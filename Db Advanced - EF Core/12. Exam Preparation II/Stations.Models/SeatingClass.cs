﻿namespace Stations.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SeatingClass
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2), MinLength(2)]
        public string Abbreviation { get; set; }
    }
}