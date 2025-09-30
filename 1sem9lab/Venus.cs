using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    internal class Venus : Planet, IHaveEvilResidents
    {
        public Venus() : base("Венера") { }

        public string GetRequirementMessage()
        {
            return "На Венере живут слишком агрессивные жители, миссия не возможна!";
        }
    }
}