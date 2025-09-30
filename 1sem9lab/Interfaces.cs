using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    internal interface IHaveEvilResidents
    {
        public string GetRequirementMessage()
        {
            return "На этой планете живут агрессивные жители, миссия не возможна!";
        }
    }
    internal interface ITooComplicated
    {
        public string GetComplicatedMessage()
        {
            return $"Слишком сложно для студентов, миссия не возможна!";
        }
    }
    internal interface IRequireSamples
    {
        int RequiredSamples { get; }
        bool CheckMission(Student student);
    }
    internal interface IRequireSurvivalTest
    {
        int RequiredSurvivalScore { get; }
        bool CheckMission(Student student)
        {
            return false;
        }
    }
}
