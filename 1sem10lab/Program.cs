using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Globalization;

namespace консолька
{
    /// <summary>
    /// Ниже я проверяла, насколько отличаются показатели стопвотча
    /// в зависимости от того, чем является Даст - структурой или классом
    /// </summary>
    public struct Dust
    {
        public double Temperature;
        public double Humidity;
        public double Density;
        public double DustCapacity;
        public double ParticleSize;
        public double Resistivity;
        
        public string Conductivity;
        public string DustDispersiveness;
        public string Formation;
    }
   
    public static class Program
    {
        static void Main()
        {
            
            Stopwatch stopwatch = new();
            stopwatch.Start();// Запуск стопвотча

            string inputFileName = @"C:\Users\admin\source\repos\10 лаба - готовая консолька\консолька\dust.csv";
            string outputFileName = @"C:\Users\admin\source\repos\10 лаба - готовая консолька\консолька\generated_dust.csv";

            //работа методов для сбора статистики пылинок
            var dustData = ReadCsvFile(inputFileName);
            var statistics = GetStatistics(dustData);
            
            int numberOfSamples = 1000000; //установка необходимого количества пылинок - 1 млн. частиц
            
            //работа методов для генерации и вывода пылинок
            var generatedDust = GenerateDust(numberOfSamples, statistics);
            PrintDust(generatedDust, 10);
            WriteCsvFile(outputFileName, generatedDust);

            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Время компиляции: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }


        /// <summary>
        /// метод для чтения CSV-файла с пылинками и сбора данных
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static Dust[] ReadCsvFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName).Skip(1); // типа пропуск строки с названием параметров
            return lines.Select
            (line =>
            {
                var part = line.Split(';'); //разбиение строки из csv-файла
                return new Dust
                {
                    Resistivity = ParseDouble(part[0]),
                    Temperature = ParseDouble(part[1]),
                    Humidity = ParseDouble(part[2]),
                    Density = ParseDouble(part[3]),
                    DustCapacity = ParseDouble(part[4]),
                    ParticleSize = ParseDouble(part[5]),
                    Conductivity = part[6],
                    DustDispersiveness = part[7],
                    Formation = part[8]
                };
            }
            ).ToArray();
        }

        /// <summary>
        /// метод для проверки и перевода чисел в десяточной системе:
        /// NumberStyles.Any - параметр, позволяющий дробным числам быть в формате с точкой или запятой
        /// CultureInfo.GetCultureInfo("ru-RU") - установка "русской" запятой в качестве десятичного разделителя
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        static double ParseDouble(string value, double defaultValue = 0)
        {
            return double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out var result) ? result : defaultValue;
        }

        /// <summary>
        /// метод GetStatistic, который получает на вход массив пылинок
        /// на выходе - выдает кортеж о двух словарях 
        /// </summary>
        /// <param name="dustArray"></param>
        /// <returns></returns>
        static (Dictionary<string, double> NumericStats, Dictionary<string, Dictionary<string, int>> Text) GetStatistics(Dust[] dustArray)
        {
            //два отдельных массива для переменных с числовыми характеристиками и со строковыми значениями
            var numericProperties = new[] { "Temperature", "Humidity", "Density", "DustCapacity", "ParticleSize", "Resistivity" };
            var textProperties = new[] { "Conductivity", "DustDispersiveness", "Formation" };

            var numericStats = new Dictionary<string, double>();
            var textStats = new Dictionary<string, Dictionary<string, int>>();

            foreach (var prop in numericProperties)
            {
                var values = dustArray.Select(d => (double)d.GetType().GetField(prop).GetValue(d)).ToArray();
                numericStats[$"{prop}_Min"] = values.Min();
                numericStats[$"{prop}_Max"] = values.Max();
                numericStats[$"{prop}_Mean"] = values.Average();
                numericStats[$"{prop}_Variance"] = values.Select(v => Math.Pow(v - numericStats[$"{prop}_Mean"], 2)).Average();
                numericStats[$"{prop}_StdDev"] = Math.Sqrt(numericStats[$"{prop}_Variance"]);
            }

            foreach (var prop in textProperties)
            {
                var values = dustArray.Select(d => (string)d.GetType().GetField(prop).GetValue(d));
                textStats[prop] = values.GroupBy(v => v).ToDictionary(g => g.Key, g => g.Count());
            }

            return (numericStats, textStats);
        }

        /// <summary>
        /// генератор пылинок (с использованием нижеописанных методов для генерации double, string характеристик)
        /// просто рандомит нужные значения
        /// </summary>
        /// <param name="count"></param>
        /// <param name="stats"></param>
        /// <returns></returns>
        static Dust[] GenerateDust(int count, (Dictionary<string, double> NumericStats, Dictionary<string, Dictionary<string, int>> Text) stats)
        {
            var random = new Random();
            var generatedDust = new Dust[count];

            for (int i = 0; i < count; i++)
            {
                generatedDust[i] = new Dust
                {
                    Temperature = GenerateRandomDoubleValue(stats.NumericStats, "Temperature", random),
                    Humidity = GenerateRandomDoubleValue(stats.NumericStats, "Humidity", random),
                    Density = GenerateRandomDoubleValue(stats.NumericStats, "Density", random),
                    DustCapacity = GenerateRandomDoubleValue(stats.NumericStats, "DustCapacity", random),
                    ParticleSize = GenerateRandomDoubleValue(stats.NumericStats, "ParticleSize", random),
                    Resistivity = GenerateRandomDoubleValue(stats.NumericStats, "Resistivity", random),
                    Conductivity = GenerateRandomStringValue(stats.Text, "Conductivity", random),
                    DustDispersiveness = GenerateRandomStringValue(stats.Text, "DustDispersiveness", random),
                    Formation = GenerateRandomStringValue(stats.Text, "Formation", random)
                };
            }

            return generatedDust;
        }

        /// <summary>
        /// генератор для рандомных double-значений по правилам статистики
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="property"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        static double GenerateRandomDoubleValue(Dictionary<string, double> stats, string property, Random random)
        {
            double min = stats[$"{property}_Min"];
            double max = stats[$"{property}_Max"];
            double mean = stats[$"{property}_Mean"];
            double value;
            do
            {
                value = min + random.NextDouble() * (max - min);
            }
            while  (Math.Abs(value - mean) > (max - min) / 2);

            return value;
        }

        /// <summary>
        /// генератор для рандомных string-значений
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="property"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        static string GenerateRandomStringValue(Dictionary<string, Dictionary<string, int>> stats, string property, Random random)
        {
            var values = stats[property];
            int totalFrequency = values.Values.Sum();
            int choice = random.Next(totalFrequency);

            foreach (var kvp in values)
            {
                choice -= kvp.Value;
                if (choice < 0) return kvp.Key;
            }

            return values.Keys.First();
        }

        /// <summary>
        /// метод для вывода данных о пыли в консоль
        /// (закомментирован)
        /// </summary>
        /// <param name="dustArray">массив для пылинок</param>
        /// <param name="count">сколько пыли требуется создать</param>
        static void PrintDust(Dust[] dustArray, int count)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Temp. \t Humid. \t Density \t Capacity \t Size \t Resist. \t Conduct. \t Dispers. \t Format. \n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Math.Min(count, dustArray.Length); i++)
            {
                Console.WriteLine($"{dustArray[i].Temperature}\t{dustArray[i].Humidity}\t{dustArray[i].Density}\t{dustArray[i].DustCapacity}\t{dustArray[i].ParticleSize}\t{dustArray[i].Resistivity}\t{dustArray[i].Conductivity}\t{dustArray[i].DustDispersiveness}\t{dustArray[i].Formation}\n");
            }
        }

        /// <summary>
        /// метод для записи данных в файл при помощи стримрайтера
        /// </summary>
        /// <param name="fileName">файл, в который записываются данные с массива</param>
        /// <param name="dustArray">массив пылинок</param>
        static void WriteCsvFile(string fileName, Dust[] dustArray)
        {
            using var writer = new StreamWriter(fileName);
            writer.WriteLine("Temperature;Humidity;Density;DustCapacity;ParticleSize;Resistivity;Conductivity;DustDispersiveness;Formation");
            foreach (var dust in dustArray)
            {
                writer.WriteLine($"{dust.Temperature};{dust.Humidity};{dust.Density};{dust.DustCapacity};{dust.ParticleSize};{dust.Resistivity};{dust.Conductivity};{dust.DustDispersiveness};{dust.Formation}");
            }
        }
    }
}
