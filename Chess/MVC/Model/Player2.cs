using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Player2 : Person
    {
        public Player2()
        {
            color = "Dark";
            isTurn = false;
            isInCheck = false;
            isInCheckMate = false;
            moveNumber = 1;
            piecesTaken = new List<Piece>();
        }

        public override StringBuilder ToString()
        {
            StringBuilder rtnStr = new StringBuilder();
            rtnStr.Append($"{color}, isTurn: {isTurn}, isInCheck: {isInCheck}, isInCheckMate: {isInCheckMate} and has taken these pieces: ");
            for (int i = 0; i < piecesTaken.Count; i++)
            {
                string piece = piecesTaken[i].name + ", ";
                rtnStr.Append(piece);

            }
            return rtnStr;
        }
    }
}
