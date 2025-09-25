using System;
using System.Text;

namespace Example01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1. Коллекции\nВведите длину списка"); 
            int R = ConverterInt(Console.ReadLine());
            int[] x = new int[R];
            for (int i = 0; i<R; i++)
            {
                Random rnd = new Random();
                x[i] = rnd.Next(1,101);
            }
            Console.WriteLine(ArraysReflection(x));

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Задание 2. Баланс на карте");
            var people = new Dictionary<string, int>()
            {
                {"Маша", 100},{"Василий", 40000},{"Юлия", 50000},{"Ашот", 100000}
            };
            Console.WriteLine("Введите ваше имя:");
            string name = InputSymbols(Console.ReadLine());
            Console.WriteLine("Введите сумму зачисления:");
            int sum = ConverterInt(Console.ReadLine());
            if(people.ContainsKey(name))
            {
                people[name] += sum;
                Console.WriteLine($"{name}, Ваш баланс счета изменен! Текущий баланс: {people[name]} рублей.");
            }
            else
            {
                people.Add(name, sum);
                Console.WriteLine($"Благодарим, что вы стали клиентом нашего банка! {name}, Ваш баланс счета изменен! Текущий баланс: {people[name]} рублей.");
            }
            Console.WriteLine(Monetize(people[name]));

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Задание 3. Самое длинное слово в тексте\nНапишите любое предложение и нажмите на Enter: ");
            string text = InputSymbols(Console.ReadLine());
            text = text.Replace(",", " ").Replace(".", " ").Replace("-", " ").Replace(":", " ").Replace(";", " ");
            string[] words = text.Split(" ");
            string answer = "";
            foreach(string i in words)
            {
                 if(i.Length > answer.Length) answer = i;
                 
            }
            Console.WriteLine(answer);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Задание 4. Придумайте пароль");
            string password = InputSymbols(Console.ReadLine());
            string ResultOfChekingPassowrd = CheckingPassword(password);
            Console.WriteLine(ResultOfChekingPassowrd);
        }

        /// <summary>
        /// Метод, возвращающий данные о массиве
        /// </summary>
        /// <param name="array">массив</param>
        static string ArraysReflection(int[] array)
        {
            string s = "";
            Array.Sort(array);
            s += $"Минимальное значение: {array[0]}\nМаксимальное значение: {array[^1]}\nДлина списка: {array.Length}";
            s += Multiply(array);
            return s;
        }

        /// <summary>
        /// метод, перемножающий элементы массива (по приколу)
        /// </summary>
        /// <param name="array">массив</param>
        /// <returns></returns>
        static string Multiply(int[] array)
        {
            return $"Произведение : {array[0]} * {array[^1]} == {array[0] * array[^1]}";
        }

        /// <summary>
        /// метод, возвращающий строку с данными о вкладе
        /// </summary>
        /// <param name="vklad">сумма денег пользователя</param>
        /// <returns></returns>
        static string Monetize(double vklad)
        {
            return "Вы можете воспользоваться стандартным вкладом нашего банка!" +
                $"\nВложив сумму остатка {vklad} руб. на 3 года под 17% годовых Вы получите прибыль" +
                $"{Convert.ToInt32((vklad * 0.17) + (vklad * 0.17 * 0.17) + (vklad * 0.17 * 0.17 * 0.17))} руб." +
                "\nДля активации вклада войдите в мобильное приложение!";
        }

        /// <summary>
        /// метод, проверяющий пароль на качество защиты
        /// </summary>
        /// <param name="password">пароль, придуманный пользователем</param>
        /// <returns></returns>
        static string CheckingPassword(string password)
        {
            bool Up = false;
            bool let = false;
            bool num = false;
            bool spec = false;
            bool pas = false;
            int max = 12;
            int min = 6;

            if (max >= password.Length & min <= password.Length)
            {
                foreach (char i in password)
                {
                    if (Char.IsDigit(i)) num = true;
                    if (Char.IsLower(i)) let = true;
                    if (Char.IsUpper(i)) Up = true;
                    if (Char.IsPunctuation(i)) spec = true;
                }
                if (spec == true & num == true & Up == true & let == true) pas = true;
            }
            if (pas == true) return $"Хороший ли Вы придумали пароль? - It's {pas}!";
            else return "Плохой пароль, переделывай!";
        }

        /// <summary>
        /// метод для проверки строки на пустоту
        /// </summary>
        /// <param name="s">введенная пользователем строка</param>
        public static string InputSymbols(string s)
        {
            if (!string.IsNullOrEmpty(s)) return s;
            else
            {
                Console.WriteLine("Вы ничего не ввели. Введите:");
                s = Console.ReadLine();
            }
            return s;
        }

        /// <summary>
        /// метод, переводящий string в int
        /// </summary>
        /// <param name="input">строка, переводимая в число</param>
        /// <returns></returns>
        public static int ConverterInt(string input)
        {
            input = InputSymbols(input);
            while (true)
            {
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
