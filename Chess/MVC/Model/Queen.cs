using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Queen : Piece
    {
        string name = "Queen";
        string ID = "Q";
        char color;
        int xLoc;
        int yLoc;

        public Queen(char color, int xLoc, int yLoc)
        {
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
