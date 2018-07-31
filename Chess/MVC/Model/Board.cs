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
                gameBoard[i] = new string[8];
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    Console.Write(gameBoard[i][j] = "j");
                }

            }
        }
    }
}
