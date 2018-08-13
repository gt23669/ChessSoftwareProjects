using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Rook : Piece
    {
        //char color;
        //int xLoc;
        //int yLoc;

        public Rook(char color, int col, int row)
        {
            base.name = "Rook";
            base.ID = "R";
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
            int x = 1;
            do
            {
                if (row - x == nextRow && col == nextCol)
                {
                    for (int i = 1; i < gameBoard.Length; i++)
                    {
                        if (row - i == nextRow && col == nextCol)
                        {
                            if (gameBoard[row - i][col] == null)
                            {
                                valid = true;
                                exit = true;
                                break;
                            }
                            else
                            {
                                if (gameBoard[row - i][col].color == this.color)
                                {
                                    Console.WriteLine("You can not move to a space occupied by the same color");
                                    valid = false;
                                    exit = true;
                                    break;
                                }
                                else
                                {
                                    valid = true;
                                    exit = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (gameBoard[row - i][col] != null)
                            {
                                Console.WriteLine("This is not a valid move");
                                valid = false;
                                exit = true;
                                break;
                            }

                        }
                    }
                }
                else if (row == nextRow && col + x == nextCol)
                {
                    for (int i = 1; i < gameBoard.Length; i++)
                    {
                        if (row == nextRow && col + i == nextCol)
                        {
                            if (gameBoard[row][col + i] == null)
                            {
                                valid = true;
                                exit = true;
                                break;
                            }
                            else
                            {
                                if (gameBoard[row][col + i].color == this.color)
                                {
                                    Console.WriteLine("You can not move to a space occupied by the same color");
                                    valid = false;
                                    exit = true;
                                    break;
                                }
                                else
                                {
                                    valid = true;
                                    exit = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (gameBoard[row][col + i] != null)
                            {
                                Console.WriteLine("This is not a valid move");
                                valid = false;
                                exit = true;
                                break;
                            }

                        }
                    }
                }
                else if (row + x == nextRow && col == nextCol)
                {
                    for (int i = 1; i < gameBoard.Length; i++)
                    {
                        if (row + i == nextRow && col == nextCol)
                        {
                            if (gameBoard[row + i][col] == null)
                            {
                                valid = true;
                                exit = true;
                                break;
                            }
                            else
                            {
                                if (gameBoard[row + i][col].color == this.color)
                                {
                                    Console.WriteLine("You can not move to a space occupied by the same color");
                                    valid = false;
                                    exit = true;
                                    break;
                                }
                                else
                                {
                                    valid = true;
                                    exit = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (gameBoard[row + i][col] != null)
                            {
                                Console.WriteLine("This is not a valid move");
                                valid = false;
                                exit = true;
                                break;
                            }

                        }
                    }
                }
                else if (row == nextRow && col - x == nextCol)
                {
                    for (int i = 1; i < gameBoard.Length; i++)
                    {
                        if (row == nextRow && col - i == nextCol)
                        {
                            if (gameBoard[row][col - i] == null)
                            {
                                valid = true;
                                exit = true;
                                break;
                            }
                            else
                            {
                                if (gameBoard[row][col - i].color == this.color)
                                {
                                    Console.WriteLine("You can not move to a space occupied by the same color");
                                    valid = false;
                                    exit = true;
                                    break;
                                }
                                else
                                {
                                    valid = true;
                                    exit = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (gameBoard[row][col - i] != null)
                            {
                                Console.WriteLine("This is not a valid move");
                                valid = false;
                                exit = true;
                                break;
                            }

                        }
                    }
                }
                else
                {
                    if (x == 7)
                    {
                        Console.WriteLine("This move is not legal");
                        valid = false;
                        exit = true;
                    }
                    else
                    {
                        x++;

                    }
                }
            } while (!exit);


            return valid;
        }
    }
}
