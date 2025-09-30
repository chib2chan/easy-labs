using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    internal class Jupiter : Planet, IRequireSamples
    {
        public Jupiter() : base("Юпитер") { }
        public int RequiredSamples { get; } = 3;
        bool IRequireSamples.CheckMission(Student student)
        {
            if (student.samplesTests[this] >= RequiredSamples) return true;
            return false;
        }
    }
}
