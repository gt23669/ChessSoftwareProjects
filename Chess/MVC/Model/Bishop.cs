using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Bishop : Piece
    {
        //char color;
        //int xLoc;
        //int yLoc;

        public Bishop(char color, int col, int row)
        {
            base.name = "Bishop";
            base.ID = "B";
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
            bool valid = false;
            

            return valid;
        }
    }
}
