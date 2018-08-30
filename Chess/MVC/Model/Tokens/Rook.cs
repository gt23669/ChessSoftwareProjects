using System;
using System.Collections.Generic;

namespace Chess.MVC.Model.Tokens
{
    class Rook : Piece
    {
        public Rook(char color, int col, int row)
        {
            name = "Rook";
            ID = "R";
            base.color = color;
            base.col = col;
            base.row = row;
            moves = new List<Move>();
        }
        public override string ToString()
        {
            return ID;
        }
        public override bool CheckValidMove(Piece[][] gameBoard, List<Piece> gameTokens, int nextRow, int nextCol, bool message)
        {
            bool valid = false;
            if (nextRow > 7 || nextCol > 7 || nextRow < 0 || nextCol < 0)
            {
                if (message)
                {
                    Console.WriteLine("Move is outside of the bounds of the board");

                }
                return false;
            }
            if (gameBoard[row][col] == gameBoard[nextRow][nextCol])
            {
                if (message)
                {

                    Console.WriteLine("You didnt move anywhere");
                }
                return false;
            }
            if (gameBoard[row][col] == null)
            {
                if (message)
                {

                    Console.WriteLine($"There is no piece to move");
                }
                return false;
            }

            bool exit = false;
            int x = 1;
            int i = 1;
            bool north;
            bool south;
            bool east;
            bool west;
            do
            {
                north = row - x == nextRow && col == nextCol;
                south = row + x == nextRow && col == nextCol;
                east = row == nextRow && col + x == nextCol;
                west = row == nextRow && col - x == nextCol;
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
                                        if (message)
                                        {

                                            Console.WriteLine("You can not move to a space occupied by the same color");
                                        }
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
                                    if (message)
                                    {

                                        Console.WriteLine("This is not a valid move");
                                    }
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
                                        if (message)
                                        {

                                            Console.WriteLine("You can not move to a space occupied by the same color");
                                        }
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
                                    if (message)
                                    {

                                        Console.WriteLine("This is not a valid move");
                                    }
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
                                        if (message)
                                        {

                                            Console.WriteLine("You can not move to a space occupied by the same color");
                                        }
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
                                    if (message)
                                    {

                                        Console.WriteLine("This is not a valid move");
                                    }
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
                                        if (message)
                                        {

                                            Console.WriteLine("You can not move to a space occupied by the same color");
                                        }
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
                                    if (message)
                                    {

                                        Console.WriteLine("This is not a valid move");
                                    }
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
                else
                {
                    if (x < 7)
                    {
                        x++;
                    }
                    else
                    {
                        if (message)
                        {

                            Console.WriteLine("This is not a valid move");
                        }
                        valid = false;
                        exit = true;
                    }
                }
            } while (!exit);


            return valid;
        }


    }
}
