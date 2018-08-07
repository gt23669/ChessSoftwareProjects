using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    abstract class Piece

    {
        //string name;
        //string ID;
        //char color;
        //int xLoc;
        //int yLoc;

        public abstract bool Check();
        
    }
}
