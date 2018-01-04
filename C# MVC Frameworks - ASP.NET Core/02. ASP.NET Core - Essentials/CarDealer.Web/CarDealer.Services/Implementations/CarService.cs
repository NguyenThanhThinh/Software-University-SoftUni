namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;
    using Models.Cars;
    using Models.Parts;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> CarsInfo(string make)
        {
            var cars = this.db.Cars.AsQueryable();

            if (!string.IsNullOrWhiteSpace(make))
            {
                cars = cars.Where(c => c.Make == make);
            }

            var result = cars
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarModel
                {
                    Model = c.Model,
                    Make = c.Make,
                    TravelledDistance = c.TravelledDistance
                }).ToList();

            return result;
        }

        public IEnumerable<CarWithPartsModel> CarWithPartsInfo()
        {
            var carsWithParts = this.db.Cars
                .Select(c => new CarWithPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts
                    .Select(p => new PartModel
                    {
                        Price = p.Part.Price,
                        PartName = p.Part.Name
                    })
                })
                .ToList();

            return carsWithParts;
        }

        public void AddCarWithParts(AddCarWithPartsModel carWithParts)
        {
            Car newCar = new Car
            {
                Make = carWithParts.Make,
                Model = carWithParts.Model,
                TravelledDistance = carWithParts.TravelledDistance
            };

            var choosenPartsIds =
                this.GetSelectedPartsIds(carWithParts.PartName, carWithParts.PartNameTwo, carWithParts.PartNameThree);

            foreach (var id in choosenPartsIds)
            {
                newCar.Parts.Add(new PartCar
                {
                    CarId = newCar.Id,
                    PartId = id
                });
            }

            this.db.Cars.Add(newCar);
            this.db.SaveChanges();
        }

        private int[] GetSelectedPartsIds(params string[] parts)
        {
            var length = parts.Count(p => p != null && p != "Select part");

            int[] partsToReturn = new int[length];

            for (int i = 0; i < length; i++)
            {
                var currentPart = this.db.Parts
                    .FirstOrDefault(p => p.Name == parts[i]);

                partsToReturn[i] = currentPart.Id;
            }

            return partsToReturn;
        }
    }
}