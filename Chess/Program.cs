using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Chess.MVC.Model;

namespace Chess
{
    class Program
    {
        static List<string> NewContent = new List<string>();
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            if (args.Length >0)
            {
                //Console.WriteLine("What is your file name");
                //string FilePath = Console.ReadLine();
                if (File.Exists(args[0]))
                {
                    string content = File.ReadAllText(args[0]);
                    Console.WriteLine("Your Game Looks like: ");
                    string[] b = Regex.Split(content, "[\r\n]+");
                    for (int i = 0; i < b.Length; i++)
                    {
                        char[] a = b[i].ToCharArray();

                        placement(a);

                    }
                }
                else
                {
                    Console.WriteLine("How many things would you like to add to this new file");
                    string num = Console.ReadLine();
                    int a = 0;
                    bool hope = int.TryParse(num, out a);

                    if (hope)
                    {
                        for (int i = 0; i < a; i++)
                        {
                            Console.WriteLine($"Item{i}");
                            NewContent.Add(Console.ReadLine());

                        }
                        // File.WriteAllLines(args[0], NewContent.ToArray());
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
            else
            {
                Console.WriteLine("empty args");
                //
            }
        }

        public static void placement(char[] lol)
        {
            string a = "";
            string b = "";
            switch (lol[1])
            {
                case 'K':
                    a = "king";
                    break;
                case 'Q':
                    a = "Queen";
                    break;
                case 'B':
                    a = "Bishop";
                    break;
                case 'N':
                    a = "Knight";
                    break;
                case 'R':
                    a = "Rook";
                    break;
                case 'P':
                    a = "Pawn";
                    break;
            }


            if (lol[2] == 'l')
            {
                b = "light";
            }
            else
            {
                b = "dark";
            }

            NewContent.Add($" The #{lol[0]} {b} {a} moved to {lol[4]},{lol[3]} ");
        }
    }
}
