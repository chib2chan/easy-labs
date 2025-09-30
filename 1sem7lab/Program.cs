using System;
using System.Data;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using _1sem6lab;
using System.Security.Cryptography.X509Certificates;

namespace _1sem6lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пришли результаты распределения стажеров, а также их характеристики.\nГотовы их увидеть?");
            Console.ReadLine();
            Console.Clear();

            DataScience dataScience = new DataScience();
            GameDevelopment gameDevelopment = new GameDevelopment();
            MobileDevelopment mobileDevelopment = new MobileDevelopment();  

            Traineeship traineeship = new Traineeship();

            Student student1 = new Student("Линус Торвальдс", 3, Languages.Dart, 90);
            Student student2 = new Student("Дональд Кнут", 4, Languages.Python, 90);
            Student student3 = new Student("Сэр Тим Бернерс-Ли", 4, Languages.CSharp, 95);
            Student student4 = new Student("Джеймс Гослинг", 5, Languages.CSharp, 80);
            Student student5 = new Student("Андерс Хейлсберг", 3, Languages.Python, 100);
            Student student6 = new Student("Марк Цукерберг", 4, Languages.Dart, 100);
            Student student7 = new Student("Брэм Коэн", 2, Languages.Dart, 90);
            Student student8 = new Student("Брендан Айк", 3, Languages.Java, 99);
            Student student9 = new Student("Бьерн Страуструп", 4, Languages.JavaScript, 90);
            Student student10 = new Student("Джон Кармак", 3, Languages.JavaScript, 100);

            traineeship.Candidates = [student1, student2, student3, student4, student5, student6, student7, student8, student9, student10];
            traineeship.Departments = [gameDevelopment, mobileDevelopment, dataScience];

            foreach(Department item in traineeship.Departments)
            {
                item.TraineeDistribution(traineeship.Candidates);
            }

            foreach(Department item in traineeship.Departments)
            {
                if (item is DataScience science)
                {
                    Console.WriteLine(science.PrintTrainees());
                }
                else if (item is GameDevelopment development)
                {
                    Console.WriteLine(development.PrintTrainees());
                }
                else if (item is MobileDevelopment development1)
                {
                    Console.WriteLine(development1.PrintTrainees());
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine("Кандидаты, к сожалению, не прошедшие отбор:");
            foreach (var item in traineeship.Candidates)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }
}
