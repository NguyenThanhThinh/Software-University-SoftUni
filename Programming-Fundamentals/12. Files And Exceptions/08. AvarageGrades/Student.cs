using System.Collections.Generic;
using System.Linq;

namespace _08.AvarageGrades
{
    public class Student
    {
        private string name = string.Empty;
        private List<double> grades = new List<double>();
        private double avarageGrade = 0d;

        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AvarageGrade
        {
            get
            {
                return Grades.Average();
            }
        }

        public Student()
        {
            this.Grades = new List<double>();
        }
    }
}