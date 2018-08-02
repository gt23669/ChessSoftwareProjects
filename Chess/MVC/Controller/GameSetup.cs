using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chess.MVC.Controller
{
    class GameSetup
    {
        static List<string> NewContent = new List<string>();
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
                Console.WriteLine("What is the new file name?");
                string input = Console.ReadLine();
                input += ".txt";
                Console.WriteLine("How many things would you like to add to this new file");
                string num = Console.ReadLine();
                int ParseNum = 0;
                bool hope = int.TryParse(num, out ParseNum);

                if (hope)
                {
                    for (int i = 0; i < ParseNum; i++)
                    {
                        Console.WriteLine($"Piece {i + 1}");
                        NewContent.Add(Console.ReadLine());

                    }
                    File.WriteAllLines(input, NewContent.ToArray());
                }
                NewContent.Clear();
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

            NewContent.Add($" The {Stringb} {StringA} moved to {lol[3]},{lol[2]} ");
        }
        public static void Move()
        {

        }

        public static void DoubleMove()
        {

        }
    }


}
