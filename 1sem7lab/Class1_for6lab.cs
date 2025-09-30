using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork6
{
    internal class Student
    {
        public Student(string name, int course, Languages lang, double achievment)
        {
            Name = name;
            CourseNumber = course;
            ProgrammingLanguage = lang;
            Achievment = achievment;
        }
        public string Name { get; set; }
        public int CourseNumber { get; set; }
        public double Achievment { get; set; }

        public Languages ProgrammingLanguage { get; set; }
        public enum Languages
        {
            CPlusPlus,
            CSharp,
            Python,
            Dart,
            Java,
            JavaScript
        }
    }

    internal class Traineeship
    {
        public List<Student> Candidates { get; set; }
        public List<Department> Departments { get; set; }
        public Traineeship()
        {
            Candidates = new List<Student>();
            Departments = new List<Department>();
        }

    }

    internal class Department
    {
        public string Title { get; set; }
        public List<Student> Trainees { get; set; }
        public int NumberOfPositions { get; set; }
        public Department()
        {
            Trainees = new List<Student>();
        }
        public virtual void TraineeDistribution(List<Student> candidates)
        {
            for (var i = candidates.Count - 1; i >= 0; i--)
            {
                var item = candidates[i];
                if (item.CourseNumber >= 2)
                {
                    Trainees.Add(item);
                    candidates.Remove(item);
                }
            }
        }
    }

    class GameDevelopment : Department
    {
        public GameDevelopment()
        {
            Title = "Разработка игр";
            NumberOfPositions = 4;
            Trainees = new List<Student>();
        }
        public override void TraineeDistribution(List<Student> candidates)
        {
            for (var i = candidates.Count - 1; i >= 0; i--)
            {
                var item = candidates[i];
                if ((NumberOfPositions > 0) && ((item.ProgrammingLanguage == Student.Languages.CPlusPlus) || (item.ProgrammingLanguage == Student.Languages.CSharp)) && (item.CourseNumber >= 2) && (item.Achievment >= 80)) 
                {
                    Trainees.Add(item);
                    candidates.Remove(item);
                    NumberOfPositions--;
                }
            }
        }
    }

    class DataScience : Department
    {
        public DataScience()
        {
            Title = "Анализ данных";
            NumberOfPositions = 4;
            Trainees = new List<Student>();
        }
        public override void TraineeDistribution(List<Student> candidates)
        {
            for (var i = candidates.Count - 1; i >= 0; i--)
            {
                var item = candidates[i];
                if ((NumberOfPositions > 0) && (item.ProgrammingLanguage == Student.Languages.Python) && (item.Achievment >= 85))
                {
                    Trainees.Add(item);
                    candidates.Remove(item);
                    NumberOfPositions--;
                }
            }
        }
    }

    class MobileAplicationDevelopment : Department
    {
        public MobileAplicationDevelopment()
        {
            Title = "Разработка мобильных приложений";
            NumberOfPositions = 4;
            Trainees = new List<Student>();
        }

        public override void TraineeDistribution(List<Student> candidates)
        {
            for (var i = candidates.Count - 1; i >= 0; i--)
            {
                var item = candidates[i]; 
                if ((NumberOfPositions > 0) && (item.ProgrammingLanguage == Student.Languages.Dart) && (item.CourseNumber >= 3) && (item.Achievment >= 90))
                {
                    Trainees.Add(item);
                    candidates.Remove(item);
                    NumberOfPositions--;
                }
            }
        }

    }
}
