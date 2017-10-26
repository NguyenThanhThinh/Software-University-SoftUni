namespace _01._CodeFirstStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<StudentCource> Students { get; set; } = new List<StudentCource>();

        public ICollection<Resource> Resources { get; set; } = new List<Resource>();

        public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}