namespace SimpleMvc.Domain.Data.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public IList<Note> Notes { get; set; } = new List<Note>();
    }
}