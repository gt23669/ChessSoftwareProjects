using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.MVC.Model.Player
{
    class Player1 : Person
    {
        public Player1()
        {
            name = "Player1";
            color = "Light";
            isTurn = true; ;
            playerTokens = new List<Piece>();
        }

        public override StringBuilder ToString()
        {
            throw new NotImplementedException();
        }
    }
}
