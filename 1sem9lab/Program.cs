using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    internal class Program
    {
        static void Main()
        {
            Student student1 = new ("Юрий Гагарин");
            Student student2 = new ("Алексей Леонов");
            Student student3 = new ("Валентина Терешкова");
            Student student4 = new ("Павел Попович");
            Student student5 = new ("Светлана Савицкая");
            Student student6 = new ("Герман Титов");
            Student student7 = new ("Владимир Комаров");

            List<Planet> planets =
            [
                new Mars(),
                new Venus(),
                new Mercury(),
                new Jupiter(),
                new Saturn(),
                new Uranus(),
                new Neptune(),
            ];

            foreach (dynamic planet in planets)
            {
                if (planet is IRequireSurvivalTest)
                {
                    student1.survivalTests.Add(planet, 80);
                    student2.survivalTests.Add(planet, 70);
                    student3.survivalTests.Add(planet, 60);
                    student4.survivalTests.Add(planet, 90);
                    student5.survivalTests.Add(planet, 50);
                    student6.survivalTests.Add(planet, 55);
                    student7.survivalTests.Add(planet, 95);

                }
                if (planet is IRequireSamples)
                {
                    student1.samplesTests.Add(planet, 5);
                    student2.samplesTests.Add(planet, 4);
                    student3.samplesTests.Add(planet, 3);
                    student4.samplesTests.Add(planet, 6);
                    student5.samplesTests.Add(planet, 2);
                    student6.samplesTests.Add(planet, 1);
                    student7.samplesTests.Add(planet, 7);
                }
            }
            List<Student> students =
            [
                student1,
                student2,
                student3,
                student4,
                student5,
                student6,
                student7,
            ];

            foreach (var planet in planets)
            {

                Console.WriteLine($"Данные о планете {planet.Name}");

                if (planet is IHaveEvilResidents evilResidents)
                {
                    Console.WriteLine(evilResidents.GetRequirementMessage());
                }
                else if (planet is ITooComplicated complicate)
                {
                    Console.WriteLine(complicate.GetComplicatedMessage());
                }
                else
                {
                    foreach (var student in students)
                    {
                        string mission = "Готовность к миссии.";

                        if (planet is IRequireSamples samplePlanet)
                        {
                            bool hasSamples = samplePlanet.CheckMission(student);
                            if (!hasSamples)
                            {
                                mission = "Не собрано достаточное количество образцов.";
                            }
                        }

                        if (planet is IRequireSurvivalTest survivalPlanet)
                        {
                            bool passedTest = survivalPlanet.CheckMission(student);
                            if (!passedTest)
                            {
                                mission = "Тест на выживание не пройден.";
                            }
                        }

                        Console.WriteLine($"{student.Name}:{mission}");
                    }
                }
                Console.WriteLine(new string('-', 30));
            }
            Console.ReadKey();
        }
    }
}
