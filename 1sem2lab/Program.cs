using System;
using System.Text;

namespace _1sem2lab
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№1. Рассчитаться на первый-второй!\nКакой Серёжа стоит в строю?");
            Console.ForegroundColor= ConsoleColor.White;

            double N = ConverterInt(Console.ReadLine());
            if (N % 2 == 0)  Console.WriteLine("Второй!");
            else  Console.WriteLine("Первый!");

            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n№2.Проверка сторон на принадлежность треугольнику и нахождение угла С");

            Console.WriteLine("Поочередно введите длины сторон треугольника:");
            Console.ForegroundColor = ConsoleColor.White;
            int a = ConverterInt(Console.ReadLine());
            int b = ConverterInt(Console.ReadLine());
            int c = ConverterInt(Console.ReadLine());

            while ((a + b <= c) || (a + c <= b) || (c + b <= a))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели не стороны треугольника, повторите попытку.");
                Console.ForegroundColor = ConsoleColor.White;
                a = ConverterInt(Console.ReadLine());
                b = ConverterInt(Console.ReadLine());
                c = ConverterInt(Console.ReadLine());
            }

           if ((Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2)) || (Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2)) || (Math.Pow(c, 2) + Math.Pow(b, 2) == Math.Pow(a, 2)))
           {
               Console.WriteLine("Этот треугольник - прямоугольный (Градусная мера угла С равна 90).");
           }
           else
           {
               double cosAngleC = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * c * b);
               double angleC = Math.Acos(cosAngleC);
               Console.WriteLine($"Градусная мера угла С равна {angleC}");
           }

            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n№3. Кто последний по записи?"+
                "\nприемное время в больнице с 9:00 до 17:20, а осмотр каждого пациента = 20 минут." +
                "\nЗначит, в 2х кабинетах врачи успеют осмотреть 2*(8*3 + 1) = 50 человек." +
                "\nВведите номер Сергея в очереди:");
            Console.ForegroundColor = ConsoleColor.White;
            int numberOgSergei = ConverterInt(Console.ReadLine());

            if (((numberOgSergei > 0) || (numberOgSergei == 0)) && (numberOgSergei < 50))
            {
                int people = ((numberOgSergei + 1) / 2) + ((numberOgSergei + 1) % 2);
                int TimeOfWaitingHour = (people % 3) * 20;
                int TimeOfWaitingMin = people * 20;

                if (TimeOfWaitingMin < 60)
                {
                    Console.WriteLine($"Сергею стоит стоять в очереди. Он простоит в ожидании {TimeOfWaitingMin} минут");
                }
                else
                {
                    Console.WriteLine($"Сергею стоит стоять в очереди. Он простоит в ожидании {TimeOfWaitingHour} часов и {TimeOfWaitingMin} минут");
                }
            }
            else
            {
                Console.WriteLine("Сергею уже не имеет смысл стоять в очереди.");
            }

            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n№4. Виды вклада\nВас приветствует ДайДенегБанк! Мы готовы предложить Вам, уважаемый клиент, следующие виды вкладов:");
            Console.WriteLine("1) вклад на 1 год под 7% годовых\n2) вклад на 2 год под 8% годовых\n3) вклад на 5 лет под 10% годовых");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Введите номер вклада, который Вас заинтересовал:");
            double TypeOfDeposit = ConverterDouble(Console.ReadLine());

            Console.WriteLine("Введите сумму ваших денежных средств для вклада, вид которого Вы выбрали ранее:");
            double SumOfDeposit = ConverterDouble(Console.ReadLine());

            string answerForClient = "Уважаемый клиент,";

            switch (TypeOfDeposit)
            {
                case 1:
                    answerForClient += $"Ваша прибыль будет составлять {(SumOfDeposit * 1.07) - SumOfDeposit} руб.";
                    break;
                case 2:
                    answerForClient += $"Ваша прибыль будет составлять {SumOfDeposit * Math.Pow(1.08, 3) - SumOfDeposit} руб.";
                    break;
                case 3:
                    answerForClient += $"Ваша прибыль будет составлять {SumOfDeposit * Math.Pow((1.1), 5) - SumOfDeposit} руб.";
                    break;
                default:
                    answerForClient += "нам жаль, что Вас не интересуют наши услуги.\nХорошего дня!";
                    break;
            }
            Console.WriteLine(answerForClient);

            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n№5. Автомобиль едет по дороге с автоматической фиксацией скорости\nВведите, с какой скоростью автомобиль едет по дороге:");
            Console.ForegroundColor = ConsoleColor.White;

            double speed = ConverterDouble(Console.ReadLine());

            if (speed < 90 + 20)
            {
                Console.WriteLine("Скорость автомобиля допустима на данном участке.");
            }
            else
            {
                if ((speed > 119) && (speed < 130))
                {
                    Console.WriteLine("Размер штрафа составляет 500 рублей.");
                }
                else if ((speed > 129) && (speed < 150))
                {
                    Console.WriteLine("Размер штрафа составляет 1500 рублей.");
                }
                else if ((speed > 149) && (speed < 170))
                {
                    Console.WriteLine("Размер штрафа составляет 2500 рублей. Возможно лишение водительских прав на 4 месяца");
                }
                else if ((speed > 170) && (speed < 210))
                {
                    Console.WriteLine("Размер штрафа составляет 5000 рублей. Возможно лишение водительских прав на 6 месяцев");
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Ты живой??");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// метод, переводящий string в double
        /// </summary>
        /// <param name="input">строка, переводимая в число</param>
        /// <returns></returns>
        public static double ConverterDouble(string input)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You didn't enter anything.");
                    input = Console.ReadLine();
                }
                if (double.TryParse(input, out double number))
                {
                    try
                    {
                        double newNumber = number;
                        return newNumber;
                    }
                    catch
                    {
                        Console.WriteLine("You entered invalid numbers.");
                        input = Console.ReadLine();
                    }
                }
            }
        }

        /// <summary>
        /// метод, переводящий string в int
        /// </summary>
        /// <param name="input">строка, переводимая в число</param>
        /// <returns></returns>
        public static int ConverterInt(string input)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You didn't enter anything.");
                    input = Console.ReadLine();
                }
                if (int.TryParse(input, out int number))
                {
                    try
                    {
                        int newNumber = number;
                        return newNumber;
                    }
                    catch
                    {
                        Console.WriteLine("You entered invalid numbers.");
                        input = Console.ReadLine();
                    }
                }
            }
        }
    }
}
