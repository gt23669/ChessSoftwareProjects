using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class King : Piece
    {

        //char color;
        //int xLoc;
        //int yLoc;
        bool isInCheck = false;
        public King(char color, int col, int row)
        {
            base.name = "King";
            base.ID = "K";
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


            bool north = row - 1 == nextRow && col == nextCol;
            bool northEast = row - 1 == nextRow && col + 1 == nextCol;
            bool northWest = row - 1 == nextRow && col - 1 == nextCol;
            bool east = row == nextRow && col + 1 == nextCol;
            bool south = row + 1 == nextRow && col == nextCol;
            bool southEast = row + 1 == nextRow && col + 1 == nextCol;
            bool southWest = row + 1 == nextRow && col - 1 == nextCol;
            bool west = row == nextRow && col - 1 == nextCol;




            if ((north) || (south))
            {
                if (north)
                {
                    if (gameBoard[row - 1][col] == null)
                    {
                        if (detectCheck(gameBoard))
                        {
                            Console.WriteLine($"You can not place the {color} {name} in check");
                            valid = false;

                        }
                        else
                        {
                            valid = true;
                        }

                    }
                    else
                    {
                        if (gameBoard[row - 1][col].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same color");
                            valid = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard))
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");
                                valid = false;

                            }
                            else
                            {
                                valid = true;
                            }
                        }
                    }
                }
                else
                {
                    if (gameBoard[row + 1][col] == null)
                    {
                        if (detectCheck(gameBoard))
                        {
                            Console.WriteLine($"You can not place the {color} {name} in check");
                            valid = false;

                        }
                        else
                        {
                            valid = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row + 1][col].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same color");
                            valid = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard))
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");
                                valid = false;

                            }
                            else
                            {
                                valid = true;
                            }
                        }
                    }
                }
            }
            else if ((east) || (west))
            {
                if (east)
                {
                    if (gameBoard[row][col + 1] == null)
                    {
                        if (detectCheck(gameBoard))
                        {
                            Console.WriteLine($"You can not place the {color} {name} in check");
                            valid = false;

                        }
                        else
                        {
                            valid = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row][col + 1].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same color");
                            valid = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard))
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");
                                valid = false;

                            }
                            else
                            {
                                valid = true;
                            }
                        }
                    }
                }
                else
                {
                    if (gameBoard[row][col - 1] == null)
                    {
                        if (detectCheck(gameBoard))
                        {
                            Console.WriteLine($"You can not place the {color} {name} in check");
                            valid = false;

                        }
                        else
                        {
                            valid = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row][col - 1].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same color");
                            valid = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard))
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");
                                valid = false;

                            }
                            else
                            {
                                valid = true;
                            }
                        }
                    }
                }
            }
            else if ((northEast) || (southEast))
            {
                if (northEast)
                {
                    if (gameBoard[row - 1][col + 1] == null)
                    {
                        if (detectCheck(gameBoard))
                        {
                            Console.WriteLine($"You can not place the {color} {name} in check");
                            valid = false;

                        }
                        else
                        {
                            valid = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row - 1][col + 1].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same color");
                            valid = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard))
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");
                                valid = false;

                            }
                            else
                            {
                                valid = true;
                            }
                        }
                    }
                }
                else
                {
                    if (gameBoard[row + 1][col + 1] == null)
                    {
                        if (detectCheck(gameBoard))
                        {
                            Console.WriteLine($"You can not place the {color} {name} in check");
                            valid = false;

                        }
                        else
                        {
                            valid = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row + 1][col + 1].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same color");
                            valid = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard))
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");
                                valid = false;

                            }
                            else
                            {
                                valid = true;
                            }
                        }
                    }
                }
            }
            else if ((northWest) || (southWest))
            {
                if (northWest)
                {
                    if (gameBoard[row - 1][col - 1] == null)
                    {
                        if (detectCheck(gameBoard))
                        {
                            Console.WriteLine($"You can not place the {color} {name} in check");
                            valid = false;

                        }
                        else
                        {
                            valid = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row - 1][col - 1].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same color");
                            valid = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard))
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");
                                valid = false;

                            }
                            else
                            {
                                valid = true;
                            }
                        }
                    }
                }
                else
                {
                    if (gameBoard[row + 1][col - 1] == null)
                    {
                        if (detectCheck(gameBoard))
                        {
                            Console.WriteLine($"You can not place the {color} {name} in check");
                            valid = false;

                        }
                        else
                        {
                            valid = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row + 1][col - 1].color == this.color)
                        {
                            Console.WriteLine("You can not move to a space occupied by the same color");
                            valid = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard))
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");
                                valid = false;

                            }
                            else
                            {
                                valid = true;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("This move is not valid");
                valid = false;
            }



            return valid;
        }

        internal bool detectCheck(Piece[][] gameBoard)
        {
            bool north;
            bool northEast;
            bool northWest;
            bool east;
            bool south;
            bool southEast;
            bool southWest;
            bool west;
            bool northEastRowKnight;
            bool northEastColKnight;
            bool southEastRowKnight;
            bool southEastColKnight;
            bool southWestRowKnight;
            bool southWestColKnight;
            bool northWestRowKnight;
            bool northWestColKnight;

            bool exit = false;
            bool checkExit = false;
            int index = 1;
            List<Piece> checkPieces = new List<Piece>();
            List<Piece> blockingPieces = new List<Piece>();

            for (int i = 1; i < 8; i++)
            {
                north = row - i >= 0 && col == col;//qkr
                northEast = row - i >= 0 && col + i <= 7;//qkpb
                northWest = row - i >= 0 && col - i >= 0;//qkpb
                east = row == row && col + i <= 7;//qkr
                south = row + i <= 7 && col == col;//qkr
                southEast = row + i <= 7 && col + i <= 7;//qkpb
                southWest = row + i <= 7 && col - i >= 0;//qkpb
                west = row == row && col - i >= 0;//qkr
                northEastRowKnight = row - 2 >= 0 && col + 1 <= 7;
                northEastColKnight = row - 1 >= 0 && col + 2 <= 7;
                southEastRowKnight = row + 2 <= 7 && col + 1 <= 7;
                southEastColKnight = row + 1 <= 7 && col + 2 <= 7;
                southWestRowKnight = row + 2 <= 7 && col - 1 >= 0;
                southWestColKnight = row + 1 <= 7 && col - 2 >= 0;
                northWestRowKnight = row - 2 >= 0 && col - 1 >= 0;
                northWestColKnight = row - 1 >= 0 && col - 2 >= 0;
                string type;

                if (northEastRowKnight || northEastColKnight)
                {
                    //northEastRowKnight = row - 2 >= 0 && col + 1 <= 7;
                    //northEastColKnight = row - 1 >= 0 && col + 2 <= 7;
                    if (northEastRowKnight)
                    {
                        if (gameBoard[row - 2][col + 1] != null && gameBoard[row - 2][col + 1].GetType().Name == "Knight")
                        {
                            if (gameBoard[row - 2][col + 1].color == this.color)
                            {

                            }
                            else
                            {
                                Console.WriteLine($"{color} {name} is in check by {gameBoard[row - 2][col + 1].color} {gameBoard[row - 2][col + 1].name}");
                                isInCheck = true;
                                return isInCheck;
                            }
                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        if (gameBoard[row - 1][col + 2] != null && gameBoard[row - 1][col + 2].GetType().Name == "Knight")
                        {
                            if (gameBoard[row - 1][col + 2].color == this.color)
                            {

                            }
                            else
                            {
                                Console.WriteLine($"{color} {name} is in check by {gameBoard[row - 2][col + 1].color} {gameBoard[row - 2][col + 1].name}");
                                isInCheck = true;
                                return isInCheck;
                            }
                        }
                        else
                        {

                        }

                    }
                }
                else if (southEastRowKnight || southEastColKnight)
                {
                    //southEastRowKnight = row + 2 <= 7 && col + 1 <= 7;
                    //southEastColKnight = row + 1 <= 7 && col + 2 <= 7;
                    if (southEastRowKnight)
                    {
                        if (gameBoard[row + 2][col + 1] != null && gameBoard[row + 2][col + 1].GetType().Name == "Knight")
                        {
                            if (gameBoard[row + 2][col + 1].color == this.color)
                            {

                            }
                            else
                            {
                                Console.WriteLine($"{color} {name} is in check by {gameBoard[row - 2][col + 1].color} {gameBoard[row - 2][col + 1].name}");
                                isInCheck = true;
                                return isInCheck;
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (gameBoard[row + 1][col + 2] != null && gameBoard[row + 1][col + 2].GetType().Name == "Knight")
                        {
                            if (gameBoard[row + 1][col + 2].color == this.color)
                            {

                            }
                            else
                            {
                                Console.WriteLine($"{color} {name} is in check by {gameBoard[row - 2][col + 1].color} {gameBoard[row - 2][col + 1].name}");
                                isInCheck = true;
                                return isInCheck;
                            }
                        }
                        else
                        {

                        }
                    }
                }
                else if (southWestRowKnight || southWestColKnight)
                {
                    //southWestRowKnight = row + 2 <= 7 && col - 1 >= 0;
                    //southWestColKnight = row + 1 <= 7 && col - 2 >= 0;
                    if (southWestRowKnight)
                    {
                        if (gameBoard[row + 2][col - 1] != null && gameBoard[row + 2][col - 1].GetType().Name == "Knight")
                        {
                            if (gameBoard[row + 2][col - 1].color == this.color)
                            {

                            }
                            else
                            {
                                Console.WriteLine($"{color} {name} is in check by {gameBoard[row - 2][col + 1].color} {gameBoard[row - 2][col + 1].name}");
                                isInCheck = true;
                                return isInCheck;
                            }
                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        if (gameBoard[row + 1][col - 2] != null && gameBoard[row + 1][col - 2].GetType().Name == "Knight")
                        {
                            if (gameBoard[row + 1][col - 2].color == this.color)
                            {

                            }
                            else
                            {
                                Console.WriteLine($"{color} {name} is in check by {gameBoard[row - 2][col + 1].color} {gameBoard[row - 2][col + 1].name}");
                                isInCheck = true;
                                return isInCheck;
                            }
                        }

                    }
                }
                else if (northWestRowKnight || northWestColKnight)
                {
                    //northWestRowKnight = row - 2 >= 0 && col - 1 >= 0;
                    //northWestColKnight = row - 1 >= 0 && col - 2 >= 0;
                    if (northWestRowKnight)
                    {
                        if (gameBoard[row - 2][col - 1] != null && gameBoard[row - 2][col - 1].GetType().Name == "Knight")
                        {
                            if (gameBoard[row - 2][col - 1].color == this.color)
                            {

                            }
                            else
                            {
                                Console.WriteLine($"{color} {name} is in check by {gameBoard[row - 2][col + 1].color} {gameBoard[row - 2][col + 1].name}");
                                isInCheck = true;
                                return isInCheck;
                            }
                        }

                    }
                    else
                    {
                        if (gameBoard[row - 1][col - 2] != null && gameBoard[row - 1][col - 2].GetType().Name == "Knight")
                        {
                            if (gameBoard[row - 1][col - 2].color == this.color)
                            {

                            }
                            else
                            {
                                Console.WriteLine($"{color} {name} is in check by {gameBoard[row - 2][col + 1].color} {gameBoard[row - 2][col + 1].name}");
                                isInCheck = true;
                                return isInCheck;
                            }
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    return isInCheck;
                }


                if (north)
                {
                    blockingPieces.Clear();
                    checkPieces.Clear();
                    checkExit = false;
                    index = 1;
                    //north = row - i >= 0 && col == col;//qkr
                    do
                    {

                        if (gameBoard[row - index][col] == null)
                        {
                            index++;
                            if (row - index < 0)
                            {                    
                                checkExit = true;
                            }
                        }
                        else
                        {
                            if ((gameBoard[row - index][col].GetType().Name == "Pawn" || gameBoard[row - index][col].GetType().Name == "Bishop" || gameBoard[row - index][col].GetType().Name == "Knight") || gameBoard[row - index][col].color == color)
                            {
                                blockingPieces.Add(gameBoard[row - index][col]);
                            }

                            if ((gameBoard[row - index][col].GetType().Name == "Queen" && gameBoard[row - index][col].color != this.color) ||
                                 (gameBoard[row - index][col].GetType().Name == "Rook" && gameBoard[row - index][col].color != this.color))
                            {
                                checkPieces.Add(gameBoard[row - index][col]);
                                isInCheck =  checkDanger(checkPieces, blockingPieces);
                            }
                            else if ((gameBoard[row - index][col].GetType().Name == "King" && gameBoard[row - index][col].color != this.color) && index < 2)
                            {
                                checkPieces.Add(gameBoard[row - index][col]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }

                            index++;
                            if (row - index < 0)
                            {
                                checkExit = true;
                            }
                        }

                    } while (!checkExit);
                }
                if (northEast)
                {
                    blockingPieces.Clear();
                    checkPieces.Clear();
                    checkExit = false;
                    index = 1;
                    //northEast = row - i >= 0 && col + i <= 7;//qkpb
                    do
                    {

                        if (gameBoard[row - index][col + index] == null)
                        {
                            index++;
                            if (row - index < 0 || col + index > 7)
                            {
                                checkExit = true;
                            }
                        }
                        else
                        {
                            if ((gameBoard[row - index][col + index].GetType().Name == "Rook" || gameBoard[row - index][col + index].GetType().Name == "Knight")|| gameBoard[row - index][col + index].color == color)
                            {
                                blockingPieces.Add(gameBoard[row - index][col + index]);
                            }

                            if ((gameBoard[row - index][col + index].GetType().Name == "Queen" && gameBoard[row - index][col + index].color != this.color) ||
                                 (gameBoard[row - index][col + index].GetType().Name == "Pawn" && gameBoard[row - index][col + index].color != this.color) ||
                                 (gameBoard[row - index][col + index].GetType().Name == "Bishop" && gameBoard[row - index][col + index].color != this.color))
                            {
                                checkPieces.Add(gameBoard[row - index][col + index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }
                            else if ((gameBoard[row - index][col + index].GetType().Name == "King" && gameBoard[row - index][col + index].color != this.color) && index < 2)
                            {
                                checkPieces.Add(gameBoard[row - index][col + index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }

                            index++;
                            if (row - index < 0 || col + index > 7)
                            {
                                checkExit = true;
                            }
                        }

                    } while (!checkExit);

                }
                if (northWest)
                {
                    //northWest = row - i >= 0 && col - i >= 0;//qkpb
                    blockingPieces.Clear();
                    checkPieces.Clear();
                    checkExit = false;
                    index = 1;
                    do
                    {

                        if (gameBoard[row - index][col - index] == null)
                        {
                            index++;
                            if (row - index < 0 || col - index < 0)
                            {
                                checkExit = true;
                            }
                        }
                        else
                        {
                            if ((gameBoard[row - index][col - index].GetType().Name == "Rook" || gameBoard[row - index][col - index].GetType().Name == "Knight") || gameBoard[row - index][col - index].color == color)
                            {
                                blockingPieces.Add(gameBoard[row - index][col - index]);
                            }

                            if ((gameBoard[row - index][col - index].GetType().Name == "Queen" && gameBoard[row - index][col - index].color != this.color) ||
                                 (gameBoard[row - index][col - index].GetType().Name == "Pawn" && gameBoard[row - index][col - index].color != this.color) ||
                                 (gameBoard[row - index][col - index].GetType().Name == "Bishop" && gameBoard[row - index][col - index].color != this.color))
                            {
                                checkPieces.Add(gameBoard[row - index][col - index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }
                            else if ((gameBoard[row - index][col - index].GetType().Name == "King" && gameBoard[row - index][col - index].color != this.color) && index < 2)
                            {
                                checkPieces.Add(gameBoard[row - index][col - index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }

                            index++;
                            if (row - index < 0 || col - index < 0)
                            {
                                checkExit = true;
                            }
                        }

                    } while (!checkExit);
                }
                if (east)
                {
                    //east = row == row && col + i <= 7;//qkr
                    blockingPieces.Clear();
                    checkPieces.Clear();
                    checkExit = false;
                    index = 1;
                    do
                    {

                        if (gameBoard[row][col + index] == null)
                        {
                            index++;
                            if (col + index > 7)
                            {
                                checkExit = true;
                            }
                        }
                        else
                        {
                            if ((gameBoard[row][col + index].GetType().Name == "Pawn" || gameBoard[row][col + index].GetType().Name == "Bishop" || gameBoard[row][col + index].GetType().Name == "Knight") || gameBoard[row][col + index].color == color)
                            {
                                blockingPieces.Add(gameBoard[row][col + index]);
                            }

                            if ((gameBoard[row][col + index].GetType().Name == "Queen" && gameBoard[row][col + index].color != this.color) ||
                                 (gameBoard[row][col + index].GetType().Name == "Rook" && gameBoard[row][col + index].color != this.color))
                            {
                                checkPieces.Add(gameBoard[row][col + index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }
                            else if ((gameBoard[row][col + index].GetType().Name == "King" && gameBoard[row][col + index].color != this.color) && index < 2)
                            {
                                checkPieces.Add(gameBoard[row][col + index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }

                            index++;
                            if (col + index > 7)
                            {
                                checkExit = true;
                            }
                        }

                    } while (!checkExit);
                }
                if (south)
                {
                    //south = row + i <= 7 && col == col;//qkr
                    blockingPieces.Clear();
                    checkPieces.Clear();
                    checkExit = false;
                    index = 1;
                    do
                    {

                        if (gameBoard[row + index][col] == null)
                        {
                            index++;
                            if (row + index > 7)
                            {
                                checkExit = true;
                            }
                        }
                        else
                        {
                            if ((gameBoard[row + index][col].GetType().Name == "Pawn" || gameBoard[row + index][col].GetType().Name == "Bishop" || gameBoard[row + index][col].GetType().Name == "Knight") || gameBoard[row + index][col].color == color)
                            {
                                blockingPieces.Add(gameBoard[row + index][col]);
                            }

                            if ((gameBoard[row + index][col].GetType().Name == "Queen" && gameBoard[row + index][col].color != this.color) ||
                                 (gameBoard[row + index][col].GetType().Name == "Rook" && gameBoard[row + index][col].color != this.color))
                            {
                                checkPieces.Add(gameBoard[row + index][col]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }
                            else if ((gameBoard[row + index][col].GetType().Name == "King" && gameBoard[row + index][col].color != this.color) && index < 2)
                            {
                                checkPieces.Add(gameBoard[row + index][col]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }


                            index++;
                            if (row + index > 7)
                            {
                                checkExit = true;
                            }
                        }

                    } while (!checkExit);
                }
                if (southEast)
                {
                    //southEast = row + i <= 7 && col + i <= 7;//qkpb
                    blockingPieces.Clear();
                    checkPieces.Clear();
                    checkExit = false;
                    index = 1;
                    do
                    {

                        if (gameBoard[row + index][col + index] == null)
                        {
                            index++;
                            if (row + index > 7 || col + index > 7)
                            {
                                checkExit = true;
                            }
                        }
                        else
                        {
                            if ((gameBoard[row + index][col + index].GetType().Name == "Rook" || gameBoard[row + index][col + index].GetType().Name == "Knight") || gameBoard[row + index][col + index].color == color)
                            {
                                blockingPieces.Add(gameBoard[row + index][col + index]);
                            }

                            if ((gameBoard[row + index][col + index].GetType().Name == "Queen" && gameBoard[row + index][col + index].color != this.color) ||
                                 (gameBoard[row + index][col + index].GetType().Name == "Pawn" && gameBoard[row + index][col + index].color != this.color) ||
                                 (gameBoard[row + index][col + index].GetType().Name == "Bishop" && gameBoard[row + index][col + index].color != this.color))
                            {
                                checkPieces.Add(gameBoard[row + index][col + index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }
                            else if ((gameBoard[row + index][col + index].GetType().Name == "King" && gameBoard[row + index][col + index].color != this.color) && index < 2)
                            {
                                checkPieces.Add(gameBoard[row + index][col + index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }

                            index++;
                            if (row + index > 7 || col + index > 7)
                            {
                                checkExit = true;
                            }
                        }

                    } while (!checkExit);
                }
                if (southWest)
                {
                    //southWest = row + i <= 7 && col - i >= 0;//qkpb
                    blockingPieces.Clear();
                    checkPieces.Clear();
                    checkExit = false;
                    index = 1;
                    do
                    {

                        if (gameBoard[row + index][col] == null)
                        {
                            index++;
                            if (row + index > 7)
                            {
                                checkExit = true;
                            }
                        }
                        else
                        {
                            if ((gameBoard[row + index][col].GetType().Name == "Rook" || gameBoard[row + index][col].GetType().Name == "Knight") || gameBoard[row + index][col].color == color)
                            {
                                blockingPieces.Add(gameBoard[row + index][col]);
                            }

                            if ((gameBoard[row + index][col].GetType().Name == "Queen" && gameBoard[row + index][col].color != this.color) ||
                                 (gameBoard[row + index][col].GetType().Name == "Pawn" && gameBoard[row + index][col].color != this.color) ||
                                 (gameBoard[row + index][col].GetType().Name == "Bishop" && gameBoard[row + index][col].color != this.color))
                            {
                                checkPieces.Add(gameBoard[row + index][col]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }
                            else if ((gameBoard[row + index][col].GetType().Name == "King" && gameBoard[row + index][col].color != this.color) && index < 2)
                            {
                                checkPieces.Add(gameBoard[row + index][col]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }

                            index++;
                            if (row + index > 7)
                            {
                                checkExit = true;
                            }
                        }

                    } while (!checkExit);
                }
                if (west)
                {
                    //west = row == row && col - i >= 0;//qkr
                    blockingPieces.Clear();
                    checkPieces.Clear();
                    checkExit = false;
                    index = 1;
                    do
                    {

                        if (gameBoard[row][col - index] == null)
                        {
                            index++;
                            if (col - index < 0)
                            {
                                checkExit = true;
                            }
                        }
                        else
                        {
                            if ((gameBoard[row][col - index].GetType().Name == "Pawn" || gameBoard[row][col - index].GetType().Name == "Bishop" || gameBoard[row][col - index].GetType().Name == "Knight") || gameBoard[row][col - index].color == color)
                            {
                                blockingPieces.Add(gameBoard[row][col - index]);
                            }

                            if ((gameBoard[row][col - index].GetType().Name == "Queen" && gameBoard[row][col - index].color != this.color) ||
                                 (gameBoard[row][col - index].GetType().Name == "Rook" && gameBoard[row][col - index].color != this.color))
                            {
                                checkPieces.Add(gameBoard[row][col - index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }
                            else if ((gameBoard[row][col - index].GetType().Name == "King" && gameBoard[row][col - index].color != this.color) && index < 2)
                            {
                                checkPieces.Add(gameBoard[row][col - index]);
                                isInCheck = checkDanger(checkPieces, blockingPieces);
                            }

                            index++;
                            if (col - index < 0)
                            {
                                checkExit = true;
                            }
                        }

                    } while (!checkExit);
                }


            }

            return isInCheck;
        }

        private bool checkDanger(List<Piece> checkPieces, List<Piece> blockingPieces)
        {

            if (blockingPieces.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
