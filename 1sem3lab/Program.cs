using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Example01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№1. Рандомайзер натуральных чисел из заданного промежутка");
            Console.ForegroundColor = ConsoleColor.White;
            Random r = new Random();
            int RandomNumber = r.Next(1, 10);
            int count = 1;
            Console.WriteLine("Компьютер загадал число от 1 до 10. Попробуйте отгадать его (попытки не ограничены)");
            int MyNumber = Converter(Console.ReadLine());
            while (count > 0)
            {
                if (RandomNumber == MyNumber)
                {
                    Console.WriteLine($"Да! Компьютер загадал число {MyNumber}! Вы угадали с попытки №{count}!");
                    break;
                }
                else
                {
                    count++;
                    if (MyNumber < RandomNumber)
                    {
                        Console.WriteLine($"Попытка №{count}. Нет, это не число {MyNumber}! Загаданное число больше введенного, попробуйте ещё раз:");
                    }
                    else
                    {
                        Console.WriteLine($"Попытка №{count}. Нет, это не число {MyNumber}! Загаданное число меньше введенного, попробуйте ещё раз:");
                    }

                    MyNumber = Converter(Console.ReadLine());
                }
            }

            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№2. Нахождение суммы квадратов всех чисел последовательности");
            Console.ForegroundColor = ConsoleColor.White;
            int N = Converter(Console.ReadLine());
            int firstel = 1;
            int summ = 0;
            int sqvr = 0;
            if (N <= 10)
            {
                Console.WriteLine("Вы ввели некорректное значение N - оно должно быть больше 10!");
            }
            else
            {
                while (firstel != N)
                {
                    summ += firstel;
                    sqvr += firstel * firstel;
                    firstel += 1;
                    if (sqvr > 500)
                    {
                        Console.WriteLine("К сожалению, сумма всех квадратов превысила 500.");
                        break;
                    }
                }
                Console.WriteLine($"Сумма чисел равна: {summ}, максимальное возможное число = 11\nСумма квадратов равна: {sqvr}");
            }

            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№3. Зачёт по физкультуре");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Пожалуйста, ведите количество учеников, сдававших зачёт:");
            int countSTUDENTS = Converter(Console.ReadLine());
            int[] plan = new int[countSTUDENTS];
            for (int i = 0; i < countSTUDENTS; i++)
            {
                Random random = new();
                plan[i] = random.Next(1, 21);
            }
            int f2, f3, f4, f5;
            f2 = f3 = f4 = f5 = 0;
            foreach (int i in plan)
            {
                if (i > 15) f5 += 1;
                
                else if (i > 13) f4 += 1;
                
                else if (i > 11) f3 += 1;
                
                else f2 += 1;
            }
            Console.WriteLine($"Количество не сдавших зачет: {f2}.\nОценка 3 - у {f3} студентов.\nОценка 4 - у {f4} студентов.\nОценка 5 - у {f5} студентов");
            Console.WriteLine($"Минимально подтягиваний: {plan.Min()}\nМаксимально подтягиваний: {plan.Max()}");

            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№4. Нахождение значений функции на определенном промежутке");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите значение для переменной A");
            double A = Converter(Console.ReadLine());
            Console.WriteLine("Введите значение для переменной B");
            double B = Converter(Console.ReadLine());
            Console.WriteLine("Введите значение для переменной C");
            double C = Converter(Console.ReadLine());
            Console.WriteLine("Введите значение для переменной D");
            double D = Converter(Console.ReadLine());
            double ya = 0;
            double y = 0;
            for (int x = 1; x < 11; x++)
            {
                if (B * x + D >= 0)
                {
                    y += A * Math.Sqrt(B * x + D) - C * x;
                    if (A * Math.Sqrt(B * x + D) - C * x > 0)
                    {
                        ya += A * Math.Sqrt(B * x + D) - C * x;
                    }
                }
            }
            Console.WriteLine($"Сумма положительных значений: {ya}");
            Console.WriteLine($"Среднее значение функции: {y / 10}");

            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№5. Работа с массивом A");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("Введите количество чисел в массиве (размер массива)");
            int newN = Converter(Console.ReadLine());
            Console.WriteLine("Введите элементы маассива (через пробел):");
            int[] massi = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (massi.Length != newN)
            {
                Console.WriteLine("Ошибка, введите заново");
                return;
            }           
            int maxIndex = Array.IndexOf(massi, massi.Max());
            int max = massi[maxIndex];
            massi[maxIndex] = massi[newN - 1];
            massi[newN - 1] = max;
            Console.WriteLine("Новый вид массива: ");
            Console.WriteLine(string.Join("", massi));
            Console.WriteLine($"Последним элементом массива стал {massi.Last()}");

            Console.ReadKey();
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№6. Окружности на координатной плоскости");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите радиус круга R:");
            int R = Converter(Console.ReadLine());
            int[] xs = new int[12];
            int[] ys = new int[12]; 
            for (int i = 0; i < xs.Length; i++)
            {
                 Random rnd =  new Random();
                 xs[i] = rnd.Next(-100,100); 
                 ys[i] = rnd.Next(-100,100);
                 Console.WriteLine($"Координаты случайно сгенерированной точки: {xs[i]}, {ys[i]}"); 
            }
            int k = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                 if (Math.Sqrt((xs[i] * xs[i]) + (ys[i] * ys[i])) < R * 2)
                 {
                     k+=1;
                 }
            }
            Console.WriteLine($"Количество окружностей, пересекающиеся с первичной: {k}");
        }

        /// <summary>
        /// метод, переводящий string в int
        /// </summary>
        /// <param name="input">строка, переводимая в число</param>
        /// <returns></returns>
        public static int Converter(string input)
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
                    }
                }
            }
        }
    }
}
