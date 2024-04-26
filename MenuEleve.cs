using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    public class MenuEleve : Menu
    {
        protected override string Title => "Student Menu";
        protected override List<string> MenuOptions => new List<string>() { "Show List", "Create", "Show Info", "Add Note", "Main Menu" };
        public Campus Campus1 { get; set; }
        public MenuEleve(Campus campus)
        {
            Campus1 = campus;

        }
        private void ShowAllStudents()
        {
            ConsoleI.ShowAllStudents(Campus1);
        }

        private Eleve? GetStudentByID(int id)
        {
            return Campus1.Students.FirstOrDefault(student => student._id == id);
        }

        private void ShowStudentInfo()
        {
            int id = ConsoleI.AskUserID(Campus1);
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

            Campus1.Students.Add(student);
            Campus.SaveData();

            Logger.Write($"[{Title}] - Created new student");
        }



        public override Menu ManageOptions(int option)
        {
            switch (option)
            {
                case 1:
                    ShowAllStudents();
                    Logger.Write($"[{Title}] - Show students list ");
                    return this;
                case 2:
                    CreateNewStudent();
                    return this;
                case 3:
                    ShowStudentInfo();
                    return this;
                case 4:
                    // AddNote();
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
