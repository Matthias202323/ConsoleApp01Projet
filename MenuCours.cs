using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    internal class MenuCours : Menu
    {
        protected override string Title => "Course Menu";

        protected override List<string> MenuOptions => new List<string>() { "Show List", "Create", "Delete", "Main Menu" };

        public override Menu ManageOptions(int option)
        {
            switch (option)
            {
                case 1:
                    Logger.Write($"[{Title}] - Show courses list");
                    return this;
                case 2:
                    Logger.Write($"[{Title}] - Create new course");
                    return this;
                case 3:
                    Logger.Write($"[{Title}] - Delete new course");
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
