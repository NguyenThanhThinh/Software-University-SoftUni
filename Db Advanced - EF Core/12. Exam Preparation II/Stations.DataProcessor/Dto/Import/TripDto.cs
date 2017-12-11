namespace Stations.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using Models.Enums;

    public class TripDto
    {
        [Required]
        public string Train { get; set; }

        [Required]
        public string OriginStation { get; set; }

        [Required]
        public string DestinationStation { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }

        public TripStatus Status { get; set; } = TripStatus.OnTime;

        public string TimeDifference { get; set; }
    }
}