using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Board
    {

        public Piece[][] gameBoard = new Piece[8][];

        public Piece[][] GenerateBoard()
        {
            for (int i = 0; i < gameBoard.Length; i++)
            {
                gameBoard[i] = new Piece[8];
                //for (int j = 0; j < gameBoard[i].Length; j++)
                //{
                //    if (j == 33)
                //    {
                //        gameBoard[i][j] = "\r\n";
                //        //Console.Write(gameBoard[i][j] = "\r\n");
                //    }
                //    else if (j % 4 == 0)
                //    {
                //        gameBoard[i][j] = "|";
                //        //Console.Write(gameBoard[i][j] = "|");
                //    }
                //    else
                //    {
                //        gameBoard[i][j] = "_";
                //        //Console.Write(gameBoard[i][j] = "_");
                //    }

                //}

            }



            return gameBoard;
        }

        public Piece[][] fillBoard(List<Piece> pieces)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                int col;
                int row;
                col = pieces[i].col;
                row = pieces[i].row;

                gameBoard[row][col] = pieces[i];
            }
            return gameBoard;
        }
        public void printNewBoard(Piece[][] gameBoard)
        {

            for (int i = 0; i < gameBoard.Length; i++)
            {

                for (int j = 0; j < gameBoard[i].Length; j++)
                {

                    if (gameBoard[i][j] == null)
                    {
                        if (j == 7)
                        {
                            Console.Write("|___|");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write("|___");
                        }
                    }
                    else
                    {
                        if (j == 7)
                        {
                            Console.Write($"|_{gameBoard[i][j].ToString()}_|");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write($"|_{gameBoard[i][j].ToString()}_");
                        }
                    }
                    
                    ////if (j == 33)
                    ////{
                    ////    //gameBoard[i][j] = "\r\n";
                    ////    //Console.Write(gameBoard[i][j] = "\r\n");
                    ////}
                    ////else if (j % 4 == 0)
                    ////{
                    ////    //gameBoard[i][j] = "|";
                    ////    //Console.Write(gameBoard[i][j] = "|");
                    ////}
                    ////else
                    ////{
                    ////    //gameBoard[i][j] = "_";
                    ////    //Console.Write(gameBoard[i][j] = "_");
                    ////}

                }

            }


            //for (int i = 0; i < gameBoard.Length; i++)
            //{
            //    for (int j = 0; j < gameBoard[i].Length; j++)
            //    {
            //        Console.Write($"{gameBoard[i][j].ToString()}");
            //    }
            //    Console.WriteLine();

            //}
            //Console.WriteLine();
        }
    }
}
