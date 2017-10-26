namespace _01._CodeFirstStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<StudentCource> Courses { get; set; } = new List<StudentCource>();

        public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}