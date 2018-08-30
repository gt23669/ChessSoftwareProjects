using System;
using System.Collections.Generic;

namespace Chess.MVC.Model.Tokens
{
    class Knight : Piece
    {
        public Knight(char color, int col, int row)
        {
            name = "Knight";
            ID = "N";
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
            bool northEastRow = row - 2 == nextRow && col + 1 == nextCol;
            bool northEastCol = row - 1 == nextRow && col + 2 == nextCol;
            bool northWestRow = row - 2 == nextRow && col - 1 == nextCol;
            bool northWestCol = row - 1 == nextRow && col - 2 == nextCol;
            bool southEastRow = row + 2 == nextRow && col + 1 == nextCol;
            bool southEastCol = row + 1 == nextRow && col + 2 == nextCol;
            bool southWestRow = row + 2 == nextRow && col - 1 == nextCol;
            bool southWestCol = row + 1 == nextRow && col - 2 == nextCol;

            if ((southEastRow) || (southEastCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        if (message)
                        {

                            Console.WriteLine("You can not move there, same color piece occupies the space");
                        }
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
            else if ((northEastRow) || (northEastCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        if (message)
                        {
                            Console.WriteLine("You can not move there, same color piece occupies the space");

                        }
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
            else if ((northWestCol) || (northWestRow))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        if (message)
                        {
                            Console.WriteLine("You can not move there, same color piece occupies the space");

                        }
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
            else if ((southWestRow) || (southWestCol))
            {
                if (gameBoard[nextRow][nextCol] != null)
                {
                    if (gameBoard[nextRow][nextCol].color == this.color)
                    {
                        if (message)
                        {
                            Console.WriteLine("You can not move there, same color piece occupies the space");

                        }
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
                if (message)
                {
                    Console.WriteLine("This is not a legal move");

                }
                valid = false;
            }

            return valid;
        }


    }
}
