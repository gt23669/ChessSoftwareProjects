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

        public override bool Check()
        {
            throw new NotImplementedException();
        }
    }
}
