using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    abstract class Piece
    {
        public string name;
        public string ID;
        public char color;
        public int col;
        public int row;
        public List<int> availableMoves;
        public abstract bool Check(Piece[][] gameBoard, int nextRow, int nextCol);

        override
        public abstract string ToString();

    }
}
