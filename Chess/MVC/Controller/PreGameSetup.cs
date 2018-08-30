using CSC160_ConsoleMenu;

namespace Chess.MVC.Controller
{
    class PreGameSetup
    {
        public static void menu(string[] args)
        {

            string[] options = new string[] { "PlayGame", "Test" };
            bool exit = false;

            do
            {
                int choice = CIO.PromptForMenuSelection(options, true);

                switch (choice)
                {
                    case 1:
                        Game.gameSetup(args);
                        break;
                    case 2:
                        break;
                    case 0:
                        exit = true;
                        break;
                }
            } while (!exit);
        }
    }
}
