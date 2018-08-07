using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Board
    {

        public string[][] gameBoard = new string[8][];

        public string[][] GenerateBoard()
        {
            //for (int i = 0; i < gameBoard.Length; i++)
            //{
            //    gameBoard[i] = new string[18];
            //    for (int j = 0; j < gameBoard[i].Length; j++)
            //    {
            //        if (j == 17)
            //        {
            //            Console.Write(gameBoard[i][j] = "\r\n");
            //        }
            //        else if (j % 2 == 0)
            //        {
            //            Console.Write(gameBoard[i][j] = "|");
            //        }
            //        else
            //        {
            //            Console.Write(gameBoard[i][j] = "_");
            //        }

            //    }

            //}

            for (int i = 0; i < gameBoard.Length; i++)
            {
<<<<<<< HEAD
                gameBoard[i] = new string[8];

            }
            for (int i = 0; i < gameBoard.Length; i++)
            {

                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    gameBoard[i][j] = "-";
=======
                gameBoard[i] = new string[34];
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    if (j == 33)
                    {
                        Console.Write(gameBoard[i][j] = "\r\n");
                    }
                    else if (j%4 == 0)
                    {
                        Console.Write(gameBoard[i][j] = "|");
                    }
                    else
                    {
                        Console.Write(gameBoard[i][j] = "_");
                    }
                   
>>>>>>> 84c79168cac0c09ed7d6cfd66dd0bcd8a2d8a054
                }
            }

            for (int i = 0; i < gameBoard.Length; i++)
            {
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    //Console.Write(gameBoard[i][j]);
                    Console.Write($"|{gameBoard[i][j]}|");
                }
                Console.WriteLine();
            }
            //for (int i = 0; i < gameBoard.Length; i++)
            //{
            //    for (int j = 0; j < gameBoard.Length; j++)
            //    {
            //        Console.WriteLine(gameBoard[i][j]);
            //    }
            //}
            return gameBoard;
        }

        public string[][] printBoard(List<Piece> pieces)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                int col;
                int row;
                Console.WriteLine(col = pieces[i].col);
                Console.WriteLine(row = pieces[i].row);
                //if (col % 2 == 0)
                //{
                //    col += 1;
                //    gameBoard[row][col] = pieces[i].ID;
                //    printNewBoard(gameBoard);
                //    count++;
                //}
                //else if (col % 2 == 1)
                //{
                //    col += 2;
                //    gameBoard[row][col] = pieces[i].ID;
                //    printNewBoard(gameBoard);
                //    count++;
                //}
                gameBoard[row][col] = pieces[i].ID;
                printNewBoard(gameBoard);






            }
            return gameBoard;
        }
        public void printNewBoard(string[][] gameBoard)
        {



            for (int i = 0; i < gameBoard.Length; i++)
            {
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    Console.Write($"|{gameBoard[i][j]}|");
                }
                Console.WriteLine();
                //Console.WriteLine("-------------------------");
            }



            Console.WriteLine();
        }
    }
}
