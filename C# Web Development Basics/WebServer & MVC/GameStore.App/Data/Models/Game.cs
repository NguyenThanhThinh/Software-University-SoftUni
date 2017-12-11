namespace GameStore.App.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructior.Common;

    public class Game
    {
        public int GameId { get; set; }

        [Required]
        [MinLength(ValidationConstants.Game.TitleMinLength),
         MaxLength(ValidationConstants.Game.TitleMaxLength)]
        public string Title { get; set; }

        [MinLength(ValidationConstants.Game.VideoIdLength),
         MaxLength(ValidationConstants.Game.VideoIdLength)]
        public string VideoId { get; set; }

        public string Url { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [MinLength(ValidationConstants.Game.DescriptionMinLength)]
        public DateTime ReleaseDate { get; set; } = new DateTime();

        public IList<UserGame> Users { get; set; } = new List<UserGame>();
    }
}