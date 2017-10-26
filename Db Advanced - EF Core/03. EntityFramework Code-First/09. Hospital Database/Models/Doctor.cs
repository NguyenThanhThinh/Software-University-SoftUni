namespace _09.Hospital_Database.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new List<Visitation>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}