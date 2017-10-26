namespace _09.Hospital_Database.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Diagnose
    {
        public Diagnose()
        {
            this.Comments = new List<string>();
        }

        public Diagnose(string name, List<string> comments)
        {
            this.Name = name;
            this.Comments = comments;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
    }
}