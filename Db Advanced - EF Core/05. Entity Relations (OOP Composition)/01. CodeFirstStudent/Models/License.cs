namespace _01._CodeFirstStudent.Models
{
    using System.ComponentModel.DataAnnotations;

    public class License
    {
        public int LicenseId { get; set; }

        [Required]
        public string Name { get; set; }

        public Resource Resource { get; set; }

        public int ResourceId { get; set; }
    }
}