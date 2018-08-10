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
            if (color == 'D')
            {
                if (nextRow > row)
                {
                    if (gameBoard[row + 1][col] != null)
                    {

                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Pawns can not take other pieces when moving vertically");
                    }

                }
                else
                {
                    Console.WriteLine("Pawns can not move backwards");
                }
            }
            else
            {
                if (nextRow < row)
                {
                    if (gameBoard[row - 1][col] != null)
                    {

                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Pawns can not take other pieces when moving vertically");
                    }
                }
                else
                {
                    Console.WriteLine("Pawns can not move backwards");
                }
            }

            return valid;
        }

        public override string ToString()
        {
            return ID;
        }
    }
}
