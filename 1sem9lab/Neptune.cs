using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    class Neptune : Planet, ITooComplicated
    {
        public Neptune() : base("Нептун") { }
        public string GetComplicatedMessage()
        {
            return "Миссия на Нептуне невыполнима!";
        }
    }
}
