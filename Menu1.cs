using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    internal class Menu1 : Menu
    {
        protected override string Title => "=========Main Menu==========";
        public Campus Campus { get; set; }
        protected override List<string> MenuOptions => new List<string>() { "Menu Eleves", "Menu Cours", "Exit" };
        public Menu1() {
            Campus = new Campus(); 
        }
        public override Menu ManageOptions(int option)
        {
            switch (option)
            {
                case 1:
                    Logger.Write($"[{Title}] - Select Menu Eleves");
                    return new MenuEleve(Campus);
                case 2:
                    Logger.Write($"[{Title}] - Select Menu Cours");
                    return new MenuCours(Campus);
                case 3:
                    Logger.Write($"[{Title}] - Select Exit");
                    Campus.IsExiting = true;
                    return this;
                default:
                    Logger.Write($"[{Title}] - Invalid option, try again.");
                    return this;
            }
        }
    }
}
