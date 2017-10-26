namespace _01._CodeFirstStudent.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        public int ResourceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TypeOfResource { get; set; }

        [Required]
        public string Url { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<License> Licenses { get; set; } = new List<License>();
    }
}