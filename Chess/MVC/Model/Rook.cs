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
                return valid;
            }

            if (col-nextCol == 0 )//moving vertically
            {
                for (int i = row; i < gameBoard.Length; i++)
                {
                    if (row+i>7)
                    {
                        break;
                    }
                    if (gameBoard[row+i][col] == gameBoard[nextRow][nextCol])
                    {
                        for (int j = 0; j < gameBoard.Length; j++)
                        {
                            if (gameBoard[row+j][col] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                //if (gameBoard[row+1][col].color == 'L')
                                //{
                                //    valid = true;
                                //}
                                //else
                                //{
                                //    valid = false;
                                //    return valid;
                                //}
                                valid = false;
                                break;
                            }
                        }
                    return valid;
                    }
                    else
                    {
                        valid = false;
                    }
                }
                for (int i = row; i < gameBoard.Length; i++)
                {
                    if (row - i < 0)
                    {
                        break;
                    }
                    if (gameBoard[row - i][col] == gameBoard[nextRow][nextCol])
                    {
                        for (int j = 0; j < gameBoard.Length; j++)
                        {
                            if (gameBoard[row - j][col] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                //if (gameBoard[row+1][col].color == 'L')
                                //{
                                //    valid = true;
                                //}
                                //else
                                //{
                                //    valid = false;
                                //    return valid;
                                //}
                                valid = false;
                                break;
                            }
                        }
                    return valid;
                    }
                    else
                    {
                        valid = false;
                    }
                }
            }
            if (row-nextRow == 0)//moving horizontally
            {
                for (int i = col; i < gameBoard.Length; i++)
                {
                    if (col + i > 7)
                    {
                        break;
                    }
                    if (gameBoard[row][col+i] == gameBoard[nextRow][nextCol])
                    {
                        for (int j = 0; j < gameBoard.Length; j++)
                        {
                            if (gameBoard[row][col+j] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                //if (gameBoard[row+1][col].color == 'L')
                                //{
                                //    valid = true;
                                //}
                                //else
                                //{
                                //    valid = false;
                                //    return valid;
                                //}
                                valid = false;
                                break;
                            }
                        }
                        return valid;
                    }
                    else
                    {
                        valid = false;
                    }
                }
                for (int i = col; i < gameBoard.Length; i++)
                {
                    if (col - i < 0)
                    {
                        break;
                    }
                    if (gameBoard[row][col-i] == gameBoard[nextRow][nextCol])
                    {

                        for (int j = 0; j < gameBoard.Length; j++)
                        {
                            if (gameBoard[row][col-j] == null)
                            {
                                valid = true;
                            }
                            else
                            {
                                //if (gameBoard[row+1][col].color == 'L')
                                //{
                                //    valid = true;
                                //}
                                //else
                                //{
                                //    valid = false;
                                //    return valid;
                                //}
                                valid = false;
                                break;
                            }
                        }
                        return valid;
                    }
                    else
                    {
                        valid = false;
                    }
                }
            }

            return valid;
        }
    }
}
