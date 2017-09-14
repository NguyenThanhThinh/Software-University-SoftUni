using System.Collections.Generic;
using System.Linq;

namespace _04.AverageGrade
{
    class Student
    {
        public string Name { get; set; }
        public List<decimal> Grades { get; set; }
        public decimal AvarageGrade
        {
            get
            {
                return Grades.Average();
            }
        }
    }
}