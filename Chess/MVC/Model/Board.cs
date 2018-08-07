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
                gameBoard[i] = new string[18];
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    if (j == 17)
                    {
                        Console.Write(gameBoard[i][j] = "\r\n");
                    }
                    else if (j%2 == 0)
                    {
                        Console.Write(gameBoard[i][j] = "|");
                    }
                    else
                    {
                        Console.Write(gameBoard[i][j] = "_");
                    }
                   
                }

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

        public string[][] printBoard(List<Piece> pieces, string[][] newBoard)
        {

            for (int i = 0; i < pieces.Count; i++)
            {
                int x = 0;
                int y = 0;
                //x = pieces[i].
            }
            return newBoard;
        }
    }
}
