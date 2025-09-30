using _1sem6lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1sem6lab
{
    internal class Traineeship
    {
        public List<Student> Candidates { get; set; }
        public List<Department> Departments { get; set; }
        public Traineeship()
        {
            Candidates = new List<Student>();
            Departments = new List<Department>();
        }
    }
}
