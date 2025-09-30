using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    internal class Mars : Planet, IRequireSamples, IRequireSurvivalTest
    {
        public Mars() : base("Марс") { }
        public int RequiredSamples { get; } = 7;
        public int RequiredSurvivalScore { get; } = 75;

        bool IRequireSurvivalTest.CheckMission(Student student)
        {
            if (student.survivalTests[this] >= RequiredSurvivalScore) return true;
            return false;
        }
        bool IRequireSamples.CheckMission(Student student)
        {
            if (student.samplesTests[this] >= RequiredSamples) return true;
            return false;
        }
    }
}
