namespace _09.Hospital_Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        public Visitation()
        {
            this.Comments = new List<string>();
        }

        public Visitation(DateTime visitDate)
        {
            this.VisitDate = visitDate;
        }

        [Key]
        public int Id { get; set; }

        public DateTime VisitDate { get; set; }

        public Doctor Doctor { get; set; }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
    }
}