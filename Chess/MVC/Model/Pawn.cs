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

        bool firstMove = false;
        public Pawn(char color, int col, int row)
        {
            base.name = "Pawn";
            base.ID = "P";
            base.color = color;
            base.col = col;
            base.row = row;
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

                if ((row - 2 == nextRow && col == nextCol) && !firstMove)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (gameBoard[row - i][col] == null)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("You can not move past this piece");
                            valid = false;
                        }
                    }
                }
                else if (row - 1 == nextRow && col == nextCol)
                {
                    if (gameBoard[row - 1][col] == null)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("You can not move past this piece");
                        valid = false;
                    }
                }
                else if (row - 1 == nextRow && col - 1 == nextCol)
                {
                    if (gameBoard[row - 1][col - 1].color != color)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("You can not take the same color piece");
                        valid = false;
                    }
                }
                else if (row - 1 == nextRow && col + 1 == nextCol)
                {
                    if (gameBoard[row - 1][col + 1].color != color)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("You can not take the same color piece");
                        valid = false;
                    }
                }
                else
                {
                    Console.WriteLine("This move is not valid");
                    valid = false;
                }

            }
            else
            {
                if ((row + 2 == nextRow && col == nextCol) && !firstMove)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (gameBoard[row - i][col] == null)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("You can not move past this piece");
                            valid = false;
                        }
                    }
                }
                else if (row + 1 == nextRow && col == nextCol)
                {
                    if (gameBoard[row - 1][col] == null)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("You can not move past this piece");
                        valid = false;
                    }
                }
                else if (row + 1 == nextRow && col + 1 == nextCol)
                {
                    if (gameBoard[row - 1][col - 1].color != color)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("You can not take the same color piece");
                        valid = false;
                    }
                }
                else if (row + 1 == nextRow && col - 1 == nextCol)
                {
                    if (gameBoard[row - 1][col + 1].color != color)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("You can not take the same color piece");
                        valid = false;
                    }
                }
                else
                {
                    Console.WriteLine("This move is not valid");
                    valid = false;
                }
            }
            if (valid == true && firstMove == false)
            {
                firstMove = true;
            }
            return valid;
        }

        public override string ToString()
        {
            return ID;
        }
    }
}
