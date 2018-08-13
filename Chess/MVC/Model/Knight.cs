using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Knight : Piece
    {

        //char color;
        //int xLoc;
        //int row;

        public Knight(char color, int col, int row)
        {
            base.name = "Knight";
            base.ID = "N";
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

            if ((row + 2 == nextRow && col + 1 == nextCol) || (row + 1 == nextRow && col + 2 == nextCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        Console.WriteLine("You can not move there, same color piece occupies the space");
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
                return valid;
            }
            else if ((row - 2 == nextRow && col + 1 == nextCol) || (row - 1 == nextRow && col + 2 == nextCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        Console.WriteLine("You can not move there, same color piece occupies the space");
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
                return valid;
            }
            else if ((row - 1 == nextRow && col - 2 == nextCol) || (row - 2 == nextRow && col - 1 == nextCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        Console.WriteLine("You can not move there, same color piece occupies the space");
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
                return valid;
            }
            else if ((row + 2 == nextRow && col - 1 == nextCol) || (row + 1 == nextRow && col - 2 == nextCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        Console.WriteLine("You can not move there, same color piece occupies the space");
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
                return valid;
            }
            else
            {
                Console.WriteLine("This is not a legal move");
                valid = false;
            }












            return valid;
        }
    }
}
