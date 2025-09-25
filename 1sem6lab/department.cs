using LaboratoryWork6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem6lab;

namespace _1sem6lab
{
    internal class Department
    {
        public string Title { get; set; }
        public List<Student> Trainees { get; set; }
        public int NumberOfPositions { get; set; }
        public Department() => Trainees = [];
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

        //для 7 лабы
        public string PrintTrainees()
        {
            var result = $"Подразделение: {Title}\nСтажеры:\n";
            int NumberOfTrainee = 1;
            foreach (var trainee in Trainees)
            {
                result += $"{NumberOfTrainee}){trainee.Name}\n";
                NumberOfTrainee++;
            }
            return result;
        }
    }
}
