using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Bishop : Piece
    {
        //char color;
        //int xLoc;
        //int yLoc;

        public Bishop(char color, int col, int row)
        {
            base.name = "Bishop";
            base.ID = "B";
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

            bool exit = false;
            int index = 1;
            int i = 1;
            bool northWest;
            bool northEast;
            bool southWest;
            bool southEast;
            do
            {
                northWest = row - index == nextRow && col - index == nextCol;
                northEast = row - index == nextRow && col + index == nextCol;
                southWest = row + index == nextRow && col - index == nextCol;
                southEast = row + index == nextRow && col + index == nextCol;
                if ((northWest) || (southWest))
                {
                    if (northWest)
                    {
                        do
                        {

                            if (gameBoard[row - i][col - i] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                if (row - i == nextRow && col - i == nextCol)
                                {
                                    if (gameBoard[nextRow][nextCol].color == this.color)
                                    {
                                        Console.WriteLine("You can not move to a space occupied by the same color");
                                        valid = false;
                                        exit = true;
                                    }
                                    else
                                    {
                                        valid = true;
                                        exit = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This move is not valid");
                                    valid = false;
                                    exit = true;
                                }
                            }
                            if (row - i == nextRow && col - i == nextCol)
                            {
                                exit = true;
                            }
                            else
                            {
                                i++;
                            }

                        } while (!exit);
                    }
                    else
                    {
                        do
                        {

                            if (gameBoard[row + i][col - i] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                if (row + i == nextRow && col - i == nextCol)
                                {
                                    if (gameBoard[nextRow][nextCol].color == this.color)
                                    {
                                        Console.WriteLine("You can not move to a space occupied by the same color");
                                        valid = false;
                                        exit = true;
                                    }
                                    else
                                    {
                                        valid = true;
                                        exit = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This move is not valid");
                                    valid = false;
                                    exit = true;
                                }
                            }
                            if (row + i == nextRow && col - i == nextCol)
                            {
                                exit = true;
                            }
                            else
                            {
                                i++;
                            }

                        } while (!exit);
                    }
                }
                else if ((northEast) || (southEast))
                {


                    if (northEast)
                    {
                        do
                        {

                            if (gameBoard[row - i][col + i] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                if (row - i == nextRow && col + i == nextCol)
                                {
                                    if (gameBoard[nextRow][nextCol].color == this.color)
                                    {
                                        Console.WriteLine("You can not move to a space occupied by the same color");
                                        valid = false;
                                        exit = true;
                                    }
                                    else
                                    {
                                        valid = true;
                                        exit = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This move is not valid");
                                    valid = false;
                                    exit = true;
                                }
                            }
                            if (row - i == nextRow && col + i == nextCol)
                            {
                                exit = true;
                            }
                            else
                            {
                                i++;
                            }

                        } while (!exit);
                    }
                    else
                    {
                        do
                        {

                            if (gameBoard[row + i][col + i] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                if (row + i == nextRow && col + i == nextCol)
                                {
                                    if (gameBoard[nextRow][nextCol].color == this.color)
                                    {
                                        Console.WriteLine("You can not move to a space occupied by the same color");
                                        valid = false;
                                        exit = true;
                                    }
                                    else
                                    {
                                        valid = true;
                                        exit = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This move is not valid");
                                    valid = false;
                                    exit = true;
                                }
                            }
                            if (row + i == nextRow && col + i == nextCol)
                            {
                                exit = true;
                            }
                            else
                            {
                                i++;
                            }

                        } while (!exit);
                    }
                }

                if (index < 7)
                {
                    index++;
                }
                else
                {
                    Console.WriteLine("This move is not legal");
                    valid = false;
                    exit = true;
                }
            } while (!exit);
            return valid;

        }
    }
}
