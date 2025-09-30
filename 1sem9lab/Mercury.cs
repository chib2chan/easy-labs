using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _1sem9lab;

namespace _1sem9lab
{
    internal class Mercury : Planet, IRequireSurvivalTest
    {
        public Mercury() : base("Меркурий") { }
        public int RequiredSurvivalScore { get; } = 85;
        bool IRequireSurvivalTest.CheckMission(Student student)
        {
            if (student.survivalTests[this] >= RequiredSurvivalScore) return true;
            return false;
        }
    }
}
