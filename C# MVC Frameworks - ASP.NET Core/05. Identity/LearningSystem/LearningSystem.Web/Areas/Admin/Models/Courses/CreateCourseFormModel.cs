namespace LearningSystem.Web.Areas.Admin.Models.Courses
{
    using Data;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateCourseFormModel : IValidatableObject
    {
        [Required]
        [MaxLength(DataConstants.CourseNameMaxLength, ErrorMessage = "{0} should be no more then {1} characters long.")]
        [MinLength(DataConstants.CourseNameMinLength, ErrorMessage = "{0} should be at least {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataConstants.CourseDescriptionMaxLength, ErrorMessage = "Course {0} should be no more then {1} characters long.")]
        [MinLength(DataConstants.CourseDescriptionMinLength, ErrorMessage = "Course {0} should be at least {1} characters long.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You should choose trainer.")]
        [Display(Name = "Trainer")]
        public string TrainerId { get; set; }

        public IEnumerable<SelectListItem> Trainers { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start date should be in the future.");
            }

            if (this.EndDate <= this.StartDate)
            {
                yield return new ValidationResult("End date should be after Start date.");
            }
        }
    }
}