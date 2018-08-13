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
            bool exit = false;
            do
            {

                if ((row - index == nextRow && col == nextCol) || (row + index == nextRow && col == nextCol))
                {
                    if (gameBoard[nextRow][nextCol] != null)
                    {
                        if (gameBoard[nextRow][nextCol].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same colorS");
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
                        valid = true;
                        exit = true;
                    }
                }
                else if ((row == nextRow && col + index == nextCol) || (row == nextRow && col - index == nextCol))
                {
                    bool temp = false;
                    int c = 1;

                    if (row == nextRow && col + index == nextCol)
                    {
                        do
                        {
                            if (gameBoard[row][col + c] == null)
                            {
                                valid = true;
                                temp = true;
                                exit = true;
                            }
                            else
                            {
                                valid = false;
                                temp = true;
                                exit = true;
                            }
                        } while (!temp);

                    }
                    else
                    {
                        do
                        {
                            if (gameBoard[row][col - c] == null)
                            {
                                if (row == nextRow && col - c == nextCol)
                                {
                                    valid = true;
                                    temp = true;
                                    exit = true;

                                }
                            }
                            else
                            {
                                if (row == nextRow && col - c == nextCol)
                                {
                                    if (gameBoard[nextRow][nextCol].color == this.color)
                                    {
                                        Console.WriteLine("You can not move your piece to a space occupied by the same color");
                                        valid = false;
                                        temp = true;
                                        exit = true;
                                    }
                                    else
                                    {
                                        valid = true;
                                        temp = true;
                                        exit = true;
                                    }
                                }
                                else
                                {
                                    valid = false;
                                    temp = true;
                                    exit = true;
                                    Console.WriteLine("This move is not valid");

                                }
                            }
                            c++;
                        } while (!temp);
                    }
                }
                else if ((row - index == nextRow && col + index == nextCol) || (row + index == nextRow && col + index == nextCol))
                {
                    if (gameBoard[nextRow][nextCol] != null)
                    {
                        if (gameBoard[nextRow][nextCol].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same colorS");
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
                        valid = true;
                        exit = true;
                    }
                }
                else if ((row - index == nextRow && col - index == nextCol) || (row + index == nextRow && col - index == nextCol))
                {
                    if (gameBoard[nextRow][nextCol] != null)
                    {
                        if (gameBoard[nextRow][nextCol].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same colorS");
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
                        valid = true;
                        exit = true;
                    }
                }
                else
                {
                    if (index < 7)
                    {
                        index++;
                    }
                    else
                    {
                        valid = false;
                        exit = true;
                    }
                }

            } while (!exit);

            return valid;
        }
    }
}
