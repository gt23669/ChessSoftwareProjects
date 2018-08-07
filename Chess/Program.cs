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
            Board board = new Board();
            //gameBoard = board.GenerateBoard();
            pieces = GameSetup.Menu(args);
            gameBoard = board.printBoard(pieces);
            board.printNewBoard(gameBoard);
            
            //GameSetup.Setup(args);
            //GameSetup.Move(args);
        }
    }
}
