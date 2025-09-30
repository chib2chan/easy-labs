using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem6lab;

namespace _1sem6lab
{
    public class Student
    {
        public string Name { get; set; }
        public int CourseNumber { get; set; }
        public Languages ProgrammingLanguage { get; set; }
        public double Achievment { get; set; }
        public string TrainingCourse { get; set; }
        public Student(string name, int courseNumber, Languages programmingLanguage, double achievment)
        {
            Name = name;
            CourseNumber = courseNumber;
            ProgrammingLanguage = programmingLanguage;
            Achievment = achievment;
        }
    }
}
