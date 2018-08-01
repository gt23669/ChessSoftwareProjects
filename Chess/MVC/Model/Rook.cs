using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Rook : Piece
    {
        string name = "Rook";
        string ID = "R";

        public override bool Check()
        {
            throw new NotImplementedException();
        }
    }
}
