using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet.Models
{
    internal class DataModel
    {
        public List<Eleve> Students { get; set; }
        public List<Cours> Courses { get; set; }

        public List<Tableau> Tableau { get; set; }
    }
}
