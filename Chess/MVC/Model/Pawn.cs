using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Pawn : Piece
    {
        //string name = "Pawn";
        //string ID = "P";
        char color;
        int xLoc;
        int yLoc;

        public Pawn(char color, int xLoc, int yLoc)
        {
            string name = "Pawn";
            string ID = "P";
            this.color = color;
            this.xLoc = xLoc;
            this.yLoc = yLoc;
        }

        public override bool Check()
        {
            throw new NotImplementedException();
        }
    }
}
