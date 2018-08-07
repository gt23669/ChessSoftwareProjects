using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class King : Piece
    {

        string name = "King";
        string ID = "K";
        char color;
        int xLoc;
        int yLoc;

        public King(char color, int xLoc, int yLoc)
        {
            this.color = color;
            this.xLoc = xLoc;
            this.yLoc = yLoc;
        }

        public override bool Check()
        {
            return false;
        }
    }
}
