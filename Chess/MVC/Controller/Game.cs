using Chess.MVC.Model;
using Chess.MVC.Model.Player;
using Chess.MVC.Model.Tokens;
using CSC160_ConsoleMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Chess.MVC.Controller
{
    class Game
    {
        static Piece[][] gameBoard;
        static List<Piece> gameTokens = new List<Piece>();
        static Person player1;
        static Person player2;
        static King LKing;
        static King DKing;
        public static void gameSetup(string[] args)
        {
            gameBoard = Board.GenerateBoard();
            //Board.PrintBoard(gameBoard);
            gameBoard = FillBoard(args, gameBoard);
            //Board.PrintBoard(gameBoard);
            playGame();
        }

        private static void playGame()
        {
            player1 = new Player1();
            player2 = new Player2();

            GetPlayerTokens(gameTokens);

            bool exit = false;
            do
            {

                if (LKing.IsInCheck)
                {
                    if (LKing.IsInCheckMate)
                    {
                        Console.WriteLine("Player1, you have lost. You are in CheckMate...");
                        exit = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Player1, you are in Check...");
                    }
                }
                else if (DKing.IsInCheck)
                {
                    if (DKing.IsInCheckMate)
                    {
                        Console.WriteLine("Player2, you have lost. You are in CheckMate...");
                        exit = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Player2, you are in Check...");
                    }
                }
                player1.playerTokens.Clear();
                player2.playerTokens.Clear();
                GetPlayerTokens(gameTokens);
                playTurn(player1.isTurn ? true : false);
            } while (!exit);

        }

        private static void playTurn(bool turnCheck)
        {
            Person tempPlayer = turnCheck ? player1 : player2;
            Console.WriteLine($"{tempPlayer.name}, it is your turn...");
            Console.WriteLine();
            Board.PrintBoard(gameBoard);

            //show list of available tokens to move based on valid moves of each piece
            //show a list of valid moves of selected token
            //end on checkmate
            //include pawn promotion

            for (int i = 0; i < tempPlayer.playerTokens.Count; i++)
            {
                Piece tempPiece = tempPlayer.playerTokens[i];
                //Console.WriteLine($"Finding moves for {tempPiece.color}{tempPiece.name}");
                FindAvailableMoves(tempPiece, tempPiece.row, tempPiece.col);
                //Console.WriteLine($"Found moves for {tempPiece.color}{tempPiece.name}");
            }

            List<string> strListAvailablePieces = new List<string>();
            List<Piece> moveableTokens = new List<Piece>();
            for (int i = 0; i < tempPlayer.playerTokens.Count; i++)
            {
                if (tempPlayer.playerTokens[i].moves.Count > 0)
                {
                    strListAvailablePieces.Add($"{tempPlayer.playerTokens[i].name} at {convertCol(tempPlayer.playerTokens[i].col + 65)}{tempPlayer.playerTokens[i].row + 1}");
                    moveableTokens.Add(tempPlayer.playerTokens[i]);
                }
            }
            Console.WriteLine($"{tempPlayer.name}, what token will you play?");
            Console.WriteLine();
            int choice = CIO.PromptForMenuSelection(strListAvailablePieces.ToArray(), false);
            Piece selectedToken = moveableTokens[choice - 1];


            //List each move available to selected token
            List<string> strTokenMoves = new List<string>();
            for (int i = 0; i < moveableTokens[choice - 1].moves.Count; i++)
            {
                strTokenMoves.Add($"{moveableTokens[choice - 1].name} at {convertCol(moveableTokens[choice - 1].col + 65)}{moveableTokens[choice - 1].row + 1} to {convertCol(moveableTokens[choice - 1].moves[i].col + 65)}{moveableTokens[choice - 1].moves[i].row + 1}");
            }
            Console.WriteLine("Where would you like to move to?");
            choice = CIO.PromptForMenuSelection(strTokenMoves.ToArray(), false);
            int selectedRow = selectedToken.moves[choice - 1].row;
            int selectedCol = selectedToken.moves[choice - 1].col;

            //gameBoard[selectedRow][selectedCol] = gameBoard[selectedToken.row][selectedToken.col];
            gameBoard[selectedRow][selectedCol] = selectedToken;


            if (selectedToken.GetType().Name == "Pawn")
            {
                if (((Pawn)selectedToken).firstMove == false)
                {
                    ((Pawn)selectedToken).firstMove = true;
                }
                if (selectedRow == 7 || selectedRow == 0)
                {
                    char Pcolor;
                    int Pcol;
                    int Prow;
                    if (selectedRow == 7)
                    {
                        Pcolor = 'D';
                        Prow = 7;
                        Pcol = selectedToken.col;
                    }
                    else
                    {
                        Pcolor = 'L';
                        Prow = 0;
                        Pcol = selectedToken.col;
                    }
                    string[] options = new string[] { "Rook", "Knight", "Bishop", "Queen" };
                    Console.WriteLine("Which piece to you want to promote your pawn to?");
                    int promotionChoice = CIO.PromptForMenuSelection(options, false);
                    switch (promotionChoice)
                    {
                        case 1:
                            Piece promotedRook = new Rook(Pcolor, Pcol, Prow);
                            gameBoard[selectedRow][selectedCol] = promotedRook;
                            break;
                        case 2:
                            Piece promotedKnight = new Knight(Pcolor, Pcol, Prow);
                            gameBoard[selectedRow][selectedCol] = promotedKnight;
                            break;
                        case 3:
                            Piece promotedBishop = new Bishop(Pcolor, Pcol, Prow);
                            gameBoard[selectedRow][selectedCol] = promotedBishop;
                            break;
                        case 4:
                            Piece promotedQueen = new Queen(Pcolor, Pcol, Prow);
                            gameBoard[selectedRow][selectedCol] = promotedQueen;
                            break;
                    }
                    for (int i = 0; i < gameTokens.Count; i++)
                    {
                        if (gameTokens[i].row == selectedToken.row && gameTokens[i].col == selectedToken.col)
                        {
                            gameTokens[i] = gameBoard[selectedRow][selectedCol];
                            break;
                        }
                    }
                }
            }

            gameBoard[selectedToken.row][selectedToken.col] = null;
            selectedToken.row = selectedRow;
            selectedToken.col = selectedCol;

            Console.WriteLine();
            //Board.PrintBoard(gameBoard);
            turnFlip();


            //check to see if any token can move to the path the checking token is using to check the king
            if (LKing.detectCheck(gameBoard, gameTokens, selectedToken))
            {
                LKing.IsInCheck = true;
                //Console.WriteLine("White King in Check");
                if (LKing.HasBlockingToken)
                {
                    DKing.IsInCheckMate = false;
                }
                else
                {
                    LKing.IsInCheckMate = true;
                    //Console.WriteLine("White King in CheckMate");
                }

            }
            else
            {
                LKing.IsInCheck = false;
            }

            if (DKing.detectCheck(gameBoard, gameTokens, selectedToken))
            {
                //Console.WriteLine("check");
                DKing.IsInCheck = true;
                //Console.WriteLine("Black King in Check");
                if (DKing.HasBlockingToken)
                {
                    DKing.IsInCheckMate = false;
                }
                else
                {
                    DKing.IsInCheckMate = true;
                    //Console.WriteLine("Black King in CheckMate");
                }
            }
            else
            {
                DKing.IsInCheck = false;
            }

        }

        private static void turnFlip()
        {
            player1.isTurn = !player1.isTurn;
            player2.isTurn = !player2.isTurn;
        }

        private static object convertCol(int col)
        {
            switch (col)
            {
                case 65:
                    return 'A';
                case 66:
                    return 'B';
                case 67:
                    return 'C';
                case 68:
                    return 'D';
                case 69:
                    return 'E';
                case 70:
                    return 'F';
                case 71:
                    return 'G';
                case 72:
                    return 'H';
            }
            return col;
        }

        public static List<Move> FindAvailableMoves(Piece piece, int row, int col)
        {
            int nRow;
            int nCol;
            piece.moves.Clear();
            List<Move> tempMoves = new List<Move>();
            if (piece.GetType().Name == "Knight")
            {
                //northEastRow
                nRow = row - 2;
                nCol = col + 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));
                }
                //northEastCol
                nRow = row - 1;
                nCol = col + 2;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //northWestRow
                nRow = row - 2;
                nCol = col - 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //northWestCol
                nRow = row - 1;
                nCol = col - 2;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //southEastRow
                nRow = row + 2;
                nCol = col + 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //southEastCol
                nRow = row + 1;
                nCol = col + 2;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //southWestRow
                nRow = row + 2;
                nCol = col - 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //southWestCol
                nRow = row + 1;
                nCol = col - 2;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
            }
            else if (piece.GetType().Name == "Pawn")
            {
                if (piece.color == 'L')
                {

                    for (int i = 1; i < 3; i++)
                    {
                        nRow = row - i;
                        nCol = col;
                        if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                        {
                            piece.moves.Add(new Move(nRow, nCol));
                            tempMoves.Add(new Move(nRow, nCol));

                        }

                    }

                    nRow = row - 1;
                    nCol = col + 1;//northeast
                    if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                    {
                        piece.moves.Add(new Move(nRow, nCol));
                        tempMoves.Add(new Move(nRow, nCol));

                    }

                    nCol = col - 1;//northwest
                    if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                    {
                        piece.moves.Add(new Move(nRow, nCol));
                        tempMoves.Add(new Move(nRow, nCol));

                    }

                }
                else
                {
                    for (int i = 1; i < 3; i++)
                    {
                        nRow = row + i;
                        nCol = col;
                        if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                        {
                            piece.moves.Add(new Move(nRow, nCol));
                            tempMoves.Add(new Move(nRow, nCol));

                        }

                    }

                    nRow = row + 1;
                    nCol = col + 1;//southeast
                    if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                    {
                        piece.moves.Add(new Move(nRow, nCol));
                        tempMoves.Add(new Move(nRow, nCol));

                    }

                    nCol = col - 1;//southwest
                    if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                    {
                        piece.moves.Add(new Move(nRow, nCol));
                        tempMoves.Add(new Move(nRow, nCol));

                    }

                }
            }
            else if (piece.GetType().Name == "King")
            {
                //north
                nRow = row - 1;
                nCol = col;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //south
                nRow = row + 1;
                nCol = col;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //east
                nRow = row;
                nCol = col + 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //west
                nRow = row;
                nCol = col - 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //northEast
                nRow = row - 1;
                nCol = col + 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //northWest
                nRow = row - 1;
                nCol = col - 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //southEast
                nRow = row + 1;
                nCol = col + 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
                //southWest
                nRow = row + 1;
                nCol = col - 1;
                if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                {
                    piece.moves.Add(new Move(nRow, nCol));
                    tempMoves.Add(new Move(nRow, nCol));

                }
            }
            else
            {


                for (int i = 1; i < gameBoard.Length; i++)
                {
                    switch (piece.GetType().Name)
                    {

                        case "Rook":
                            //north
                            nRow = row - i;
                            nCol = col;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //south
                            nRow = row + i;
                            nCol = col;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //east
                            nRow = row;
                            nCol = col + i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //west
                            nRow = row;
                            nCol = col - i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            break;
                        case "Bishop":
                            //northEast
                            nRow = row - i;
                            nCol = col + i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //northWest
                            nRow = row - i;
                            nCol = col - i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //southEast
                            nRow = row + i;
                            nCol = col + i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //southWest
                            nRow = row + i;
                            nCol = col - i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            break;
                        case "Queen":
                            //north
                            nRow = row - i;
                            nCol = col;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //south
                            nRow = row + i;
                            nCol = col;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //east
                            nRow = row;
                            nCol = col + i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //west
                            nRow = row;
                            nCol = col - i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //northEast
                            nRow = row - i;
                            nCol = col + i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //northWest
                            nRow = row - i;
                            nCol = col - i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //southEast
                            nRow = row + i;
                            nCol = col + i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            //southWest
                            nRow = row + i;
                            nCol = col - i;
                            if (gameBoard[row][col] != null && gameBoard[row][col].CheckValidMove(gameBoard, gameTokens, nRow, nCol, false))
                            {
                                piece.moves.Add(new Move(nRow, nCol));
                                tempMoves.Add(new Move(nRow, nCol));

                            }
                            break;
                    }
                }
            }
            return tempMoves;
        }

        private static Piece[][] FillBoard(string[] args, Piece[][] gameBoard)
        {

            string fileContent;
            fileContent = File.ReadAllText(args[0]);
            fileContent = fileContent.ToUpper();
            string[] SplitArray = Regex.Split(fileContent, "[\r\n]+");

            for (int i = 0; i < SplitArray.Length; i++)
            {
                gameTokens.Add(CreatePiece(SplitArray[i]));
                if (gameTokens[i].GetType().Name == "King")
                {
                    if (gameTokens[i].color == 'L')
                    {
                        LKing = (King)gameTokens[i];
                    }
                    else
                    {
                        DKing = (King)gameTokens[i];
                    }
                }
            }

            for (int i = 0; i < gameTokens.Count; i++)
            {
                int col;
                int row;
                col = gameTokens[i].col;
                row = gameTokens[i].row;

                gameBoard[row][col] = gameTokens[i];
            }

            return gameBoard;
        }

        private static Piece CreatePiece(string stringPiece)
        {
            for (int i = 0; i < stringPiece.Length; i++)
            {

                char type = stringPiece[0];
                char color = stringPiece[1];
                int col = convertX(stringPiece[2]);
                int.TryParse(stringPiece[3].ToString(), out int row);
                switch (type)
                {
                    case 'P':
                        Piece Pawn = new Pawn(color, col, row);
                        if (color == 'D')
                        {
                            Pawn.ID = Pawn.ID.ToLower();

                        }
                        else
                        {

                        }
                        return Pawn;
                    case 'R':
                        Piece Rook = new Rook(color, col, row);
                        if (color == 'D')
                        {
                            Rook.ID = Rook.ID.ToLower();
                        }
                        else
                        {

                        }
                        return Rook;
                    case 'N':
                        Piece Knight = new Knight(color, col, row);
                        if (color == 'D')
                        {
                            Knight.ID = Knight.ID.ToLower();
                        }
                        else
                        {

                        }
                        return Knight;
                    case 'B':
                        Piece Bishop = new Bishop(color, col, row);
                        if (color == 'D')
                        {
                            Bishop.ID = Bishop.ID.ToLower();
                        }
                        else
                        {

                        }
                        return Bishop;
                    case 'K':
                        Piece King = new King(color, col, row);
                        if (color == 'D')
                        {
                            King.ID = King.ID.ToLower();
                        }
                        else
                        {

                        }
                        return King;
                    case 'Q':
                        Piece Queen = new Queen(color, col, row);
                        if (color == 'D')
                        {
                            Queen.ID = Queen.ID.ToLower();
                        }
                        else
                        {

                        }
                        return Queen;

                }
            }
            return null;
        }

        private static int convertX(char tempX)
        {
            int x = 0;
            switch (tempX)
            {
                case 'A':
                    //x = 2;
                    x = 0;
                    break;
                case 'B':
                    //x = 6;
                    x = 1;
                    break;
                case 'C':
                    //x = 10;
                    x = 2;
                    break;
                case 'D':
                    //x = 14;
                    x = 3;
                    break;
                case 'E':
                    //x = 18;
                    x = 4;
                    break;
                case 'F':
                    //x = 22;
                    x = 5;
                    break;
                case 'G':
                    //x = 26;
                    x = 6;
                    break;
                case 'H':
                    //x = 30;
                    x = 7;
                    break;
            }
            return x;
        }

        private static void GetPlayerTokens(List<Piece> gameTokens)
        {
            for (int i = 0; i < gameTokens.Count; i++)
            {
                if (gameTokens[i].color == 'L')
                {
                    player1.playerTokens.Add(gameTokens[i]);
                    if (gameTokens[i].name == "King")
                    {
                        LKing = (King)gameTokens[i];
                    }
                }
                else
                {
                    player2.playerTokens.Add(gameTokens[i]);
                    if (gameTokens[i].name == "King")
                    {
                        DKing = (King)gameTokens[i];
                    }
                }
            }
        }
    }
}
