using System;
using System.Collections.Generic;

namespace _08.MentorGroup
{
    class Student
    {
        private List<string> comments = new List<string>();
        private List<DateTime> dates = new List<DateTime>();
        private string name = "";


        public List<string> Comments { get; set; }
        public List<DateTime> Dates { get; set; }
        public string Name { get; set; }

        public Student()
        {
            this.Comments = new List<string>();
            this.Dates = new List<DateTime>();
        }
    }
}