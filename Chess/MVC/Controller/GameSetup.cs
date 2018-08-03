using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSC160_ConsoleMenu;

namespace Chess.MVC.Controller
{
    class GameSetup
    {
        static List<string> NewContent = new List<string>();
        public static void menu(string[] args)
        {
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
                            Setup(tempArgs);
                        }
                        else
                        {
                            Setup(args);

                        }
                        break;
                    case 2:
                        if (args.Length > 1)
                        {
                            Console.WriteLine("Which file do you want to use?");
                            int fileChoice = CIO.PromptForMenuSelection(args, false);
                            string file = args[fileChoice - 1];
                            string[] tempArgs = new string[] { file };
                            Console.WriteLine(file);
                            Move(tempArgs);

                        }
                        else
                        {
                            Move(args);

                        }
                        break;
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
                        break;
                    case 0:
                        exit = true;
                        break;
                }
            } while (!exit);
        }
        public static void Setup(string[] args)
        {
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

            }
            else
            {
                bool valid = false;

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
        public static void Move(string[] args)
        {

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
                        string[] SplitArray = Regex.Split(content, "[\r\n]+");
                        string[] StringSplit;
                        for (int i = 0; i < SplitArray.Length; i++)
                        {
                            if (SplitArray[i] == "")
                            {

                            }
                            else
                            {
                                StringSplit = SplitArray[i].Split(' ');
                                for (int j = 0; j < StringSplit.Length; j++)
                                {
                                    Console.WriteLine($"The piece at {StringSplit[0]} moved to {StringSplit[1]}");
                                }

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
    }
}



