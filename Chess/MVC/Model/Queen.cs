using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Queen : Piece
    {
        //char color;
        //int xLoc;
        //int yLoc;

        public Queen(char color, int col, int row)
        {
            base.name = "Queen";
            base.ID = "Q";
            base.color = color;
            base.col = col;
            base.row = row;
            base.availableMoves = new List<int>();
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
            int i = 1;
            bool exit;
            bool north;
            bool northEast;
            bool northWest;
            bool east;
            bool south;
            bool southEast;
            bool southWest;
            bool west;
            do
            {
                exit = false;
                north = row - index == nextRow && col == nextCol;
                northEast = row - index == nextRow && col + index == nextCol;
                northWest = row - index == nextRow && col - index == nextCol;
                east = row == nextRow && col + index == nextCol;
                south = row + index == nextRow && col == nextCol;
                southEast = row + index == nextRow && col + index == nextCol;
                southWest = row + index == nextRow && col - index == nextCol;
                west = row == nextRow && col - index == nextCol;

                if ((north) || (south))
                {
                    if (north)
                    {
                        do
                        {
                            if (gameBoard[row - i][col] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                if (row - i == nextRow && col == nextCol)
                                {
                                    if (gameBoard[row - i][col].color == this.color)
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
                                    Console.WriteLine("This is not a valid move");
                                    valid = false;
                                    exit = true;
                                }
                            }
                            if (row - i == nextRow && col == nextCol)
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
                            if (gameBoard[row + i][col] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                if (row + i == nextRow && col == nextCol)
                                {
                                    if (gameBoard[row + i][col].color == this.color)
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
                                    Console.WriteLine("This is not a valid move");
                                    valid = false;
                                    exit = true;
                                }
                            }
                            if (row + i == nextRow && col == nextCol)
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
                else if ((east) || (west))
                {
                    if (east)
                    {
                        do
                        {
                            if (gameBoard[row][col + i] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                if (row == nextRow && col + i == nextCol)
                                {
                                    if (gameBoard[row][col + i].color == this.color)
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
                                    Console.WriteLine("This is not a valid move");
                                    valid = false;
                                    exit = true;
                                }
                            }
                            if (row == nextRow && col + i == nextCol)
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
                            if (gameBoard[row][col - i] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                if (row == nextRow && col - i == nextCol)
                                {
                                    if (gameBoard[row][col - i].color == this.color)
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
                                    Console.WriteLine("This is not a valid move");
                                    valid = false;
                                    exit = true;
                                }
                            }
                            if (row == nextRow && col - i == nextCol)
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
                                    if (gameBoard[row - i][col + i].color == this.color)
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
                                    Console.WriteLine("This is not a valid move");
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
                                    if (gameBoard[row + i][col + i].color == this.color)
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
                                    Console.WriteLine("This is not a valid move");
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
                else if ((northWest) || (southWest))
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
                                    if (gameBoard[row - i][col - i].color == this.color)
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
                                    Console.WriteLine("This is not a valid move");
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
                                    if (gameBoard[row + i][col - i].color == this.color)
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
                                    Console.WriteLine("This is not a valid move");
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
                if (index < 8)
                {
                    index++;
                }
                else
                {
                    Console.WriteLine("This move is not valid");
                    exit = true;
                    valid = false;
                }

            } while (!exit);

            return valid;
        }
    }
}
