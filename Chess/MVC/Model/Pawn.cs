using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Pawn : Piece
    {
        string name = "Pawn";
        string ID = "P";


        public override bool Check()
        {
            throw new NotImplementedException();
        }
    }
}
