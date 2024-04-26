using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    internal class ConsoleI
    {
        public Campus campus { get; set; }
        public ConsoleI()
        {
            campus = new Campus();
        }
        /// <summary>
        /// Prompts the user to input a numerical choice.
        /// </summary>
        /// <returns>The user input choice as an integer.</returns>
        public static int AskUserOption()
        {
            Console.Write("Choose an option: ");

            int input = -1;
            while (!int.TryParse(Console.ReadLine(), out input))
                Console.Write("Choose an option: ");

            Console.Clear();

            return input;
        }


        /// <summary>
        /// Output the main menu.
        /// </summary>
        public static void ShowMainMenu(string title, List<string> options)
        {
            Console.WriteLine($"{title} :");

            for (int i = 0; i < options.Count; i++)
                Console.WriteLine($"{i + 1} - {options[i]}");
        }


        /// <summary>
        /// Output a list of students.
        /// </summary>
        /// <param name="students">list of student.</param>
        public static void ShowAllStudents(Campus campus)
        {
            Console.WriteLine("List of Students:");
            foreach (var student in campus.Students)
            {
                Console.WriteLine($"\n\tStudent:\n " +
                    $"\t\tID : {student._id}\n" +
                    $"\t\tName : {student._firstname} {student._lastname}\n" +
                    $"\t\tBirthday : {student._birthdate}");
            }
        }


        /// <summary>
        /// Asks for student info and returns it as a tuple.
        /// </summary>
        /// <returns>
        /// A tuple containing three strings:
        /// - firstname: The student's first name.
        /// - lastname: The student's last name.
        /// - birthday: The student's birthday in the format "MM/DD/YYYY".
        /// </returns>
        public static (string? firstname, string? lastname, string? birthday) AskStudentInfo()
        {
            string? firstName = null;
            string? lastName = null;
            string? birthday = null; ;
            bool isAnyFieldEmpty, doNamesContainDigits, isBirthdayInvalid;

            do
            {
                Console.WriteLine("\n\nEnter student details: [type exit to cancel]");
                Console.Write("Firstname: ");
                firstName = Console.ReadLine();

                if (firstName == "exit")
                    break;

                Console.Write("Lastname: ");
                lastName = Console.ReadLine();
                if (lastName == "exit")
                    break;


                Console.Write("Birthday (Format: DD/MM/YYYY): ");
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

        /// <summary>
        /// Prompts the user to input a numerical choice.
        /// </summary>
        /// <returns>The user input choice as an integer.</returns>
        public static int AskUserID(Campus campus)
        {
            Console.WriteLine("Student List:");
            for (int i = 0; i < campus.Students.Count; i++)
            {
                Eleve? student = campus.Students[i];
                Console.WriteLine($"ID: {student._id}, Name: {student._firstname} {student._lastname}");
            }

            int id;
            while (true)
            {
                Console.Write("Enter student ID: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    // Check if the entered ID exists
                    if (!campus.Students.Any(student => student._id == id))
                        Console.WriteLine("Invalid student ID. Please enter a valid student ID.");
                    else break;
                }
                else Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }

            Console.Clear();

            return id;
        }

        /// <summary>
        /// Output the student data.
        /// </summary>
        /// <param name="student">The Student to show.</param>
        public static void ShowUserData(Eleve student)
        {
            Console.WriteLine($"\n\tStudent:\n " +
                $"\t\tID : {student._id}\n" +
                $"\t\tFirstname : {student._firstname}\n" +
                $"\t\tLastname : {student._lastname}\n" +
                $"\t\tBirthday : {student._birthdate}");


        }

        /// <summary>
        /// Prompts the user to enter the ID of a course.
        /// </summary>
        /// <returns>The ID of the course entered by the user.</returns>
        public static int AskCourseID()
        {
            Console.WriteLine("Course List:");
            foreach (var course in Campus.Courses)
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}");

            int id;
            while (true)
            {
                Console.Write("Enter course ID: ");
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

        /// <summary>
        /// Prompts the user to enter a note out of 20.
        /// </summary>
        /// <returns>The note entered by the user, which should be between 0 and 20.</returns>
        public static int AskNote()
        {
            Console.Write("Enter note (out of 20): ");
            int note;
            while (!int.TryParse(Console.ReadLine(), out note) || note < 0 || note > 20)
                Console.Write("Invalid note. Enter note (out of 20): ");

            return note;
        }

        /// <summary>
        /// Prompts the user to enter a commentary (optional).
        /// </summary>
        /// <returns>The commentary entered by the user.</returns>
        public static string AskCommentary()
        {
            Console.Write("Enter commentary (optional): ");
            return Console.ReadLine();
        }



        public static void ShowAllCourses()
        {
            Console.WriteLine("Course List:");
            foreach (var course in Campus.Courses)
            {
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}");
            }
        }

        public static string? AskCourseInfo()
        {
            string? name;

            do
            {
                Console.WriteLine("\n\nEnter course details: [type exit to cancel]");
                Console.Write("Name: ");
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
