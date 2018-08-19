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
            base.availableMoves = new List<int>();
        }

        public override bool Check(Piece[][] gameBoard, int nextRow, int nextCol)
        {
            //check to make sure the pawn is not validating on a straight move when a piece is in front
            bool valid = false;
            if (nextRow > 7 || nextCol > 7 || nextRow < 0 || nextCol < 0)
            {
                //Console.WriteLine("Move is outside of the bounds of the board");
                return false;
            }
            if (gameBoard[row][col] == gameBoard[nextRow][nextCol])
            {
                //Console.WriteLine("You didnt move anywhere");
                return false;
            }
            if (gameBoard[row][col] == null)
            {
                //Console.WriteLine($"There is no piece to move");
                return false;
            }

            bool north = row - 1 == nextRow && col == nextCol;
            bool northEastTake = row - 1 == nextRow && col + 1 == nextCol;
            bool northWestTake = row - 1 == nextRow && col - 1 == nextCol;
            bool northJump = row - 2 == nextRow && col == nextCol;
            bool south = row + 1 == nextRow && col == nextCol;
            bool southEastTake = row + 1 == nextRow && col + 1 == nextCol;
            bool southWestTake = row + 1 == nextRow && col - 1 == nextCol;
            bool southJump = row + 2 == nextRow && col == nextCol;


            if (color == 'L')
            {

                if ((northJump) && firstMove == false)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (gameBoard[row - 1][col] == null && gameBoard[row - 2][col] == null)
                        {

                            valid = true;
                        }
                        else
                        {
                            //Console.WriteLine("You can not move past this piece");
                            valid = false;
                        }
                    }
                }
                else if (north)
                {
                    if (gameBoard[row - 1][col] == null)
                    {

                        valid = true;
                    }
                    else
                    {
                        //Console.WriteLine("You can not move past this piece");
                        valid = false;
                    }
                }
                else if (northWestTake)
                {
                    if (gameBoard[row - 1][col - 1] == null)
                    {
                        valid = false;
                        //Console.WriteLine("There is no piece to take");
                    }
                    else
                    {
                        if (gameBoard[row - 1][col - 1].color != this.color)
                        {

                            valid = true;
                        }
                        else
                        {
                            //Console.WriteLine("You can not take the same color piece");
                            valid = false;
                        }

                    }
                }
                else if (northEastTake)
                {
                    if (gameBoard[row - 1][col + 1] == null)
                    {
                        valid = false;
                        //Console.WriteLine("There is no piece to take");
                    }
                    else
                    {
                        if (gameBoard[row - 1][col + 1].color != color)
                        {

                            valid = true;
                        }
                        else
                        {
                            //Console.WriteLine("You can not take the same color piece");
                            valid = false;
                        }

                    }
                }
                else
                {
                    //Console.WriteLine("This move is not valid");
                    valid = false;
                }

            }
            else
            {
                if ((southJump) && firstMove != false)
                {

                    if (gameBoard[row + 1][col] == null && gameBoard[row + 2][col] == null)
                    {

                        valid = true;
                    }
                    else
                    {
                        //Console.WriteLine("You can not move past this piece");
                        valid = false;
                    }

                }
                else if (south)
                {
                    if (gameBoard[row + 1][col] == null)
                    {

                        valid = true;
                    }
                    else
                    {
                        //Console.WriteLine("You can not move past this piece");
                        valid = false;
                    }
                }
                else if (southEastTake)
                {
                    if (gameBoard[row + 1][col + 1] == null)
                    {
                        valid = false;
                        //Console.WriteLine("There is no piece to take");
                    }
                    else
                    {
                        if (gameBoard[row + 1][col + 1].color != color)
                        {

                            valid = true;
                        }
                        else
                        {
                            //Console.WriteLine("You can not take the same color piece");
                            valid = false;
                        }

                    }
                }
                else if (southWestTake)
                {
                    if (gameBoard[row + 1][col - 1] == null)
                    {
                        valid = false;
                        //Console.WriteLine("There is no piece to take");
                    }
                    else
                    {
                        if (gameBoard[row + 1][col - 1].color != color)
                        {

                            valid = true;
                        }
                        else
                        {
                            //Console.WriteLine("You can not take the same color piece");
                            valid = false;
                        }

                    }
                }
                else
                {
                    //Console.WriteLine("This move is not valid");
                    valid = false;
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
