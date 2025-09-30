using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    internal class Student(string name)
    {
        public string Name { get; } = name;

        public Dictionary<IRequireSurvivalTest, int> survivalTests = [];
        
        public Dictionary<IRequireSamples, int> samplesTests = [];
    }
}