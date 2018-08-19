using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSC160_ConsoleMenu;
using Chess.MVC.Model;

namespace Chess.MVC.Controller
{
    class GameSetup
    {
        static Board board = new Board();
        static Piece[][] gameBoard = new Piece[8][];
        static List<Piece> allPieces;
        static King LKing;
        static King DKing;



        internal static void SetupGame(string[] args)
        {
            gameBoard = board.GenerateBoard();
            setupBoard(args);
            board.FillBoard(allPieces, gameBoard);
            board.printNewBoard(gameBoard);
        }

        private static void setupBoard(string[] allArgs)
        {
            allPieces = new List<Piece>();
            List<string> args = new List<string>();
            for (int i = 0; i < allArgs.Length; i++)
            {
                if (allArgs[i].Contains("Default"))
                {
                    args.Add(allArgs[i]);
                }

            }

            Console.WriteLine("Which file are you using?");
            string[] options = args.ToArray();
            int selection = CIO.PromptForMenuSelection(options, false);

            string fileContent;
            fileContent = File.ReadAllText(options[selection - 1]);
            fileContent = fileContent.ToUpper();

            string[] SplitArray = Regex.Split(fileContent, "[\r\n]+");

            for (int i = 0; i < SplitArray.Length; i++)
            {
                allPieces.Add(CreatePiece(SplitArray[i]));
                if (allPieces[i].GetType().Name == "King")
                {
                    if (allPieces[i].color == 'L')
                    {
                        LKing = (King)allPieces[i];
                    }
                    else
                    {
                        DKing = (King)allPieces[i];
                    }
                }
            }

        }

        internal static void moveTest(string[] args)
        {
            string[] pieceMovments = readInPieces(args);
            movePiecesTest(pieceMovments);
        }

        private static void movePiecesTest(string[] pieceMovments)
        {
            for (int i = 0; i < pieceMovments.Length; i++)
            {
                int currentCol = convertX(pieceMovments[i][0]);
                int.TryParse(pieceMovments[i][1].ToString(), out int currentRow);
                int nextCol = convertX(pieceMovments[i][2]);
                int.TryParse(pieceMovments[i][3].ToString(), out int NextRow);


                if (gameBoard[currentRow][currentCol] != null)
                {
                    //Console.WriteLine($"Attempting to move {gameBoard[currentRow][currentCol].color} {gameBoard[currentRow][currentCol].name} from col:{currentCol} row:{currentRow} to col:{nextCol} row:{NextRow} ");
                    if (gameBoard[currentRow][currentCol].Check(gameBoard, NextRow, nextCol))
                    {
                        Console.WriteLine($"{gameBoard[currentRow][currentCol].color} {gameBoard[currentRow][currentCol].name} from col:{currentCol} row:{currentRow} moved to col:{nextCol} row:{NextRow} ");
                        gameBoard[NextRow][nextCol] = gameBoard[currentRow][currentCol];
                        gameBoard[currentRow][currentCol] = null;
                        gameBoard[NextRow][nextCol].row = NextRow;
                        gameBoard[NextRow][nextCol].col = nextCol;
                        Console.WriteLine();
                        board.printNewBoard(gameBoard);

                        if (LKing.detectCheck(gameBoard))
                        {
                            Console.WriteLine("White King in Check");
                            if (LKing.detectCheckMate(gameBoard))
                            {
                                Console.WriteLine("White King in CheckMate");
                                break;
                            }

                        }
                        else if (DKing.detectCheck(gameBoard))
                        {
                            Console.WriteLine("Black King in Check");
                            if (DKing.detectCheckMate(gameBoard))
                            {
                                Console.WriteLine("Black King in CheckMate");
                                break;
                            }
                        }

                        //Console.WriteLine($"Light King in check: {LKing.detectCheck(gameBoard)}" + $"\nDark King in check: {DKing.detectCheck(gameBoard)}");
                    }

                }
                else
                {

                    Console.WriteLine("There is no piece to move");
                }


            }
            Console.WriteLine();
            board.printNewBoard(gameBoard);
        }




        public static string[] readInPieces(string[] allArgs)
        {
            List<string> argList = new List<string>();
            for (int i = 0; i < allArgs.Length; i++)
            {
                if (allArgs[i].Contains("Move"))
                {
                    argList.Add(allArgs[i]);
                }
            }
            Console.WriteLine("Which test file are you using?");
            int choice = CIO.PromptForMenuSelection(argList.ToArray(), false);

            string content = File.ReadAllText(argList[choice - 1]);
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


        public static Piece CreatePiece(string stringPiece)
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

        public static int convertX(char tempX)
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

        public static Piece[][] getGameBoard()
        {
            return gameBoard;
        }
        public static void printBoard(Piece[][] gameBoard)
        {
            board.printNewBoard(gameBoard);
        }
        public static List<Piece> getAllPieces()
        {
            return allPieces;
        }

    }
}