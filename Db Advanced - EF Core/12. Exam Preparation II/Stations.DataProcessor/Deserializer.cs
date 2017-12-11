using System;
using Stations.Data;

namespace Stations.DataProcessor
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Dto.Import;
    using Dto.Import.Ticket;
    using Dto.Import.Train;
    using Models;
    using Models.Enums;
    using Newtonsoft.Json;
    using CardDto = Dto.Import.CardDto;
    using TripDto = Dto.Import.TripDto;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonStations = JsonConvert.DeserializeObject<StationDto[]>(jsonString);

            var stations = new List<Station>();

            foreach (var station in jsonStations)
            {
                if (!IsValid(station))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                string town = station.Town;
                string name = station.Name;

                bool nameExist = stations.Any(s => s.Name == name);

                if (nameExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (town == null)
                {
                    town = name;
                }

                Station currentStation = new Station
                {
                    Name = name,
                    Town = town,
                };

                stations.Add(currentStation);
                sb.AppendLine(String.Format(SuccessMessage, name));
            }

            context.AddRange(stations);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonSeats = JsonConvert.DeserializeObject<SeatingClassesDto[]>(jsonString);

            var seats = new List<SeatingClass>();

            foreach (var seat in jsonSeats)
            {
                if (!IsValid(seat))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool seatingClassExist =
                    seats.Any(sc => sc.Name == seat.Name || sc.Abbreviation == seat.Abbreviation);

                if (seatingClassExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                string seatName = seat.Name;

                SeatingClass currentSeat = new SeatingClass
                {
                    Name = seatName,
                    Abbreviation = seat.Abbreviation
                };

                seats.Add(currentSeat);
                sb.AppendLine(String.Format(SuccessMessage, seatName));
            }

            context.AddRange(seats);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonTrains = JsonConvert.DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var trains = new List<Train>();

            foreach (var train in jsonTrains)
            {
                if (!IsValid(train))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool trainALreadyExist = trains.Any(t => t.TrainNumber == train.TrainNumber);

                if (trainALreadyExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool areSeatsValid = train.Seats.All(IsValid);

                if (!areSeatsValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool areSeatsContaintedInTheDatabase = train.Seats.All(s =>
                    context.SeatingClasses.Any(sc => sc.Abbreviation == s.Abbreviation && sc.Name == s.Name));

                if (!areSeatsContaintedInTheDatabase)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var trainType = Enum.Parse<TrainType>(train.Type);

                var trainSeats = train.Seats.Select(s => new TrainSeat
                {
                    SeatingClass = context.SeatingClasses.FirstOrDefault(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
                    Quantity = s.Quantity.Value
                })
                .ToArray();

                string trainNumber = train.TrainNumber;

                var currentTrain = new Train
                {
                    TrainNumber = trainNumber,
                    Type = trainType,
                    TrainSeats = trainSeats
                };

                trains.Add(currentTrain);
                sb.AppendLine(String.Format(SuccessMessage, trainNumber));
            }

            context.AddRange(trains);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonTrips = JsonConvert.DeserializeObject<TripDto[]>(jsonString, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var trips = new List<Trip>();

            foreach (var trip in jsonTrips)
            {
                if (!IsValid(trip))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var train = context.Trains.FirstOrDefault(t => t.TrainNumber == trip.Train);
                var arrivalStation = context.Stations.FirstOrDefault(s => s.Name == trip.DestinationStation);
                var departerStation = context.Stations.FirstOrDefault(s => s.Name == trip.OriginStation);

                if (train == null || arrivalStation == null || departerStation == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime departerTime = DateTime.ParseExact(trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                DateTime arrivalTime = DateTime.ParseExact(trip.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                if (departerTime > arrivalTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                TimeSpan timeDifference;

                if (trip.TimeDifference != null)
                {
                    timeDifference = TimeSpan.ParseExact(trip.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                Trip currentTrip = new Trip
                {
                    Train = train,
                    DestinationStation = arrivalStation,
                    OriginStation = departerStation,
                    DepartureTime = departerTime,
                    ArrivalTime = arrivalTime,
                    TimeDifference = timeDifference,
                    Status = trip.Status
                };

                trips.Add(currentTrip);
                sb.AppendLine(String.Format($"Trip from {departerStation.Name} to {arrivalStation.Name} imported."));
            }

            context.AddRange(trips);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(CardDto[]), new XmlRootAttribute("Cards"));

            var cardsDto = (CardDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var cards = new List<CustomerCard>();

            foreach (var card in cardsDto)
            {
                if (!IsValid(card))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                string customerName = card.Name;
                CardType cardType = Enum.Parse<CardType>(card.CardType);

                CustomerCard currentCard = new CustomerCard
                {
                    Name = customerName,
                    Age = card.Age,
                    Type = cardType
                };

                cards.Add(currentCard);
                sb.AppendLine(String.Format(SuccessMessage, customerName));
            }

            context.Cards.AddRange(cards);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));

            var ticketDtos = (TicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var tickets = new List<Ticket>();

            foreach (var ticket in ticketDtos)
            {
                if (!IsValid(ticket))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime departerTime =
                    DateTime.ParseExact(ticket.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var trip = context.Trips
                    .FirstOrDefault(t =>
                        t.OriginStation.Name == ticket.Trip.OriginStation
                        && t.DestinationStation.Name == ticket.Trip.DestinationStation
                        && t.DepartureTime == departerTime);

                if (trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;

                if (ticket.Card != null)
                {
                    card = context.Cards
                         .FirstOrDefault(c => c.Name == ticket.Card.Name);
                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var abbreviation = ticket.Seat.Substring(0, 2);
                var quantity = int.Parse(ticket.Seat.Substring(2));

                var abbreviationExist = context.SeatingClasses.Any(sc => sc.Abbreviation == abbreviation);

                if (!abbreviationExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var availableSeats = trip.Train.TrainSeats.Any(s =>
                    s.SeatingClass.Abbreviation == abbreviation && s.Quantity >= quantity);

                if (!availableSeats)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var currentTicket = new Ticket
                {
                    SeatingPlace = ticket.Seat,
                    Trip = trip,
                    CustomerCard = card,
                    Price = ticket.Price
                };

                tickets.Add(currentTicket);
                sb.AppendLine(String.Format($"Ticket from {trip.OriginStation.Name} to {trip.DestinationStation.Name} " +
                                            $"departing at {trip.DepartureTime.ToString(@"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} imported."));
            }

            context.AddRange(tickets);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}