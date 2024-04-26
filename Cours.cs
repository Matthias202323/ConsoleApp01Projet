using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    public class Cours
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        private static int _nextId = 1;

        public Cours(string name)
        {
            Id = _nextId++;
            Name = name;
        }
    }
}
