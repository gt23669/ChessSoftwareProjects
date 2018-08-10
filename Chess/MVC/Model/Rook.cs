using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Rook : Piece
    {
        //char color;
        //int xLoc;
        //int yLoc;

        public Rook(char color, int col, int row)
        {
            base.name = "Rook";
            base.ID = "R";
            base.color = color;
            base.col = col;
            base.row = row;
        }
        
        public override string ToString()
        {
            return ID;
        }

        public override bool Check(Piece[][] gameBoard, int nextRow, int nextCol)
        {
            throw new NotImplementedException();
        }
    }
}
