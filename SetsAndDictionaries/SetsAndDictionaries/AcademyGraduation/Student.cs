using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGraduation
{
    public class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double Average
        {
            get
            {
                return Grades.Sum() / Grades.Count;
            }
        }
        public Student(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
        }
        public Student() { }
    }
}
