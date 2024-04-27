using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    internal class MenuCours : Menu
    {
        protected override string Title => "Menu Cours";
        public Campus Campus1 { get; set; }
        protected override List<string> MenuOptions => new List<string>() { "Afficher la liste des cours", "Creer un cours", "Supprimer un cours", "Main Menu" };
        private void ShowAllCourses()
        {
            ConsoleI.ShowAllCourses();
        }
         public MenuCours(Campus campus)
        {
            Campus1 = campus;
        }
        private void CreateNewCourse()
        {
            string? name = ConsoleI.AskCourseInfo();

            if (Validation.AnyNullOrEmpty(name))
            {
                Logger.Write("[CourseMenu] - Creation of course canceled.");
                return;
            }

            Cours course = new Cours(name);
            Campus.Courses.Add(course);

            Campus.SaveData();

            Logger.Write($"[{Title}] - Created new course");
        }

        private void DeleteCourse()
        {
            int courseId = ConsoleI.AskCourseID();
            Cours? course = Campus.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                Logger.Write($"[{Title}] - Course not found.");
                return;
            }

            Campus.Courses.Remove(course);

            foreach (var student in Campus.Students)
            {
                var gradeToRemove = student.ListeTableaux.FirstOrDefault(g => g.CourseId == courseId);

                if (gradeToRemove != null)
                {
                    student.ListeTableaux.Remove(gradeToRemove);
                }
            }

            Campus.SaveData();

            Logger.Write($"[{Title}] - Deleted course and associated grades");
        }
        public override Menu ManageOptions(int option)
        {
            switch (option)
            {
                case 1:
                    ShowAllCourses();
                    Logger.Write($"[{Title}] - Afficher la liste des cours");
                    return this;
                case 2:
                    CreateNewCourse();
                    Logger.Write($"[{Title}] - Creer un cours");
                    return this;
                case 3:
                    DeleteCourse();
                    Logger.Write($"[{Title}] - Supprimer un cours");
                    return this;
                case 4:
                    Logger.Write($"[{Title}] - Back to Main Menu");
                    return new Menu1();
                default:
                    Logger.Write($"[{Title}] - Invalid option, try again.");
                    return this;
            }
        }
    }
}
