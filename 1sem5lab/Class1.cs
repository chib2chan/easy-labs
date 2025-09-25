namespace Lab5
{
    internal partial class Program
    {
        class FitnessProgram
        {
            static int CaloriesBurned = 0;
            static int TotalExcesises = 0; 

            string[] motivationMessageArray = new string[]
            {   $"Уже {CaloriesBurned} калорий сожжено!",
                $"Уже {TotalExcesises} занятий пройдено, не сдавайся!",
                "Ура! Ты стал чуточку лучше, чем вчера!!!",
                "Пусть прогресс и не будет сразу виден, но он будет сразу ощутим!"
            };

            Random Rand { get; init; } = new Random();

            public string Name { get; init; }

            public List<string> ExercisePlan = new List<string> { };

            public int dailyCaloriesGoal;

            public FitnessProgram(string name) => this.Name = name; 

            public string ShowFitnessLevelInformation()
            { 
                return  $"{TotalExcesises} выполнено упражнений, {CaloriesBurned} сожжено," +
                        $"цель {(CaloriesBurned >= dailyCaloriesGoal ? "достигнута" : "не достигнута")}," +
                        $"уровень {(CaloriesBurned <= 1000 ? "Новичок" : CaloriesBurned <= 2000 ? "Активный" : "Спортсмен")}";
            }

            public bool Warning() => dailyCaloriesGoal < CaloriesBurned ? true : false;

            public void CompleteExercise(int calories)
            {
                CaloriesBurned += calories;
                TotalExcesises++;
            }

            public string Motivate()
            {
                return motivationMessageArray[Rand.Next(motivationMessageArray.Length)];
            }
        }
    }
}
