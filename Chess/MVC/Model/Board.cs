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

        public void GenerateBoard()
        {
            for (int i = 0; i < gameBoard.Length; i++)
            {
                gameBoard[i] = new string[18];
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    if (j == 17)
                    {
                        gameBoard[i][j] = "\r\n";
                    }
                    else if (j%2 == 0)
                    {
                        gameBoard[i][j] = "|";
                    }
                    else
                    {
                        gameBoard[i][j] = "_";
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
        }
    }
}
