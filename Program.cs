namespace ConsoleApp01Projet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a valid path where the data.json file is located.");
                return;
            }

            string jsonFilePath = args[0];

            Campus.Initialize(jsonFilePath);

            Menu menu = new Menu1();

            while (Campus.ShouldNotClose())
            {
                menu.Render();

                int userOptionChoice = ConsoleI.AskUserOption();

                menu = menu.ManageOptions(userOptionChoice);
            }

            Logger.Write("Application terminated successfully.");
        }
    }
    
}
