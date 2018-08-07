using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Chess.MVC.Controller;
using Chess.MVC.Model;

namespace Chess
{
    class Program
    {
        static string[][] gameBoard = new string[8][];

        static void Main(string[] args)
        {
            List<Piece> pieces = new List<Piece>();
            pieces = GameSetup.Menu(args);
            //GameSetup.Setup(args);
            //GameSetup.Move(args);
            Board board = new Board();
            gameBoard = board.GenerateBoard();
            gameBoard = board.printBoard(pieces, gameBoard);
        }
    }
}
