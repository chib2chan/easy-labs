using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Lab5
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в Fitness!\nВведите ваше имя:");
            
            FitnessProgram FitnessSession = new FitnessProgram(InputSymbols(Console.ReadLine()));
            SetNewExercisePlan(FitnessSession);

            Console.WriteLine("Введите целевое количество калорий");

            string set_daily_calories_goal = InputSymbols(Console.ReadLine());
            int result = 0;
            int.TryParse(set_daily_calories_goal, out result);

            Console.Clear();
            while (true)
            {
                Console.WriteLine(  $"Приветствую, {FitnessSession.Name}! Пожалуйста, выберите, чем Вы хотели бы заняться:" +
                                    "\n1. Выполнить упражнение\n2. Вывести текущую информацию о пользователе" +
                                    "\n3. Установить целевую норму калорий\n4. Задать новый план тренировок\n5. Изменить текущий план тренировок" +
                                    "\n6. Вывести мотивационное сообщение\n7. Выход из приложения");

                int clientChoise = ConverterInt(Console.ReadLine());
                switch (clientChoise)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите название упражнения.");
                        DoExercise(InputSymbols(Console.ReadLine()), FitnessSession);
                        break;
                    case 2:
                        Console.Clear();
                        ShowFitnessLevelInformation(FitnessSession);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Введите новую цель по калориям.");
                        SetDailyCaloriesGoal(ConverterInt(Console.ReadLine()), FitnessSession);
                        break;
                    case 4:
                        Console.Clear();
                        SetNewExercisePlan(FitnessSession);
                        break;
                    case 5:
                        Console.Clear();
                        EditExercisePlan(FitnessSession);
                        break;
                    case 6:
                        Console.Clear();
                        Motivate(FitnessSession);
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("До новых встреч!");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
        }

        static void DoExercise(string ExerciseName, FitnessProgram thisProgram)
        {
            if (thisProgram.ExercisePlan.Contains(ExerciseName))
            {
                Console.WriteLine("Введите количество сожженных калорий.");
                string k = InputSymbols(Console.ReadLine());
                thisProgram.CompleteExercise(int.Parse(k));
                thisProgram.ExercisePlan.Remove(ExerciseName);
            }
            else
            {
                Console.WriteLine("Такого упражнения нет.");
            }
            Console.ReadKey();
        }

        static void ShowFitnessLevelInformation(FitnessProgram thisProgram)
        {
            Console.WriteLine(thisProgram.ShowFitnessLevelInformation());
            Console.ReadKey();
        }

        static void SetDailyCaloriesGoal(int Goal, FitnessProgram thisProgram)
        {
            thisProgram.dailyCaloriesGoal = Goal;
            Console.WriteLine($"Целевое количество калорий изменено на {Goal}.");
            Console.ReadKey();
        }

        static void SetNewExercisePlan(FitnessProgram thisProgram)
        {
            Console.WriteLine("Введите новый план тренировок (разделяйте упражнения через Enter):");
            thisProgram.ExercisePlan.Clear();
            while (true)
            {
                string NewExercise = InputSymbols(Console.ReadLine());
                thisProgram.ExercisePlan.Add(NewExercise);
            }
        }

        static void EditExercisePlan(FitnessProgram thisProgram)
        {
            if (thisProgram.ExercisePlan.Count > 0)
            {
                while (true)
                {
                    Console.WriteLine("Текущий план:", String.Join(", ", thisProgram.ExercisePlan) +
                                      "\n1. Добавить новое упражнение\n2. Удалить упражнение");

                    int Choice = ConverterInt(Console.ReadLine());

                    switch (Choice)
                    {
                        case 1:
                            thisProgram.ExercisePlan.Add(InputSymbols(Console.ReadLine()));
                            break;

                        case 2:
                            string ExcersiseName = InputSymbols(Console.ReadLine());
                            if (thisProgram.ExercisePlan.Contains(ExcersiseName)) thisProgram.ExercisePlan.Remove(ExcersiseName);
                            else Console.WriteLine("Такого упражнения нет.");
                            
                            break;

                        default:
                            break;

                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else Console.WriteLine("Невозможно отредактировать."); 
        }

        static void Motivate(FitnessProgram thisProgram)
        {
            Console.WriteLine(thisProgram.Motivate());
            Console.ReadKey();
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
                Console.WriteLine("Вы ничего не ввели. Введите повторно:");
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