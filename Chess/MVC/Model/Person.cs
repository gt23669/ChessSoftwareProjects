using System.Collections.Generic;
using System.Text;

namespace Chess.MVC.Model
{
    abstract class Person
    {
        public string name;
        public string color;
        public bool isTurn;
        public List<Piece> playerTokens;


        public abstract StringBuilder ToString();
    }
}
