using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Player1 : Person
    {
        public Player1()
        {
            name = "Player1";
            color = "Light";
            isTurn = true;
            isInCheck = false;
            isInCheckMate = false;
            moveIndex = 0;
            piecesTaken = new List<Piece>();
            moves = new List<string>();
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
