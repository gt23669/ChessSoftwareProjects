using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Chess.MVC.Model;
using CSC160_ConsoleMenu;

namespace Chess.MVC.Controller
{
    class PlayGame
    {
        static Person player1 = new Player1();
        static Person player2 = new Player2();
        static string[] playerMovments;
        static Piece[][] gameBoard = GameSetup.getGameBoard();

        public static void playGame()
        {

            List<Piece> playerPieces = GameSetup.getAllPieces();
            sortPlayerPieceList(playerPieces);

            bool exit = false;
            do
            {
                if (player1.isInCheck)
                {
                    if (player1.isInCheckMate)
                    {
                        Console.WriteLine("Player1, you have lost. You are in CheckMate");
                        exit = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Player1, you are in Check");
                    }
                }
                else if (player2.isInCheck)
                {
                    if (player2.isInCheckMate)
                    {
                        Console.WriteLine("Player2, you have lost. You are in CheckMate");
                        exit = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Player2, you are in Check");
                    }
                }

                playTurn(player1.isTurn ? true : false);





            } while (!exit);
        }

        private static void playTurn(bool player)
        {
            Person tempPlayer = player ? player1 : player2;

            GameSetup.printBoard(gameBoard);
            Console.WriteLine();
            Console.WriteLine($"{tempPlayer.name}, it is your turn. Select your token to move...");
            string[] temp = new string[tempPlayer.moveablePieces.Count];
            for (int i = 0; i < tempPlayer.moveablePieces.Count; i++)
            {
                //Console.WriteLine($"{player1.moveablePieces[i].name} col: {player1.moveablePieces[i].col} row: {player1.moveablePieces[i].row}");
                temp[i] = $"{tempPlayer.moveablePieces[i].name} col: {convertCol(tempPlayer.moveablePieces[i].col + 65)} row: {tempPlayer.moveablePieces[i].row + 1}";
            }
            int pieceChoice = CIO.PromptForMenuSelection(temp, false);

            int col = tempPlayer.moveablePieces[pieceChoice - 1].col;
            int row = tempPlayer.moveablePieces[pieceChoice - 1].row;
            FindAvailableMoves(tempPlayer.moveablePieces[pieceChoice], row, col);
            List<Move> tempMoves = new List<Move>();
            for (int i = 0; i < gameBoard[row][col].availableMoves.Count; i = i + 2)
            {
                tempMoves.Add(new Move(gameBoard[row][col].availableMoves[i], gameBoard[row][col].availableMoves[i + 1]));
            }
            temp = new string[tempMoves.Count];
            for (int i = 0; i < tempMoves.Count; i++)
            {
                temp[i] = $"Col: {convertCol(tempMoves[i].col + 65)} Row: {tempMoves[i].row + 1}";
            }
            Console.WriteLine("Select a move to make...");
            int moveChoice = CIO.PromptForMenuSelection(temp, false);

            gameBoard[tempMoves[moveChoice - 1].row][tempMoves[moveChoice - 1].col] = gameBoard[row][col];
            gameBoard[row][col] = null;
            GameSetup.printBoard(gameBoard);
            turnFlip();
        }

        private static void FindAvailableMoves(Piece piece, int row, int col)
        {
            int nRow;
            int nCol;
            for (int i = 1; i < gameBoard.Length; i++)
            {
                switch (piece.GetType().Name)
                {
                    case "Pawn":
                        if (piece.color == 'L')
                        {
                            nRow = row - i;
                            nCol = col;
                            if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                            {
                                gameBoard[row][col].availableMoves.Add(nRow);
                                gameBoard[row][col].availableMoves.Add(nCol);
                            }

                            nCol = col + i;//northeast
                            if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                            {
                                gameBoard[row][col].availableMoves.Add(nRow);
                                gameBoard[row][col].availableMoves.Add(nCol);
                            }

                            nCol = col - i;//northwest
                            if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                            {
                                gameBoard[row][col].availableMoves.Add(nRow);
                                gameBoard[row][col].availableMoves.Add(nCol);
                            }

                        }
                        else
                        {
                            nRow = row + i;
                            nCol = col;
                            if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                            {
                                gameBoard[row][col].availableMoves.Add(nRow);
                                gameBoard[row][col].availableMoves.Add(nCol);
                            }
                            nCol = col + i;//southeast
                            if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                            {
                                gameBoard[row][col].availableMoves.Add(nRow);
                                gameBoard[row][col].availableMoves.Add(nCol);
                            }

                            nCol = col - i;//southwest
                            if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                            {
                                gameBoard[row][col].availableMoves.Add(nRow);
                                gameBoard[row][col].availableMoves.Add(nCol);
                            }

                        }


                        break;
                    case "Rook":
                        //north
                        nRow = row - i;
                        nCol = col;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //south
                        nRow = row + i;
                        nCol = col;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //east
                        nRow = row;
                        nCol = col + i;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //west
                        nRow = row;
                        nCol = col - i;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        break;
                    case "Knight":
                        //northEastRow
                        nRow = row - 2;
                        nCol = col + 1;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //northEastCol
                        nRow = row - 1;
                        nCol = col + 2;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //northWestRow
                        nRow = row - 2;
                        nCol = col - 1;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //northWestCol
                        nRow = row - 1;
                        nCol = col - 2;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //southEastRow
                        nRow = row + 2;
                        nCol = col + 1;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //southEastCol
                        nRow = row + 1;
                        nCol = col + 2;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //southWestRow
                        nRow = row + 2;
                        nCol = col - 1;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        //southWestCol
                        nRow = row + 1;
                        nCol = col - 2;
                        if (gameBoard[row][col].Check(gameBoard, nRow, nCol))
                        {
                            gameBoard[row][col].availableMoves.Add(nRow);
                            gameBoard[row][col].availableMoves.Add(nCol);
                        }
                        break;
                    case "Bishop":

                        break;
                    case "King":
                        break;
                    case "Queen":
                        break;
                }
            }

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

        private static void sortPlayerPieceList(List<Piece> playerPieces)
        {
            for (int i = 0; i < playerPieces.Count; i++)
            {
                if (playerPieces[i].color == 'L')
                {
                    player1.moveablePieces.Add(playerPieces[i]);
                }
                else
                {
                    player2.moveablePieces.Add(playerPieces[i]);
                }
            }
        }

        private static void movePiece()
        {
            //bool exit = false;
            //do
            //{
            //    //GameSetup.printBoard(gameBoard);
            //    //Console.WriteLine();
            //    int currentCol = GameSetup.convertX(playerMovments[index][0]);
            //    int.TryParse(playerMovments[index][1].ToString(), out int currentRow);
            //    int nextCol = GameSetup.convertX(playerMovments[index][2]);
            //    int.TryParse(playerMovments[index][3].ToString(), out int NextRow);

            //    if (gameBoard[currentRow][currentCol] != null)
            //    {
            //        Console.WriteLine($"Attempting to move {(player1.isTurn ? player1.name : player2.name)}'s {gameBoard[currentRow][currentCol].name} from col:{currentCol} row:{currentRow} to col:{nextCol} row:{NextRow} ");
            //        if (gameBoard[currentRow][currentCol].Check(gameBoard, NextRow, nextCol))
            //        {
            //            Console.WriteLine($"{(player1.isTurn ? player1.name : player2.name)}'s {gameBoard[currentRow][currentCol].name} from col:{currentCol} row:{currentRow} moved to col:{nextCol} row:{NextRow} ");
            //            gameBoard[NextRow][nextCol] = gameBoard[currentRow][currentCol];
            //            gameBoard[currentRow][currentCol] = null;
            //            gameBoard[NextRow][nextCol].row = NextRow;
            //            gameBoard[NextRow][nextCol].col = nextCol;
            //            exit = true;

            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("There is no piece to move");
            //        index++;
            //    }

            //} while (!exit);


            //Console.WriteLine();
            //GameSetup.printBoard(gameBoard);
            //Console.WriteLine();
        }

        public static void turnFlip(int i = 0)
        {
            if (player1.isTurn)
            {
                player1.moveIndex = i + 1;
            }
            else
            {
                player2.moveIndex = i + 1;
            }
            player1.isTurn = !player1.isTurn;
            player2.isTurn = !player2.isTurn;
        }
        public static int MoveNumber()
        {
            if (player1.isTurn)
            {
                return player1.moveIndex;
            }
            else
            {
                return player2.moveIndex;
            }
        }
        private static string[] readPlayerMoves(string file)
        {
            string content = File.ReadAllText(file);
            content = content.ToUpper();

            string[] SplitArray = Regex.Split(content, "[\r\n]+");
            List<string> temp = new List<string>();
            for (int i = 0; i < SplitArray.Length; i++)
            {

                if (SplitArray[i].Length == 11)
                {
                    string x = SplitArray[i].Substring(0, 5);
                    string y = SplitArray[i].Substring(6, 5);
                    string[] doubleString = new string[] { x, y };
                    for (int j = 0; j < 2; j++)
                    {
                        int.TryParse(doubleString[i][1].ToString(), out int temp1);
                        int.TryParse(doubleString[i][4].ToString(), out int temp4);
                        if (doubleString[i][1] < 8 && doubleString[i][4] < 8)
                        {

                            if ((doubleString[j][0] != 'I') && (doubleString[j][3] != 'I'))
                            {
                                temp.Add(doubleString[j]);
                            }
                        }

                    }


                }
                else
                {
                    int.TryParse(SplitArray[i][1].ToString(), out int temp1);
                    int.TryParse(SplitArray[i][4].ToString(), out int temp4);
                    if (temp1 < 8 && temp4 < 8)
                    {

                        if ((SplitArray[i][0] != 'I') && (SplitArray[i][3] != 'I'))
                        {
                            temp.Add(SplitArray[i]);
                        }
                    }

                }
            }

            for (int i = 0; i < temp.Count; i++)
            {
                temp[i] = temp[i].Replace(" ", "");
            }


            SplitArray = temp.ToArray();
            return SplitArray;
        }
    }
}
