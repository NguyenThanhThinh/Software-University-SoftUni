﻿namespace SimpleMvc.Domain.Data.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}