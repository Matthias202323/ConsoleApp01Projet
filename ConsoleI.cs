using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    internal class ConsoleI
    {
        public static Campus campus { get; set; }
        public ConsoleI()
        {
            campus = new Campus();
        }
       
        public static int AskUserOption()
        {
            Console.Write("Choose an option: ");

            int input = -1;
            while (!int.TryParse(Console.ReadLine(), out input))
                Console.Write("Choose an option: ");

            Console.Clear();

            return input;
        }


        
        public static void ShowMainMenu(string title, List<string> options)
        {
            Console.WriteLine($"{title} :");

            for (int i = 0; i < options.Count; i++)
                Console.WriteLine($"{i + 1} - {options[i]}");
        }


       
        public static void ShowAllStudents()
        {

            Console.WriteLine("========Liste des Eleves:========");

            foreach (var student in Campus.Students)
            {
                Console.WriteLine($"\n\tEleve:\n " +
                    $"\t\tID : {student._id}\n" +
                    $"\t\tNom : {student._firstname} {student._lastname}\n" +
                    $"\t\tDate de naissance : {student._birthdate}");
                Console.WriteLine();
            }
        }


       
        public static (string? firstname, string? lastname, string? birthday) AskStudentInfo()
        {
            string? firstName = null;
            string? lastName = null;
            string? birthday = null; ;
            bool isAnyFieldEmpty, doNamesContainDigits, isBirthdayInvalid;

            do
            {
                Console.WriteLine("\n\nEntrer les details: [type exit to cancel]");
                Console.Write("Prenom: ");
                firstName = Console.ReadLine();

                if (firstName == "exit")
                    break;

                Console.Write("Nom: ");
                lastName = Console.ReadLine();
                if (lastName == "exit")
                    break;


                Console.Write("Date de naissance (Format: DD/MM/YYYY): ");
                birthday = Console.ReadLine();
                if (birthday == "exit")
                    break;

                isAnyFieldEmpty = Validation.AnyNullOrEmpty(firstName, lastName, birthday);
                doNamesContainDigits = Validation.ContainsDigits(firstName, lastName);
                isBirthdayInvalid = !Validation.IsValidDate(birthday);



                if (isAnyFieldEmpty)
                    Console.WriteLine("No fields can be empty.");

                if (doNamesContainDigits)
                    Console.WriteLine("Names should not contain digits.");

                if (isBirthdayInvalid)
                    Console.WriteLine("Birthday must be in the correct format (DD/MM/YYYY) and a valid date.");

            } while (isAnyFieldEmpty || doNamesContainDigits || isBirthdayInvalid);

            Console.Clear();

            return (firstName, lastName, birthday);
        }

       
        public static int AskUserID()
        {
            Console.WriteLine("Liste des eleves:");
            for (int i = 0; i < Campus.Students.Count; i++)
            {
                Eleve? student = Campus.Students[i];
                Console.WriteLine($"ID: {student._id}, Nom: {student._firstname} {student._lastname}");
            }

            int id;
            while (true)
            {
                Console.Write("Enter eleve ID: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    // Check if the entered ID exists
                    if (!Campus.Students.Any(student => student._id == id))
                        Console.WriteLine("Invalid student ID. Please enter a valid student ID.");
                    else break;
                }
                else Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }

            Console.Clear();

            return id;
        }

        
        public static void ShowUserData(Eleve student)
        {
            Console.WriteLine($"\n\tEleve:\n " +
                $"\t\tID : {student._id}\n" +
                $"\t\tPrenom : {student._firstname}\n" +
                $"\t\tNom : {student._lastname}\n" +
                $"\t\tDate de naissance : {student._birthdate}");
            Console.WriteLine();
            Console.WriteLine("\tRésultats scolaires:");

            double noteAverage = 0;
            foreach (var tableau in student.ListeTableaux)
            {
                string comment = tableau.Commentary.Length > 0 ? "Appréciation : " + tableau.Commentary : "";
                var courseName = Campus.Courses.Find(c => c.Id == tableau.CourseId)?.Name;

                noteAverage += tableau.Note;

                Console.WriteLine($"\t\tCours: {courseName ?? "Unknown"}, \n\t\t\tNote : {tableau.Note}/20, \n\t\t\t{comment}");

                Console.WriteLine();
            }

            noteAverage /= student.ListeTableaux.Count;

            Console.WriteLine($"\t\tMoyenne : {noteAverage}/20");
            Console.WriteLine() ;
        }

        
        public static int AskCourseID()
        {
            Console.WriteLine("Lste des cours:");
            foreach (var course in Campus.Courses)
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}");

            int id;
            while (true)
            {
                Console.Write("ID cours: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    // Check if the entered ID exists
                    if (Campus.Courses.Any(course => course.Id == id))
                        break;
                    else Console.WriteLine("Invalid course ID. Please enter a valid course ID.");
                }
                else Console.WriteLine("Invalid input. Please enter a valid course ID.");
            }

            return id;
        }

        
        public static int AskNote()
        {
            Console.Write("Note (sur 20): ");
            int note;
            while (!int.TryParse(Console.ReadLine(), out note) || note < 0 || note > 20)
                Console.Write("Invalid note. Enter note (out of 20): ");

            return note;
        }

       
        public static string AskCommentary()
        {
            Console.Write("Entrer appréciation (optional): ");
            return Console.ReadLine();
        }



        public static void ShowAllCourses()
        {
            Console.WriteLine("=========Liste des cours:===========");
            foreach (var course in Campus.Courses)
            {
                Console.WriteLine($"ID: {course.Id}, Intitulé: {course.Name}");
            }
        }

        public static string? AskCourseInfo()
        {
            string? name;

            do
            {
                Console.WriteLine("\n\nEntrer les details du cours: [type exit to cancel]");
                Console.Write("Intitule: ");
                name = Console.ReadLine();

                if (name == "exit")
                    break;

                if (string.IsNullOrWhiteSpace(name))
                    Console.WriteLine("name cannot be empty.");

            } while (string.IsNullOrWhiteSpace(name));

            Console.Clear();

            return name;
        }
    }
}
