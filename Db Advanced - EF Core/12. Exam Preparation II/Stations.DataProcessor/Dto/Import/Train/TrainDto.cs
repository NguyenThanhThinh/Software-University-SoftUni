namespace Stations.DataProcessor.Dto.Import.Train
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Models.Enums;

    public class TrainDto
    {
        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        public string Type { get; set; } = "HighSpeed";

        [Required]
        public SeatDto[] Seats { get; set; } = new SeatDto[0];
    }
}