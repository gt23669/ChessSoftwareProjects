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
        static List<Piece> pieces = new List<Piece>();
        internal static void Menu(string[] args)
        {
            bool exit = false;
            do
            {

                string[] options = new string[] { "Setup Board", "Move" };
                int choiceOption;
                choiceOption = CIO.PromptForMenuSelection(options, true);
                int choiceFile;
                string file;


                switch (choiceOption)
                {
                    case 1:
                        Console.WriteLine("Which file will you use?");
                        choiceFile = CIO.PromptForMenuSelection(args, false);
                        file = args[choiceFile - 1];
                        gameBoard = board.GenerateBoard();
                        setupBoard(file);
                        board.fillBoard(pieces);
                        board.printNewBoard(gameBoard);
                        break;
                    case 2:
                        Console.WriteLine("Which file will you use?");
                        choiceFile = CIO.PromptForMenuSelection(args, false);
                        file = args[choiceFile - 1];
                        string[] pieceMovments = readInPieces(file);
                        move(pieceMovments);
                        break;
                    case 0:
                        exit = !exit;
                        break;
                }
            } while (!exit);
        }

        private static void setupBoard(string args)
        {

            string content = File.ReadAllText(args);
            content = content.ToUpper();
            string[] SplitArray = Regex.Split(content, "[\r\n]+");
            for (int i = 0; i < SplitArray.Length; i++)
            {
                char type = SplitArray[i][0]; //Piece type
                char color = SplitArray[i][1];//Color               
                int y = 0; //YLocation
                int x = 0; //XLocation
                string tempY;
                if (SplitArray[i][0] == 'K')
                {
                    if (SplitArray[i][0 + 1] == 'N')
                    {
                        color = SplitArray[i][2];
                        tempY = SplitArray[i][3].ToString();
                        int.TryParse(tempY, out y);
                        x = convertX(SplitArray[i][4]);
                        Piece knight = new Knight(color, x, y);
                        if (knight.color == 'D')
                        {
                            knight.ID = knight.ID.ToLower();
                        }
                        pieces.Add(knight);
                        continue;

                    }
                }

                switch (SplitArray[i][0])
                {

                    case 'B':
                        color = SplitArray[i][1];
                        tempY = SplitArray[i][2].ToString();
                        int.TryParse(tempY, out y);
                        x = convertX(SplitArray[i][3]);
                        Piece bishop = new Bishop(color, x, y);
                        if (bishop.color == 'D')
                        {
                            bishop.ID = bishop.ID.ToLower();
                        }
                        pieces.Add(bishop);
                        break;
                    case 'K':
                        color = SplitArray[i][1];
                        tempY = SplitArray[i][2].ToString();
                        int.TryParse(tempY, out y);
                        x = convertX(SplitArray[i][3]);
                        Piece king = new King(color, x, y);
                        if (king.color == 'D')
                        {
                            king.ID = king.ID.ToLower();
                        }
                        pieces.Add(king);
                        break;
                    case 'P':
                        color = SplitArray[i][1];
                        tempY = SplitArray[i][2].ToString();
                        int.TryParse(tempY, out y);
                        x = convertX(SplitArray[i][3]);
                        Piece pawn = new Pawn(color, x, y);
                        if (pawn.color == 'D')
                        {
                            pawn.ID = pawn.ID.ToLower();
                        }
                        pieces.Add(pawn);
                        break;
                    case 'Q':
                        color = SplitArray[i][1];
                        tempY = SplitArray[i][2].ToString();
                        int.TryParse(tempY, out y);
                        x = convertX(SplitArray[i][3]);
                        Piece queen = new Queen(color, x, y);
                        if (queen.color == 'D')
                        {
                            queen.ID = queen.ID.ToLower();
                        }
                        pieces.Add(queen);
                        break;
                    case 'R':
                        color = SplitArray[i][1];
                        tempY = SplitArray[i][2].ToString();
                        int.TryParse(tempY, out y);
                        x = convertX(SplitArray[i][3]);
                        Piece rook = new Rook(color, x, y);
                        if (rook.color == 'D')
                        {
                            rook.ID = rook.ID.ToLower();
                        }
                        pieces.Add(rook);
                        break;
                }

            }

        }


        public static void move(string[] SplitArray)
        {
            for (int i = 0; i < SplitArray.Length && i < 8100; i++)
            {
                //Piece MovedPiece = null;

                int currentCol = convertX(SplitArray[i][0]);
                int currentRow;
                int.TryParse(SplitArray[i][1].ToString(), out currentRow);
                int nextCol = convertX(SplitArray[i][2]);
                int NextRow;
                int.TryParse(SplitArray[i][3].ToString(), out NextRow);
                //Console.WriteLine($"count = {i}");
                if (SplitArray[i] == "" || currentRow > 7 || currentCol > 7 || nextCol > 7 || NextRow > 7)
                {
                    continue;
                }
                else
                {
                    if (gameBoard[currentRow][currentCol] != null)
                    {
                        if (gameBoard[currentRow][currentCol].Check(gameBoard, NextRow, nextCol))
                        {
                            board.printNewBoard(gameBoard);
                            Console.WriteLine();
                            //Piece temp = gameBoard[currentRow][currentCol];
                            gameBoard[NextRow][nextCol] = gameBoard[currentRow][currentCol];
                            gameBoard[currentRow][currentCol] = null;
                            gameBoard[NextRow][nextCol].row = NextRow;
                            gameBoard[NextRow][nextCol].col = nextCol;
                            board.printNewBoard(gameBoard);
                        }

                    }
                    else
                    {
                        Console.WriteLine("There is no piece to move");
                    }
                    //if (gameBoard[currentRow][currentCol]!=null)
                    //{
                    //    Console.WriteLine(i);
                    //    Piece temp = gameBoard[currentRow][currentCol];
                    //    gameBoard[currentRow][currentCol] = null;
                    //    gameBoard[NextRow][nextCol] = temp;
                    //    board.printNewBoard(gameBoard);
                    //    Console.WriteLine();
                    //}
                    //else
                    //{
                    //    continue;
                    //}
                }


            }
            board.printNewBoard(gameBoard);
            Console.WriteLine("Final move complete");
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


        private static string[] readInPieces(string args)
        {

            string content = File.ReadAllText(args);
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
                        if ((doubleString[j][0] != 'I') && (doubleString[j][3] != 'I'))
                        {
                            temp.Add(doubleString[j]);
                        }

                    }


                }
                else
                {
                    if ((SplitArray[i][0] != 'I') && (SplitArray[i][3] != 'I'))
                    {
                        temp.Add(SplitArray[i]);
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



