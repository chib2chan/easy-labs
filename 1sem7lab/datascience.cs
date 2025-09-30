using LaboratoryWork6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem6lab;

namespace _1sem6lab
{
    internal class DataScience : Department
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
                if ((NumberOfPositions > 0) && (item.ProgrammingLanguage == Languages.Python) && (item.Achievment >= 85))
                {
                    Trainees.Add(item);
                    candidates.Remove(item);
                    NumberOfPositions--;
                }
            }
        }

        //для 7 лабы
        new public string PrintTrainees()
        {
            //var result = base.PrintTrainees();
            var result = "Подразделение: Анализ данных\nСписок стажеров и их успеваемость:\n";
            int NumberOfTrainee = 1;
            foreach (var trainee in Trainees)
            {
                string CourseNumber = trainee.TrainingCourse;
                result += $" {NumberOfTrainee}) {trainee.Name}:\nУспеваемость: {trainee.Achievment}\n";
                NumberOfTrainee++;
            }
            return result;
        }
    }
}
