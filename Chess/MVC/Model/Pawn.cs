using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Pawn : Piece
    {

        //char color;
        //int xLoc;
        //int yLoc;

        public Pawn(char color, int col, int row)
        {
            base.name = "Pawn";
            base.ID = "P";
            base.color = color;
            base.col = col;
            base.row = row;
        }



        //public override bool Check()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
