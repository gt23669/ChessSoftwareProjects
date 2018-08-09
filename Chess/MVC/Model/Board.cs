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
            for (int i = 0; i < gameBoard.Length; i++)
            {
                gameBoard[i] = new string[34];
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    if (j == 33)
                    {
                        gameBoard[i][j] = "\r\n";
                        //Console.Write(gameBoard[i][j] = "\r\n");
                    }
                    else if (j % 4 == 0)
                    {
                        gameBoard[i][j] = "|";
                        //Console.Write(gameBoard[i][j] = "|");
                    }
                    else
                    {
                        gameBoard[i][j] = "_";
                        //Console.Write(gameBoard[i][j] = "_");
                    }

                }

            }



            return gameBoard;
        }

        public string[][] fillBoard(List<Piece> pieces)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                int col;
                int row;
                col = pieces[i].col;
                row = pieces[i].row;

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
                    Console.Write($"{gameBoard[i][j]}");
                }
                Console.WriteLine();

            }



            Console.WriteLine();
        }
    }
}
