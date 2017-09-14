using System;

namespace _11.Custom_Attribute
{
    class CustomAttribute : Attribute
    {
        private string author;
        private int revision;
        private string description;
        private string reviewers;

        public string Reviewers
        {
            get { return reviewers; }
            set { reviewers = value; }
        }

        public CustomAttribute(string author, int revision, string description, string reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Revision
        {
            get { return revision; }
            set { revision = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
    }
}