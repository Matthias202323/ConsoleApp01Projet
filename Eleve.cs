using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    public class Eleve
    {
        public string _firstname { get; init; }
        public string _lastname { get; init; }
        public string _birthdate { get; init; }
        
        public int _id { get; }
        private static int _nextId = 1;
        public List<Tableau>? ListeTableaux { get; set; }
       
        




        public Eleve(string firstname, string lastname, string birthday)
        {

            _id = _nextId++;
            _birthdate = birthday;
            _firstname = firstname;
            _lastname = lastname;
            ListeTableaux = new List<Tableau>();
            

        }
        
        public void AddGrade(Tableau table)
        {
            ListeTableaux.Add(table);
        }
    }
}
