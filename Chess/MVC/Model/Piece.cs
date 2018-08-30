using System.Collections.Generic;

namespace Chess.MVC.Model
{
    abstract class Piece
    {
        public string name;
        public string ID;
        public char color;
        public int col;
        public int row;
        public List<Move> moves;



        public abstract bool CheckValidMove(Piece[][] gameBoard, List<Piece> gameTokens, int nextRow, int nextCol, bool message);
        public abstract string ToString();

    }
}
