using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        static Piece[][] gameBoard = GameSetup.getGameBoard();

        public static void playGame(string[] allArgs)
        {
            List<string> args = new List<string>();

            for (int i = 0; i < allArgs.Length; i++)
            {
                if (allArgs[i].Contains("Player"))
                {
                    args.Add(allArgs[i]);
                }
            }

            int choiceFile;
            string file;

            Console.WriteLine($"Player1, which file will you use?");
            choiceFile = CIO.PromptForMenuSelection(args, false);
            file = args[choiceFile - 1];
            string[] temp = readPlayerMoves(file);
            player1.moves = temp.ToList();
            Console.WriteLine($"Player2, which file will you use?");
            choiceFile = CIO.PromptForMenuSelection(args, false);
            file = args[choiceFile - 1];
            temp = readPlayerMoves(file);
            player2.moves = temp.ToList();


            int index = 0;
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
                            index = player1.moveIndex;
                            playerMovments = player1.moves.ToArray();
                        }
                        else
                        {
                            Console.WriteLine("Player2, it is your turn!");
                            index = player2.moveIndex;
                            playerMovments = player2.moves.ToArray();
                        }

                    }

                    movePiece(index);

                }



            } while (!exit);
        }



        private static void movePiece(int index)
        {
            bool exit = false;
            do
            {
                GameSetup.printBoard(gameBoard);
                Console.WriteLine();
                int currentCol = GameSetup.convertX(playerMovments[index][0]);
                int.TryParse(playerMovments[index][1].ToString(), out int currentRow);
                int nextCol = GameSetup.convertX(playerMovments[index][2]);
                int.TryParse(playerMovments[index][3].ToString(), out int NextRow);

                if (gameBoard[currentRow][currentCol] != null)
                {
                    Console.WriteLine($"Attempting to move {(player1.isTurn ? player1.name : player2.name)}'s {gameBoard[currentRow][currentCol].name} from col:{currentCol} row:{currentRow} to col:{nextCol} row:{NextRow} ");
                    if (gameBoard[currentRow][currentCol].Check(gameBoard, NextRow, nextCol))
                    {
                        Console.WriteLine($"{(player1.isTurn ? player1.name : player2.name)}'s {gameBoard[currentRow][currentCol].name} from col:{currentCol} row:{currentRow} moved to col:{nextCol} row:{NextRow} ");
                        gameBoard[NextRow][nextCol] = gameBoard[currentRow][currentCol];
                        gameBoard[currentRow][currentCol] = null;
                        gameBoard[NextRow][nextCol].row = NextRow;
                        gameBoard[NextRow][nextCol].col = nextCol;
                        turnFlip(index);
                        exit = true;

                    }

                }
                else
                {
                    Console.WriteLine("There is no piece to move");
                    index++;
                }

            } while (!exit);


            Console.WriteLine();
            GameSetup.printBoard(gameBoard);
            Console.WriteLine();
        }

        public static void turnFlip(int i)
        {
            if (player1.isTurn)
            {
                player1.moveIndex = i + 1;
            }
            else
            {
                player2.moveIndex = i + 1;
            }
            player1.isTurn = !player1.isTurn;
            player2.isTurn = !player2.isTurn;
        }
        public static int MoveNumber()
        {
            if (player1.isTurn)
            {
                return player1.moveIndex;
            }
            else
            {
                return player2.moveIndex;
            }
        }
        private static string[] readPlayerMoves(string file)
        {
            string content = File.ReadAllText(file);
            content = content.ToUpper();

            string[] SplitArray = Regex.Split(content, "[\r\n]+");
            List<string> temp = new List<string>();
            for (int i = 0; i < SplitArray.Length; i++)
            {

                if (SplitArray[i].Length == 11)
                {
                    string x = SplitArray[i].Substring(0, 5);
                    string y = SplitArray[i].Substring(6, 5);
                    string[] doubleString = new string[] { x, y };
                    for (int j = 0; j < 2; j++)
                    {
                        int.TryParse(doubleString[i][1].ToString(), out int temp1);
                        int.TryParse(doubleString[i][4].ToString(), out int temp4);
                        if (doubleString[i][1] < 8 && doubleString[i][4] < 8)
                        {

                            if ((doubleString[j][0] != 'I') && (doubleString[j][3] != 'I'))
                            {
                                temp.Add(doubleString[j]);
                            }
                        }

                    }


                }
                else
                {
                    int.TryParse(SplitArray[i][1].ToString(), out int temp1);
                    int.TryParse(SplitArray[i][4].ToString(), out int temp4);
                    if (temp1 < 8 && temp4 < 8)
                    {

                        if ((SplitArray[i][0] != 'I') && (SplitArray[i][3] != 'I'))
                        {
                            temp.Add(SplitArray[i]);
                        }
                    }

                }
            }

            for (int i = 0; i < temp.Count; i++)
            {
                temp[i] = temp[i].Replace(" ", "");
            }


            SplitArray = temp.ToArray();
            return SplitArray;
        }
    }
}
