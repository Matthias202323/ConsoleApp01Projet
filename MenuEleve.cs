using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    public class MenuEleve : Menu
    {
        protected override string Title => "=========Menu Eleve=========";
        protected override List<string> MenuOptions => new List<string>() { "Afficher la liste des Eleves", "Creer un eleve", "Informations Eleve", "Ajouter une note", "Main Menu" };
        public Campus Campus1 { get; set; }
        public MenuEleve(Campus campus)
        {
            Campus1 = campus;

        }
        private void ShowAllStudents()
        {
            ConsoleI.ShowAllStudents();
        }

        private Eleve? GetStudentByID(int id)
        {
            return Campus.Students.FirstOrDefault(student => student._id == id);
        }

        private void ShowStudentInfo()
        {
            int id = ConsoleI.AskUserID();
            Eleve? student = GetStudentByID(id);

            if (student == null)
            {
                Logger.Write($"[{Title}] - Student not found.");
                return;
            }

            ConsoleI.ShowUserData(student);
            Logger.Write($"[{Title}] - Show student info");
        }

        private Campus GetCampus1()
        {
            return Campus1;
        }

        private void CreateNewStudent()
        {
            (string? firstname, string? lastname, string? birthday) = ConsoleI.AskStudentInfo();

            if (Validation.AnyNullOrEmpty(firstname, lastname, birthday))
            {
                Logger.Write("[StudentMenu] - Creation of student canceled.");
                return;
            }

            Eleve student = new Eleve(firstname, lastname, birthday);

            Campus.Students.Add(student);
            Campus.SaveData();

            Logger.Write($"[{Title}] - Created new student");
        }

        private void AddNote()
        {
            int studentId = ConsoleI.AskUserID();
            Eleve? student = GetStudentByID(studentId);

            if (student == null)
            {
                Logger.Write($"[{Title}] - Student not found.");
                return;
            }

            int courseId = ConsoleI.AskCourseID();
            int note = ConsoleI.AskNote();
            string commentary = ConsoleI.AskCommentary();

            var existing = student.ListeTableaux.FirstOrDefault(g => g.CourseId == courseId);

            if (existing != null)
            {
                existing.Note = note;
                existing.Commentary = commentary;

                Logger.Write($"[{Title}] - Updated existing table for the course.");
            }
            else
            {
                Tableau newGrade = new Tableau(courseId, note, commentary);
                student.AddGrade(newGrade);

                Logger.Write($"[{Title}] - Added new table to student.");
            }

            Campus.SaveData();
        }

        public override Menu ManageOptions(int option)
        {
            switch (option)
            {
                case 1:
                    ShowAllStudents();
                    Logger.Write($"[{Title}] - Afficher la liste des eleves ");
                    return this;
                case 2:
                    CreateNewStudent();
                    return this;
                case 3:
                    ShowStudentInfo();
                    return this;
                case 4:
                    AddNote();
                    return this;
                case 5:
                    Logger.Write($"[{Title}] - Back to Main Menu");
                    return new Menu1();
                default:
                    Logger.Write($"[{Title}] - Invalid option, try again.");
                    return this;
            }
        }
    }
}
