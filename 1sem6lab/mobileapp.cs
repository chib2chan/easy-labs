using _1sem6lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1sem6lab
{
    internal class MobileDevelopment : Department
    {
        public MobileDevelopment()
        {
            Title = "Разработка мобильных приложений";
            NumberOfPositions = 3;
            Trainees = new List<Student>();
        }
        public override void TraineeDistribution(List<Student> candidates)
        {
            for (var i = candidates.Count - 1; i >= 0; i--)
            {
                var item = candidates[i];
                if ((NumberOfPositions > 0) && (item.ProgrammingLanguage == Languages.Dart) && (item.CourseNumber >= 3) && (item.Achievment >= 90))
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
            var result = "Подразделение: Разработка мобильных приложений\nСписок стажеров, их курс и владение ЯП:\n";
            int NumberOfTrainee = 1;
            foreach (var trainee in Trainees)
            {
                result += $"{NumberOfTrainee}){trainee.Name}:\nКурс обучения: {trainee.CourseNumber}, язык программирования: {trainee.ProgrammingLanguage}\n";
                NumberOfTrainee++;
            }
            return result;
        }
    }
}