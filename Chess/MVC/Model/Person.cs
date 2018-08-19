using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    abstract class Person
    {
        public string name;
        public string color;
        public bool isTurn;
        public bool isInCheck;
        public bool isInCheckMate;
        public List<Piece> piecesTaken;
        public int moveIndex;
        public List<string> moves;
        public List<Piece> moveablePieces;


        public abstract StringBuilder ToString();
    }
}
