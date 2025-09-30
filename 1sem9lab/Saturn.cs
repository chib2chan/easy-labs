using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    class Saturn : Planet, IRequireSamples
    {
        public Saturn() : base("Сатурн") { }

        public int RequiredSamples { get; } = 5;
        bool IRequireSamples.CheckMission(Student student)
        {
            if (student.samplesTests[this] >= RequiredSamples) return true;
            return false;
        }
    }
}
