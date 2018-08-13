using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class King : Piece
    {

        //char color;
        //int xLoc;
        //int yLoc;

        public King(char color, int col, int row)
        {
            base.name = "King";
            base.ID = "K";
            base.color = color;
            base.col = col;
            base.row = row;
        }


        public override string ToString()
        {
            return ID;
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

            int index = 1;


            if ((row - index == nextRow && col == nextCol) || row + index == nextRow && col == nextCol)
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        Console.WriteLine("You can not move in a space occupied by the same color");
                        valid = false;
                    }
                    else
                    {
                        valid = true;
                    }
                }
                else
                {
                    valid = true;
                }
            }
            else if ((row == nextRow && col + index == nextCol) || (row == nextRow && col - index == nextCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        Console.WriteLine("You can not move in a space occupied by the same color");
                        valid = false;

                    }
                    else
                    {
                        valid = true;

                    }
                }
                else
                {
                    valid = true;

                }
            }
            else if ((row - index == nextRow && col + index == nextCol) || (row + index == nextRow && col + index == nextCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        Console.WriteLine("You can not move in a space occupied by the same color");
                        valid = false;

                    }
                    else
                    {
                        valid = true;

                    }
                }
                else
                {
                    valid = true;

                }
            }
            else if ((row - index == nextRow && col - index == nextCol) || (row + index == nextRow && col - index == nextCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        Console.WriteLine("You can not move in a space occupied by the same color");
                        valid = false;

                    }
                    else
                    {
                        valid = true;

                    }
                }
                else
                {
                    valid = true;

                }
            }
            else
            {
                Console.WriteLine("This move is not legal");
                valid = false;

            }









            return valid;
        }
    }
}
