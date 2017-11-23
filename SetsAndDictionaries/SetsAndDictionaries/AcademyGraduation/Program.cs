using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGraduation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int numberOfStudents = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; ++i)
            {
                string name = Console.ReadLine();
                List<double> grades = new List<double>();
                string[] strs = Console.ReadLine().Split().ToArray();
                foreach (var str in strs)
                {
                    if (Double.TryParse(str, out double dblVal))
                    {
                        grades.Add(dblVal);
                    }
                }
                students.Add(new Student() { Name = name, Grades = grades });
            }
            foreach(Student s in students)
            {
                Console.WriteLine(s.Name + " is graduated with " + s.Average.ToString("F3"));
            }
            Console.ReadLine();
        }
    }
}
