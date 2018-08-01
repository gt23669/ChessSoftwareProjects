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

        public override bool Check()
        {
            return false;
        }
    }
}
