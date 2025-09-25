using System;
using System.Collections;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _1sem1lab
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№1. Кто я?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Меня зовут Яна Руцкая, я знаю Python!");

            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№2. Нахождение тангенса угла между осью абcцисс и прямой, проведенной через начало координат и заданную точку");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите целочисленные координаты точки по оси X:");
            int X = Converter(Console.ReadLine());
            Console.WriteLine("Введите целочисленные координаты точки по оси Y:");
            int Y = Converter(Console.ReadLine());

            if (Y == 0)
            {
                Console.WriteLine("Невозможно рассчитать тангенс угла. (Координата Y принадлежит  оси Y)");
            }
            else
            {
                if (X == 0)
                {
                    Console.WriteLine("Тангенс угла равен 0");
                }
                else
                {
                    double tg = Y / X;
                    Console.WriteLine($" Тангенс угла равен  {tg}");
                }

            }

            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№3. Задание с кольцевой дорогой");
            Console.ForegroundColor = ConsoleColor.White;
            int L = 163;
            Console.WriteLine("Введите скорость автомобиля V:");
            int V = Converter(Console.ReadLine());
            Console.WriteLine("Введите время пути T:");
            int T = Converter(Console.ReadLine());

            if ((T > 0) || (T == 0))
            {
                if ((V > 0) || (V == 0))
                {
                    int WhereAmI = (V * T) % 163;
                    int HowManyRounds = V * T / 163;
                    Console.WriteLine($"Автомобиль остановился на отметке  {WhereAmI}, при этом проехал {HowManyRounds} кругов");
                }
                else
                {
                    int WhereAmI = 163 - (V * (-1) * T % 163);
                    int HowManyRounds = V * (-1) * T / 163;
                    Console.WriteLine($"Автомобиль остановился на отметке  {WhereAmI}, при этом проехал {HowManyRounds} кругов");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели некорректное время.");
                Console.WriteLine("Введите скорость автомобиля V:");
                V = Converter(Console.ReadLine());
                Console.WriteLine("Введите время пути T:");
                T = Converter(Console.ReadLine());
            }

            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№4. Рандомайзер натуральных чисел из заданного промежутка");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите первое число:");
            int Num1 = Converter(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int Num2 = Converter(Console.ReadLine());
            if (Num1 < Num2)
            {
                Random r = new Random();
                int RandomAns = r.Next(Num1, Num2);
                Console.WriteLine($"Случайное число: {RandomAns}");
            }
            else
            {
                Random r = new Random();
                int RandomAns = r.Next(Num2, Num1);
                Console.WriteLine($"Случайное число: {RandomAns}");
            }

            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№5. Решение уравнения с целочисленными переменными");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите число A:");
            int A = Converter(Console.ReadLine());
            Console.WriteLine("Введите число B:");
            int B = Converter(Console.ReadLine());
            Console.WriteLine("Введите число C:");
            int C = Converter(Console.ReadLine());
            Console.WriteLine("Введите число D:");
            int D = Converter(Console.ReadLine());
            if ((D < 0) || (D == 0) || (C == 0))
            {
                Console.WriteLine("Данное уравнение нерешаемо.");
                Console.WriteLine("Введите число A:");
                A = Converter(Console.ReadLine());
                Console.WriteLine("Введите число B:");
                B = Converter(Console.ReadLine());
                Console.WriteLine("Введите число C:");
                C = Converter(Console.ReadLine());
                Console.WriteLine("Введите число D:");
                D = Converter(Console.ReadLine());
            }
            else
            {
                var Z = (A / C) * (B / D) - (A * B - C) / (C * D) + Math.Sqrt(D);
                Console.WriteLine($"Число Z = {Z}");
            }

            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("№6. Нахождение площади треугольника по формуле Герона\nПоочередно введите длины сторон треугольника:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите число A:");
            int a = Converter(Console.ReadLine());
            Console.WriteLine("Введите число B:");
            int b = Converter(Console.ReadLine());
            Console.WriteLine("Введите число C:");
            int c = Converter(Console.ReadLine());

            double P = (a + b + c) / 2; //полупериметр

            while(true)
            {
                if ((a + b < c) || (a + c < b) || (c + b < a))
                {
                    Console.WriteLine("Вы ввели не стороны треугольника, повторите попытку.");
                    Console.WriteLine("Введите число A:");
                    a = Converter(Console.ReadLine());
                    Console.WriteLine("Введите число B:");
                    b = Converter(Console.ReadLine());
                    Console.WriteLine("Введите число C:");
                    c = Converter(Console.ReadLine());
                }
                else
                {
                    double S = Math.Sqrt(P * (P - a) * (P - b) * (P - c));
                    Console.WriteLine($"Площадь прямоугольника равна {S}");
                    break;
                }
            }
        }

        /// <summary>
        /// метод, переводящий string в int
        /// </summary>
        /// <param name="input">строка, переводимая в число</param>
        /// <returns></returns>
        public static int Converter (string input)
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
