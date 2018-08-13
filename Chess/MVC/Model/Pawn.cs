using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Pawn : Piece
    {

        //char color;
        //int xLoc;
        //int yLoc;

        public Pawn(char color, int col, int row)
        {
            base.name = "Pawn";
            base.ID = "P";
            base.color = color;
            base.col = col;
            base.row = row;
            bool firstMove = false;
        }

        public override bool Check(Piece[][] gameBoard, int nextRow, int nextCol)
        {
            bool valid = false;
            if (nextRow > 7 || nextCol > 7)
            {
                Console.WriteLine("Move is outside of the bounds of the board");
                return false;
            }
            if (gameBoard[row][col] == gameBoard[nextRow][nextCol])
            {
                Console.WriteLine("You didnt move anywhere");
                return false;
            }
            if (gameBoard[row][col] == null)
            {
                Console.WriteLine($"There is no piece to move");
                return false;
            }

            if (color == 'L')
            {
                if (row-1 == nextRow)
                {

                }
                if (row-1 == nextRow && col+1 == nextCol)
                {

                }
            }
            else
            {

            }

            return valid;
        }

        public override string ToString()
        {
            return ID;
        }
    }
}
