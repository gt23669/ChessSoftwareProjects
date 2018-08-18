using CSC160_ConsoleMenu;
using System;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC160_ConsoleMenu;

namespace Chess.MVC.Controller
{
    class Game
    {
        public static void PreGame(string[] args)
        {
            string[] options = new string[] { "Setup Game", "PlayGame", "Test" };
            int choiceOption;

            bool exit = false;
            do
            {
                choiceOption = CIO.PromptForMenuSelection(options, true);

                switch (choiceOption)
                {
                    case 1:
                        GameSetup.SetupGame(args);
                        break;
                    case 2:
                        PlayGame.playGame(args);
                        break;
                    case 3:
                        GameSetup.moveTest(args);
                        break;
                    case 0:
                        exit = true;
                        break;
                }
            } while (!exit);
        }
    }
}
