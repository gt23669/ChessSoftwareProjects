using Chess.MVC.Controller;
using System;
using System.Collections.Generic;

namespace Chess.MVC.Model.Tokens
{
    class King : Piece
    {
        private bool isInCheck = false;
        private bool isInCheckMate = false;
        private bool hasBlockingToken = false;
        public King(char color, int col, int row)
        {
            name = "King";
            ID = "K";
            base.color = color;
            base.col = col;
            base.row = row;
            moves = new List<Move>();
        }

        public bool IsInCheck { get => isInCheck; set => isInCheck = value; }
        public bool IsInCheckMate { get => isInCheckMate; set => isInCheckMate = value; }
        public bool HasBlockingToken { get => hasBlockingToken; set => hasBlockingToken = value; }

        public override string ToString()
        {
            return ID;
        }
        public override bool CheckValidMove(Piece[][] gameBoard, List<Piece> gameTokens, int nextRow, int nextCol, bool message)
        {
            bool validMove = false;
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

            bool north = row - 1 == nextRow && col == nextCol;
            bool northEast = row - 1 == nextRow && col + 1 == nextCol;
            bool northWest = row - 1 == nextRow && col - 1 == nextCol;
            bool east = row == nextRow && col + 1 == nextCol;
            bool south = row + 1 == nextRow && col == nextCol;
            bool southEast = row + 1 == nextRow && col + 1 == nextCol;
            bool southWest = row + 1 == nextRow && col - 1 == nextCol;
            bool west = row == nextRow && col - 1 == nextCol;

            if (north || south || east || west || northEast || southEast || northWest || southWest)
            {
                //north
                if (north)
                {
                    if (gameBoard[row - 1][col] == null)
                    {
                        if (detectCheck(gameBoard, gameTokens))
                        {
                            if (message)
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");

                            }
                            validMove = false;

                        }
                        else
                        {
                            validMove = true;
                        }

                    }
                    else
                    {
                        if (gameBoard[row - 1][col].color == this.color)
                        {
                            if (message)
                            {
                                Console.WriteLine("You can not move to a space occupied by the same color");

                            }
                            validMove = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard, gameTokens))
                            {
                                if (message)
                                {
                                    Console.WriteLine($"You can not place the {color} {name} in check");

                                }
                                validMove = false;

                            }
                            else
                            {
                                validMove = true;
                            }
                        }
                    }
                }
                //south
                if (south)
                {
                    if (gameBoard[row + 1][col] == null)
                    {
                        if (detectCheck(gameBoard, gameTokens))
                        {
                            if (message)
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");

                            }
                            validMove = false;

                        }
                        else
                        {
                            validMove = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row + 1][col].color == this.color)
                        {
                            if (message)
                            {
                                Console.WriteLine("You can not move to a space occupied by the same color");

                            }
                            validMove = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard, gameTokens))
                            {
                                if (message)
                                {
                                    Console.WriteLine($"You can not place the {color} {name} in check");

                                }
                                validMove = false;

                            }
                            else
                            {
                                validMove = true;
                            }
                        }
                    }
                }
                if (east)
                {
                    if (east)
                    {
                        if (gameBoard[row][col + 1] == null)
                        {
                            if (detectCheck(gameBoard, gameTokens))
                            {
                                if (message)
                                {
                                    Console.WriteLine($"You can not place the {color} {name} in check");

                                }
                                validMove = false;

                            }
                            else
                            {
                                validMove = true;
                            }
                        }
                        else
                        {
                            if (gameBoard[row][col + 1].color == this.color)
                            {
                                if (message)
                                {
                                    Console.WriteLine("You can not move to a space occupied by the same color");

                                }
                                validMove = false;
                            }
                            else
                            {
                                if (detectCheck(gameBoard, gameTokens))
                                {
                                    if (message)
                                    {
                                        Console.WriteLine($"You can not place the {color} {name} in check");

                                    }
                                    validMove = false;

                                }
                                else
                                {
                                    validMove = true;
                                }
                            }
                        }
                    }
                }
                if (west)
                {
                    if (gameBoard[row][col - 1] == null)
                    {
                        if (detectCheck(gameBoard, gameTokens))
                        {
                            if (message)
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");

                            }
                            validMove = false;

                        }
                        else
                        {
                            validMove = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row][col - 1].color == this.color)
                        {
                            if (message)
                            {
                                Console.WriteLine("You can not move to a space occupied by the same color");

                            }
                            validMove = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard, gameTokens))
                            {
                                if (message)
                                {
                                    Console.WriteLine($"You can not place the {color} {name} in check");

                                }
                                validMove = false;

                            }
                            else
                            {
                                validMove = true;
                            }
                        }
                    }
                }
                if (northEast)
                {
                    if (gameBoard[row - 1][col + 1] == null)
                    {
                        if (detectCheck(gameBoard, gameTokens))
                        {
                            if (message)
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");

                            }
                            validMove = false;

                        }
                        else
                        {
                            validMove = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row - 1][col + 1].color == this.color)
                        {
                            if (message)
                            {
                                Console.WriteLine("You can not move to a space occupied by the same color");

                            }
                            validMove = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard, gameTokens))
                            {
                                if (message)
                                {
                                    Console.WriteLine($"You can not place the {color} {name} in check");

                                }
                                validMove = false;

                            }
                            else
                            {
                                validMove = true;
                            }
                        }
                    }
                }
                //southeast
                if (southEast)
                {
                    if (gameBoard[row + 1][col + 1] == null)
                    {
                        if (detectCheck(gameBoard, gameTokens))
                        {
                            if (message)
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");

                            }
                            validMove = false;

                        }
                        else
                        {
                            validMove = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row + 1][col + 1].color == this.color)
                        {
                            if (message)
                            {
                                Console.WriteLine("You can not move to a space occupied by the same color");

                            }
                            validMove = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard, gameTokens))
                            {
                                if (message)
                                {
                                    Console.WriteLine($"You can not place the {color} {name} in check");

                                }
                                validMove = false;

                            }
                            else
                            {
                                validMove = true;
                            }
                        }
                    }
                }
                //northwest
                if (northWest)
                {
                    if (gameBoard[row - 1][col - 1] == null)
                    {
                        if (detectCheck(gameBoard, gameTokens))
                        {
                            if (message)
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");

                            }
                            validMove = false;

                        }
                        else
                        {
                            validMove = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row - 1][col - 1].color == this.color)
                        {
                            if (message)
                            {
                                Console.WriteLine("You can not move to a space occupied by the same color");

                            }
                            validMove = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard, gameTokens))
                            {
                                if (message)
                                {
                                    Console.WriteLine($"You can not place the {color} {name} in check");

                                }
                                validMove = false;

                            }
                            else
                            {
                                validMove = true;
                            }
                        }
                    }
                }
                //southwest
                if (southWest)
                {
                    if (gameBoard[row + 1][col - 1] == null)
                    {
                        if (detectCheck(gameBoard, gameTokens))
                        {
                            if (message)
                            {
                                Console.WriteLine($"You can not place the {color} {name} in check");

                            }
                            validMove = false;

                        }
                        else
                        {
                            validMove = true;
                        }
                    }
                    else
                    {
                        if (gameBoard[row + 1][col - 1].color == this.color)
                        {
                            if (message)
                            {
                                Console.WriteLine("You can not move to a space occupied by the same color");

                            }
                            validMove = false;
                        }
                        else
                        {
                            if (detectCheck(gameBoard, gameTokens))
                            {
                                if (message)
                                {
                                    Console.WriteLine($"You can not place the {color} {name} in check");

                                }
                                validMove = false;

                            }
                            else
                            {
                                validMove = true;
                            }
                        }
                    }
                }

            }
            else
            {
                if (message)
                {
                    Console.WriteLine("This move is not valid");

                }
                validMove = false;
            }

            return validMove;
        }


        public bool detectCheck(Piece[][] gameBoard, List<Piece> gameTokens, Piece selectedToken = null)
        {
            bool isKingInCheck = false;


            if (CheckForKnight(gameBoard) || CheckForPawn(gameBoard) || CheckForAllElse(gameBoard, gameTokens))
            {
                return true;
            }

            return isKingInCheck;
        }

        public bool CheckForKnight(Piece[][] gameBoard)
        {


            bool NEC = row - 1 >= 0 && col + 2 <= 7;
            bool NER = row - 2 >= 0 && col + 1 <= 7;
            bool NWC = row - 1 >= 0 && col - 2 >= 0;
            bool NWR = row - 2 >= 0 && col - 1 >= 0;
            if (NEC)
            {
                if (gameBoard[row - 1][col + 2] != null && gameBoard[row - 1][col + 2].GetType().Name == "Knight" && gameBoard[row - 1][col + 2].color != color)
                {
                    return true;
                }
                else
                {

                }
            }
            if (NER)
            {
                if (gameBoard[row - 2][col + 1] != null && gameBoard[row - 2][col + 1].GetType().Name == "Knight" && gameBoard[row - 2][col + 1].color != color)
                {
                    return true;
                }
                else
                {

                }
            }
            if (NWC)
            {
                if (gameBoard[row - 1][col - 2] != null && gameBoard[row - 1][col - 2].GetType().Name == "Knight" && gameBoard[row - 1][col - 2].color != color)
                {
                    return true;
                }
                else
                {

                }
            }
            if (NWR)
            {
                if (gameBoard[row - 2][col - 1] != null && gameBoard[row - 2][col - 1].GetType().Name == "Knight" && gameBoard[row - 2][col - 1].color != color)
                {
                    return true;
                }
                else
                {

                }
            }


            bool SEC = row + 1 <= 7 && col + 2 <= 7;
            bool SER = row + 2 <= 7 && col + 1 <= 7;
            bool SWC = row + 1 <= 7 && col - 2 >= 0;
            bool SWR = row + 2 <= 7 && col - 1 >= 0;
            if (SEC)
            {
                if (gameBoard[row + 1][col + 2] != null && gameBoard[row + 1][col + 2].GetType().Name == "Knight" && gameBoard[row + 1][col + 2].color != color)
                {
                    return true;
                }
                else
                {

                }
            }
            if (SER)
            {
                if (gameBoard[row + 2][col + 1] != null && gameBoard[row + 2][col + 1].GetType().Name == "Knight" && gameBoard[row + 2][col + 1].color != color)
                {
                    return true;
                }
                else
                {

                }
            }
            if (SWC)
            {
                if (gameBoard[row + 1][col - 2] != null && gameBoard[row + 1][col - 2].GetType().Name == "Knight" && gameBoard[row + 1][col - 2].color != color)
                {
                    return true;
                }
                else
                {

                }
            }
            if (SWR)
            {
                if (gameBoard[row + 2][col - 1] != null && gameBoard[row + 2][col - 1].GetType().Name == "Knight" && gameBoard[row + 2][col - 1].color != color)
                {
                    return true;
                }
                else
                {

                }
            }



            return false;
        }
        public bool CheckForPawn(Piece[][] gameBoard)
        {
            bool NE = row - 1 >= 0 && col + 1 <= 7;
            bool NW = row - 1 >= 0 && col - 1 >= 0;
            bool SE = row + 1 <= 7 && col + 1 <= 7;
            bool SW = row + 1 <= 7 && col - 1 >= 0;

            if (NE)
            {
                if (gameBoard[row - 1][col + 1] != null && gameBoard[row - 1][col + 1].GetType().Name == "Pawn" && gameBoard[row - 1][col + 1].color != color)
                {
                    return true;
                }

            }
            if (NW)
            {
                if (gameBoard[row - 1][col - 1] != null && gameBoard[row - 1][col - 1].GetType().Name == "Pawn" && gameBoard[row - 1][col - 1].color != color)
                {
                    return true;
                }

            }
            if (SE)
            {
                if (gameBoard[row + 1][col + 1] != null && gameBoard[row + 1][col + 1].GetType().Name == "Pawn" && gameBoard[row + 1][col + 1].color != color)
                {
                    return true;
                }

            }
            if (SW)
            {
                if (gameBoard[row + 1][col - 1] != null && gameBoard[row + 1][col - 1].GetType().Name == "Pawn" && gameBoard[row + 1][col - 1].color != color)
                {
                    return true;
                }

            }

            return false;
        }
        public bool CheckForAllElse(Piece[][] gameBoard, List<Piece> gameTokens)
        {
            bool north;
            bool south;
            bool east;
            bool west;
            bool northEast;
            bool northWest;
            bool southEast;
            bool southWest;

            bool check = false;


            List<Move> possibleBlockingMoves = new List<Move>();
            List<Move> pathToKing = new List<Move>();

            for (int i = 1; i < gameBoard.Length; i++)
            {

                north = row - i >= 0;//qr
                if (north)
                {
                    if (gameBoard[row - i][col] == null)
                    {
                        pathToKing.Add(new Move(row - i, col));
                        continue;
                    }
                    else
                    {
                        pathToKing.Add(new Move(row - i, col));
                        if (gameBoard[row - i][col].GetType().Name == "Pawn" || gameBoard[row - i][col].GetType().Name == "Bishop" || gameBoard[row - i][col].GetType().Name == "Knight" || gameBoard[row - i][col].color == color)
                        {
                            break;
                        }
                        else
                        {
                            for (int j = 0; j < gameTokens.Count; j++)
                            {
                                if (gameTokens[j] == this || gameTokens[j].GetType().Name=="King")
                                {
                                    continue;
                                }
                                else if (gameTokens[j].color == color)
                                {
                                    possibleBlockingMoves.AddRange(Game.FindAvailableMoves(gameTokens[j], gameTokens[j].row, gameTokens[j].col));
                                }
                            }
                            for (int j = 0; j < possibleBlockingMoves.Count; j++)
                            {
                                for (int k = 0; k < pathToKing.Count; k++)
                                {
                                    if (possibleBlockingMoves[j].row == pathToKing[k].row && possibleBlockingMoves[j].col == pathToKing[k].col)
                                    {
                                        HasBlockingToken = true;
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = true;
                                    }
                                }
                                if (HasBlockingToken)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                if (HasBlockingToken || !north)
                {
                    possibleBlockingMoves.Clear();
                    pathToKing.Clear();
                    break;
                }
            }
            for (int i = 1; i < gameBoard.Length; i++)
            {
                south = row + i <= 7;//qr
                if (south)
                {

                    if (gameBoard[row + i][col] == null)
                    {
                        pathToKing.Add(new Move(row + i, col));
                        continue;
                    }
                    else
                    {
                        pathToKing.Add(new Move(row + i, col));
                        if (gameBoard[row + i][col].GetType().Name == "Pawn" || gameBoard[row + i][col].GetType().Name == "Bishop" || gameBoard[row + i][col].GetType().Name == "Knight" || gameBoard[row + i][col].color == color)
                        {
                            break;
                        }
                        else
                        {
                            for (int j = 0; j < gameTokens.Count; j++)
                            {
                                if (gameTokens[j] == this || gameTokens[j].GetType().Name == "King")
                                {
                                    continue;
                                }
                                else
                                {
                                    possibleBlockingMoves.AddRange(Game.FindAvailableMoves(gameTokens[j], gameTokens[j].row, gameTokens[j].col));
                                }
                            }
                            for (int j = 0; j < possibleBlockingMoves.Count; j++)
                            {
                                for (int k = 0; k < pathToKing.Count; k++)
                                {
                                    if (possibleBlockingMoves[j].row == pathToKing[k].row && possibleBlockingMoves[j].col == pathToKing[k].col)
                                    {
                                        HasBlockingToken = true;
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = true;
                                    }
                                }
                                if (HasBlockingToken)
                                {
                                    possibleBlockingMoves.Clear();
                                    pathToKing.Clear();
                                    break;
                                }
                            }
                        }
                    }
                }
                if (HasBlockingToken || !south)
                {
                    break;
                }

            }
            for (int i = 1; i < gameBoard.Length; i++)
            {
                east = col + i <= 7;//qr
                if (east)
                {

                    if (gameBoard[row][col + i] == null)
                    {
                        pathToKing.Add(new Move(row, col + i));
                        continue;
                    }
                    else
                    {
                        pathToKing.Add(new Move(row, col + i));
                        if (gameBoard[row][col + i].GetType().Name == "Pawn" || gameBoard[row][col + i].GetType().Name == "Bishop" || gameBoard[row][col + i].GetType().Name == "Knight" || gameBoard[row][col + i].color == color)
                        {
                            break;
                        }
                        else
                        {
                            for (int j = 0; j < gameTokens.Count; j++)
                            {
                                if (gameTokens[j] == this || gameTokens[j].GetType().Name == "King")
                                {
                                    continue;
                                }
                                else
                                {
                                    possibleBlockingMoves.AddRange(Game.FindAvailableMoves(gameTokens[j], gameTokens[j].row, gameTokens[j].col));
                                }
                            }
                            for (int j = 0; j < possibleBlockingMoves.Count; j++)
                            {
                                for (int k = 0; k < pathToKing.Count; k++)
                                {
                                    if (possibleBlockingMoves[j].row == pathToKing[k].row && possibleBlockingMoves[j].col == pathToKing[k].col)
                                    {
                                        HasBlockingToken = true;
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = true;
                                    }
                                }
                                if (HasBlockingToken)
                                {
                                    possibleBlockingMoves.Clear();
                                    pathToKing.Clear();
                                    break;
                                }
                            }
                        }
                    }
                }
                if (HasBlockingToken || !east)
                {
                    break;
                }
            }
            for (int i = 1; i < gameBoard.Length; i++)
            {
                west = col - i >= 0;//qr
                if (west)
                {

                    if (gameBoard[row][col - i] == null)
                    {
                        pathToKing.Add(new Move(row, col - i));
                        continue;
                    }
                    else
                    {
                        pathToKing.Add(new Move(row, col - i));
                        if (gameBoard[row][col - i].GetType().Name == "Pawn" || gameBoard[row][col - i].GetType().Name == "Bishop" || gameBoard[row][col - i].GetType().Name == "Knight" || gameBoard[row][col - i].color == color)
                        {
                            break;
                        }
                        else
                        {
                            for (int j = 0; j < gameTokens.Count; j++)
                            {
                                if (gameTokens[j] == this || gameTokens[j].GetType().Name == "King")
                                {
                                    continue;
                                }
                                else
                                {
                                    possibleBlockingMoves.AddRange(Game.FindAvailableMoves(gameTokens[j], gameTokens[j].row, gameTokens[j].col));
                                }
                            }
                            for (int j = 0; j < possibleBlockingMoves.Count; j++)
                            {
                                for (int k = 0; k < pathToKing.Count; k++)
                                {
                                    if (possibleBlockingMoves[j].row == pathToKing[k].row && possibleBlockingMoves[j].col == pathToKing[k].col)
                                    {
                                        HasBlockingToken = true;
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = true;
                                    }
                                }
                                if (HasBlockingToken)
                                {
                                    possibleBlockingMoves.Clear();
                                    pathToKing.Clear();
                                    break;
                                }
                            }
                        }
                    }
                }
                if (HasBlockingToken || !west)
                {
                    break;
                }

            }
            for (int i = 1; i < gameBoard.Length; i++)
            {
                northEast = row - i >= 0 && col + i <= 7;//qb
                if (northEast)
                {

                    if (gameBoard[row - i][col + i] == null)
                    {
                        pathToKing.Add(new Move(row - i, col + i));
                        continue;
                    }
                    else
                    {
                        pathToKing.Add(new Move(row - i, col + i));
                        if (gameBoard[row - i][col + i].GetType().Name == "Rook" || gameBoard[row - i][col + i].GetType().Name == "Knight" || gameBoard[row - i][col + i].color == color)
                        {
                            break;
                        }
                        else
                        {
                            for (int j = 0; j < gameTokens.Count; j++)
                            {
                                if (gameTokens[j] == this || gameTokens[j].GetType().Name == "King")
                                {
                                    continue;
                                }
                                else
                                {
                                    possibleBlockingMoves.AddRange(Game.FindAvailableMoves(gameTokens[j], gameTokens[j].row, gameTokens[j].col));
                                }
                            }
                            for (int j = 0; j < possibleBlockingMoves.Count; j++)
                            {
                                for (int k = 0; k < pathToKing.Count; k++)
                                {
                                    if (possibleBlockingMoves[j].row == pathToKing[k].row && possibleBlockingMoves[j].col == pathToKing[k].col)
                                    {
                                        HasBlockingToken = true;
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = true;
                                    }
                                }
                                if (HasBlockingToken)
                                {
                                    possibleBlockingMoves.Clear();
                                    pathToKing.Clear();
                                    break;
                                }
                            }
                        }
                    }
                }
                if (HasBlockingToken || !northEast)
                {
                    break;
                }

            }
            for (int i = 1; i < gameBoard.Length; i++)
            {
                northWest = row - i >= 0 && col - i >= 0;//qb
                if (northWest)
                {

                    if (gameBoard[row - i][col - i] == null)
                    {
                        pathToKing.Add(new Move(row - i, col - i));
                        continue;
                    }
                    else
                    {
                        pathToKing.Add(new Move(row - i, col - i));
                        if (gameBoard[row - i][col - i].GetType().Name == "Rook" || gameBoard[row - i][col - i].GetType().Name == "Knight" || gameBoard[row - i][col - i].color == color)
                        {
                            break;
                        }
                        else
                        {
                            for (int j = 0; j < gameTokens.Count; j++)
                            {
                                if (gameTokens[j] == this || gameTokens[j].GetType().Name == "King")
                                {
                                    continue;
                                }
                                else
                                {
                                    possibleBlockingMoves.AddRange(Game.FindAvailableMoves(gameTokens[j], gameTokens[j].row, gameTokens[j].col));
                                }
                            }
                            for (int j = 0; j < possibleBlockingMoves.Count; j++)
                            {
                                for (int k = 0; k < pathToKing.Count; k++)
                                {
                                    if (possibleBlockingMoves[j].row == pathToKing[k].row && possibleBlockingMoves[j].col == pathToKing[k].col)
                                    {
                                        HasBlockingToken = true;
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = true;
                                    }
                                }
                                if (HasBlockingToken)
                                {
                                    possibleBlockingMoves.Clear();
                                    pathToKing.Clear();
                                    break;
                                }
                            }
                        }
                    }
                }
                if (HasBlockingToken || !northWest)
                {
                    break;
                }

            }
            for (int i = 1; i < gameBoard.Length; i++)
            {
                southEast = row + i <= 7 && col + i <= 7;//qb
                if (southEast)
                {

                    if (gameBoard[row + i][col + i] == null)
                    {
                        pathToKing.Add(new Move(row + i, col + i));
                        continue;
                    }
                    else
                    {
                        pathToKing.Add(new Move(row + i, col + i));
                        if (gameBoard[row + i][col + i].GetType().Name == "Rook" || gameBoard[row + i][col + i].GetType().Name == "Knight" || gameBoard[row + i][col + i].color == color)
                        {
                            break;
                        }
                        else
                        {
                            for (int j = 0; j < gameTokens.Count; j++)
                            {
                                if (gameTokens[j] == this || gameTokens[j].GetType().Name == "King")
                                {
                                    continue;
                                }
                                else
                                {
                                    possibleBlockingMoves.AddRange(Game.FindAvailableMoves(gameTokens[j], gameTokens[j].row, gameTokens[j].col));
                                }
                            }
                            for (int j = 0; j < possibleBlockingMoves.Count; j++)
                            {
                                for (int k = 0; k < pathToKing.Count; k++)
                                {
                                    if (possibleBlockingMoves[j].row == pathToKing[k].row && possibleBlockingMoves[j].col == pathToKing[k].col)
                                    {
                                        HasBlockingToken = true;
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = true;
                                    }
                                }
                                if (HasBlockingToken)
                                {
                                    possibleBlockingMoves.Clear();
                                    pathToKing.Clear();
                                    break;
                                }
                            }
                        }
                    }
                }
                if (HasBlockingToken || !southEast)
                {
                    break;
                }

            }
            for (int i = 1; i < gameBoard.Length; i++)
            {
                southWest = row + i <= 7 && col - i >= 0;//qb
                if (southWest)
                {

                    if (gameBoard[row + i][col - i] == null)
                    {
                        pathToKing.Add(new Move(row + i, col - i));
                        continue;
                    }
                    else
                    {
                        pathToKing.Add(new Move(row + i, col - i));
                        if (gameBoard[row + i][col - i].GetType().Name == "Rook" || gameBoard[row + i][col - i].GetType().Name == "Knight" || gameBoard[row + i][col - i].color == color)
                        {
                            break;
                        }
                        else
                        {
                            for (int j = 0; j < gameTokens.Count; j++)
                            {
                                if (gameTokens[j] == this || gameTokens[j].GetType().Name == "King")
                                {
                                    continue;
                                }
                                else
                                {
                                    possibleBlockingMoves.AddRange(Game.FindAvailableMoves(gameTokens[j], gameTokens[j].row, gameTokens[j].col));
                                }
                            }
                            for (int j = 0; j < possibleBlockingMoves.Count; j++)
                            {
                                for (int k = 0; k < pathToKing.Count; k++)
                                {
                                    if (possibleBlockingMoves[j].row == pathToKing[k].row && possibleBlockingMoves[j].col == pathToKing[k].col)
                                    {
                                        HasBlockingToken = true;
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = true;
                                    }
                                }
                                if (HasBlockingToken)
                                {
                                    possibleBlockingMoves.Clear();
                                    pathToKing.Clear();
                                    break;
                                }
                            }
                        }
                    }
                }
                if (HasBlockingToken || !southWest)
                {
                    break;
                }

            }

            return check;
        }
    }
}
