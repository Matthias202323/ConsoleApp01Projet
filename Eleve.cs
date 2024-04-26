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
        public Dictionary<string, double> _note { get; set; }
        public int _id { get; }
        private static int _nextId = 1;

        private int _coursnumber;
        




        public Eleve(string firstname, string lastname, string birthday)
        {

            _id = _nextId++;
            _birthdate = birthday;
            _firstname = firstname;
            _lastname = lastname;

            _coursnumber = 0;

        }
        public void SetNote(double note)
        {

            /*_notes.Add(note);*/
        }
        public void SetCommentaire(string commentaire)
        {
            /*_commentaires = commentaire;*/
        }

        public double CalculeMoyenne()
        {
            double result = 0;
            return result;
        }
      
    }
}
