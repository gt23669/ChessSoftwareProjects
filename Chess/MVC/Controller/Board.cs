using System;

namespace Chess.MVC.Model
{
    class Board
    {
        public static Piece[][] GenerateBoard()
        {
            Piece[][] board = new Piece[8][];

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new Piece[8];

            }

            return board;
        }

        public static void PrintBoard(Piece[][] gameBoard)
        {
            for (int i = 0; i < gameBoard.Length; i++)
            {

                for (int j = 0; j < gameBoard[i].Length; j++)
                {

                    if (gameBoard[i][j] == null)
                    {
                        if (j == 7)
                        {
                            Console.Write($"|___| {i + 1}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write($"|___");
                        }
                    }
                    else
                    {
                        if (j == 7)
                        {
                            Console.Write($"|_{gameBoard[i][j].ToString()}_| {i + 1}");
                            Console.WriteLine();

                        }
                        else
                        {
                            Console.Write($"|_{gameBoard[i][j].ToString()}_");
                        }
                    }

                }
                if (i == 7)
                {
                    Console.WriteLine();
                    Console.WriteLine("  A   B   C   D   E   F   G   H  ");
                }
            }
            Console.WriteLine();
        }
    }
}
