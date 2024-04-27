using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp01Projet.Models;

namespace ConsoleApp01Projet
{
    public class Campus
    {
        private static List<Eleve> _students = new List<Eleve>();
        private static List<Cours> _courses = new List<Cours>();
        private static List<Tableau> _tableau = new List<Tableau>();


        public static string FilePath { get; private set; }

        public static List<Eleve> Students { get { return _students; } set { } }
        public static List<Cours> Courses { get { return _courses; } set { } }
        public static List<Tableau> Tableau { get { return _tableau; } set { } }

        public static bool IsExiting { get; set; } = false;
        public static bool ShouldNotClose() => !IsExiting;

        public Campus()
        {
            Students = new List<Eleve>();
        }
        public static void Initialize(string jsonFilePath)
        {
            FilePath = jsonFilePath;
            Logger.InitializeLogger(jsonFilePath);
            LoadData();
        }

        private static void LoadData()
        {
            var data = JSON.LoadData();
            if (data != null)
            {
                _students = data.Students;
                _courses = data.Courses;
                _tableau = data.Tableau;

                Logger.Write("Data loaded successfully.");
            }
            else
            {
                Logger.Write("No data found.");
            }
        }

        public static void SaveData()
        {
            var data = new DataModel
            {
                Students = _students,
                Courses = _courses,
                Tableau = _tableau
            };

            JSON.SaveData(data);

            Logger.Write("Data saved successfully");
        }
    }
}
