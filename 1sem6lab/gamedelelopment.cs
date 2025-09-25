using LaboratoryWork6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem6lab;

namespace _1sem6lab
{
    internal class GameDevelopment : Department
    {
        public GameDevelopment()
        {
            Title = "Разработка игр";
            NumberOfPositions = 5;
            Trainees = new List<Student>();
        }

        public override void TraineeDistribution(List<Student> candidates)
        {
            for (var i = candidates.Count - 1; i >= 0; i--)
            {
                var item = candidates[i];
                if ((NumberOfPositions > 0) && (item.ProgrammingLanguage == Languages.CSharp || item.ProgrammingLanguage == Languages.Java))
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
            var result = "Подразделение: Разработка игр\nСписок стажеров и их владение языками программирования:\n";
            int NumberOfTrainee = 1;
            foreach (var trainee in Trainees)
            {
                result += $"{NumberOfTrainee}){trainee.Name}:\nЯзык программирования: {trainee.ProgrammingLanguage}\n";
                NumberOfTrainee++;
            }
            return result;
        }
    }
}
