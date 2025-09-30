using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    internal class Uranus: Planet, ITooComplicated
    {
        public Uranus() : base("Уран") { }
        public string GetComplicatedMessage()
        {
            return $"Миссия на Уране невыполнима!";
        }
    }
}
