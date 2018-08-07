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
        static List<string> NewContent = new List<string>();
        public static List<Piece> Menu(string[] args)
        {
            List<Piece> pieces = new List<Piece>();
            List<string> newPositions = new List<string>();
            bool exit = false;
            do
            {

                string[] options = new string[] { "Game Setup", "Single Move", "Double Move" };
                int choice = CIO.PromptForMenuSelection(options, true);

                switch (choice)
                {
                    case 1:
                        if (args.Length > 1)
                        {
                            Console.WriteLine("Which file do you want to use?");
                            int fileChoice = CIO.PromptForMenuSelection(args, false);
                            string file = args[fileChoice - 1];
                            string[] tempArgs = new string[] { file };
                            Console.WriteLine(file);
                            pieces = Setup(tempArgs);
                        }
                        else
                        {
                            pieces = Setup(args);

                        }
                        return pieces;
                    case 2:
                        if (args.Length > 1)
                        {
                            Console.WriteLine("Which file do you want to use?");
                            int fileChoice = CIO.PromptForMenuSelection(args, false);
                            string file = args[fileChoice - 1];
                            string[] tempArgs = new string[] { file };
                            Console.WriteLine(file);
                            newPositions = Move(tempArgs);
                            movePieces(newPositions);

                        }
                        else
                        {
                            newPositions = Move(args);
                            movePieces(newPositions);

                        }
                        return null;
                    case 3:
                        if (args.Length > 1)
                        {
                            Console.WriteLine("Which file do you want to use?");
                            int fileChoice = CIO.PromptForMenuSelection(args, false);
                            string file = args[fileChoice - 1];
                            string[] tempArgs = new string[] { file };
                            Console.WriteLine(file);
                            DoubleMove(tempArgs);
                        }
                        else
                        {
                            DoubleMove(args);

                        }
                        return pieces;
                    case 0:
                        exit = true;
                        return pieces;
                }
            } while (!exit);
            return pieces;

        }

        

        public static List<Piece> Setup(string[] args)
        {
            List<Piece> pieces = new List<Piece>();
            if (args.Length > 0)
            {
                //Console.WriteLine("What is your file name");
                //string FilePath = Console.ReadLine();
                if (File.Exists(args[0]))
                {
                    string content = File.ReadAllText(args[0]);
                    content = content.ToUpper();
                    Console.WriteLine("Your Game Looks like: ");
                    string[] SplitArray = Regex.Split(content, "[\r\n]+");
                    for (int i = 0; i < SplitArray.Length; i++)
                    {
                        char type = SplitArray[i][0]; //Piece type
                        char color = SplitArray[i][1];
                        //Color
                        int y = 0; //YLocation
                        string tempY;
                        int x = 0; //XLocation
                        if (SplitArray[i][0] == 'K')
                        {
                            if (SplitArray[i][0 + 1] == 'N')
                            {
                                tempY = SplitArray[i][3].ToString();
                                int.TryParse(tempY, out y);
                                x = convertX(SplitArray[i][4]);
                                Piece knight = new Knight(color, x, y);
                                if (knight.color =='D')
                                {
                                    knight.ID = knight.ID.ToLower();
                                }
                                pieces.Add(knight);

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
                    Console.WriteLine(SplitArray[0][0]);
                    for (int i = 0; i < SplitArray.Length; i++)
                    {
                        if (SplitArray[i] == "")
                        {
                            break;
                        }
                        else
                        {

                            char[] CharSplit = SplitArray[i].ToCharArray();

                            placement(CharSplit);

                        }

                    }
                }
                return pieces;

            }
            else
            {

                Console.WriteLine("What is the new file name?");
                string input = Console.ReadLine();
                if (input.Length > 0)
                {
                    input += ".txt";
                    Console.WriteLine("How many things would you like to add to this new file");
                    string num = Console.ReadLine();
                    int ParseNum = 0;
                    bool hope = int.TryParse(num, out ParseNum);

                    if (hope && ParseNum > 0)
                    {
                        for (int i = 0; i < ParseNum; i++)
                        {
                            Console.WriteLine($"Piece {i + 1}([K,Q,R,B,N,P][l,d][Col][Row])");
                            NewContent.Add(Console.ReadLine());

                        }
                        File.WriteAllLines(input, NewContent.ToArray());
                    }
                    NewContent.Clear();

                }
                return pieces;
            }

            if (NewContent.Count > 0)
            {
                foreach (var item in NewContent)
                {
                    Console.WriteLine(item);
                }
                // File.WriteAllLines(FilePath, NewContent.ToArray());
            }
        }

        public static void placement(char[] lol)
        {

            string StringA = "";
            string Stringb = "";
            switch (lol[0])
            {
                case 'K':
                    StringA = "king";
                    break;
                case 'Q':
                    StringA = "Queen";
                    break;
                case 'B':
                    StringA = "Bishop";
                    break;
                case 'N':
                    StringA = "Knight";
                    break;
                case 'R':
                    StringA = "Rook";
                    break;
                case 'P':
                    StringA = "Pawn";
                    break;
            }


            if (lol[1] == 'L')
            {
                Stringb = "Light";
            }
            else
            {
                Stringb = "Dark";
            }

            NewContent.Add($" The {Stringb} {StringA} is placed on {lol[3]},{lol[2]} ");
        }
        public static List<string> Move(string[] args)
        {
            string[] SplitArray = null;
            //
            //put in validation at some point
            bool exit = false;
            do
            {

                if (args.Length > 0)
                {
                    if (File.Exists(args[0]))
                    {
                        string content = File.ReadAllText(args[0]);
                        content = content.ToUpper();
                        Console.WriteLine("Your Moves Looks like: ");
                        SplitArray = Regex.Split(content, "[\r\n]+");
                        string[] StringSplit;
                        for (int i = 0; i < SplitArray.Length; i++)
                        {
                            if (SplitArray[i] == "")
                            {

                            }
                            else
                            {
                                if (SplitArray[i].Contains(" "))
                                {
                                    SplitArray[i] = SplitArray[i].Replace(" ", "");
                                }
                                //StringSplit = SplitArray[i].Split(' ');
                                //for (int j = 0; j < StringSplit.Length; j++)
                                //{
                                //    Console.WriteLine($"The piece at {StringSplit[0]} moved to {StringSplit[1]}");
                                //}

                            }

                        }
                        exit = true;
                    }
                }
                else
                {
                    Console.WriteLine("There are no arguments");
                    string path = "./";
                    var allFiles = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                    for (int i = 0; i < allFiles.Length; i++)
                    {
                        //Console.WriteLine(allFiles[i]);
                        //Console.WriteLine(allFiles[i].Length);

                        allFiles[i] = allFiles[i].Substring(2, allFiles[i].Length - 2);
                    }
                    Console.WriteLine("Which file will you use?");
                    int choice = CIO.PromptForMenuSelection(allFiles, false);
                    Console.WriteLine(allFiles[choice - 1]);
                    args = new string[] { allFiles[choice - 1] };

                    //args[0].Insert(0,allFiles[choice-1]);
                }
            } while (!exit);



            List<string> tempList = SplitArray.ToList();
            return tempList;
        }

        public static void DoubleMove(string[] args)
        {
            bool exit = false;
            do
            {

                if (args.Length > 0)
                {
                    List<string> doubleMoveContent = new List<string>();

                    string content = File.ReadAllText(args[0]);
                    content = content.ToUpper();
                    Console.WriteLine("Your Game Looks like: ");
                    string[] SplitArray = Regex.Split(content, "[\r\n]+");
                    List<string> tempList = new List<string>();
                    for (int i = 0; i < SplitArray.Length; i++)
                    {
                        SplitArray[i] = SplitArray[i].Replace(" ", "");
                        //tempList.Add(SplitArray[i].Substring(0,4));
                        //tempList.Add(SplitArray[i].Substring(4, 4));
                        //Console.WriteLine(tempList[i]);
                        Console.WriteLine($"Piece at {SplitArray[i].Substring(0, 2)} is moving to {SplitArray[i].Substring(2, 2)} and {SplitArray[i].Substring(4, 2)} is moving to {SplitArray[i].Substring(6, 2)}");
                    }
                    exit = true;



                    //List<string> tempList = SplitArray.ToList();

                    //for (int i = 0; i < tempList.Count; i++)
                    //{
                    //    if (tempList[i].Contains("@"))
                    //    {
                    //        tempList.RemoveAt(i);

                    //    }
                    //}

                }
                else
                {

                    string path = "./";
                    var allFiles = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                    for (int i = 0; i < allFiles.Length; i++)
                    {
                        //Console.WriteLine(allFiles[i]);
                        //Console.WriteLine(allFiles[i].Length);

                        allFiles[i] = allFiles[i].Substring(2, allFiles[i].Length - 2);
                    }
                    Console.WriteLine("Which file will you use?");
                    int choice = CIO.PromptForMenuSelection(allFiles, false);
                    Console.WriteLine(allFiles[choice - 1]);
                    args = new string[] { allFiles[choice - 1] };

                    //args[0].Insert(0,allFiles[choice-1]);
                }
            } while (!exit);
        }

        public static int convertX(char tempX)
        {
            int x = 0;
            switch (tempX)
            {
                case 'A':
                    x = 0;
                    break;
                case 'B':
                    x = 1;
                    break;
                case 'C':
                    x = 2;
                    break;
                case 'D':
                    x = 3;
                    break;
                case 'E':
                    x = 4;
                    break;
                case 'F':
                    x = 5;
                    break;
                case 'G':
                    x = 6;
                    break;
                case 'H':
                    x = 7;
                    break;
            }
            return x;
        }
        private static void movePieces(List<string> newPositions)
        {

            
        }
    }
}



