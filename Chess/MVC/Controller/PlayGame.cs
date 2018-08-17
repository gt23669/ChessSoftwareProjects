using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MVC.Model;
using CSC160_ConsoleMenu;

namespace Chess.MVC.Controller
{
    class PlayGame
    {
        static Person player1 = new Player1();
        static Person player2 = new Player2();
        static string[] playerMovments;

        public static void playGame(string[] args)
        {

            int choiceFile;
            string file;
            Console.WriteLine("Which file will you use?");
            choiceFile = CIO.PromptForMenuSelection(args, false);
            file = args[choiceFile - 1];
            
            bool exit = false;
            do
            {
                if (player1.isInCheckMate)
                {
                    Console.WriteLine("Sorry player1, you have lost!");
                    exit = true;
                }
                else if (player2.isInCheckMate)
                {
                    Console.WriteLine("Sorry player2, you have lost!");
                    exit = true;
                }
                else
                {
                    if (player1.isInCheck)
                    {
                        Console.WriteLine("Player1, protect your king! You are in check!");
                    }
                    else if (player2.isInCheck)
                    {
                        Console.WriteLine("Player2, protect your king! You are in check!");
                    }
                    else
                    {
                        if (player1.isTurn)
                        {
                            Console.WriteLine("Player1, it is your turn!");
                        }
                        else
                        {
                            Console.WriteLine("Player2, it is your turn!");
                        }

                    }

                }


                string[] options = new string[] { "Move" };
                int choice = CIO.PromptForMenuSelection(options, false);
                switch (choice)
                {
                    case 1:
                        GameSetup.move(playerMovments);
                        break;
                }
            } while (!exit);
        }



        public static void turnFlip(int i)
        {
            if (player1.isTurn)
            {
                player1.moveNumber = i + 2;
            }
            else
            {
                player2.moveNumber = i + 2;
            }
            player1.isTurn = !player1.isTurn;
            player2.isTurn = !player2.isTurn;
        }
        public static int MoveNumber()
        {
            if (player1.isTurn)
            {
                return player1.moveNumber;
            }
            else
            {
                return player2.moveNumber;
            }
        }
    }
}
