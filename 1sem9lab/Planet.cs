using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1sem9lab;

namespace _1sem9lab
{
    internal abstract class Planet
    {
        public string Name { get; }
        public Planet (string name)
        {
            Name = name;
        }
    }
}
