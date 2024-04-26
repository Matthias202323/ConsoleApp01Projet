using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    public abstract class Menu
    {
        protected abstract string Title { get; }
        protected abstract List<string> MenuOptions { get; }


        public void Render()
        {
            ConsoleI.ShowMainMenu(Title, MenuOptions);
        }

        public abstract Menu ManageOptions(int option);
    }
}
