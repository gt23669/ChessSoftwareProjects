using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.MVC.Model.Player
{
    class Player2 : Person
    {
        public Player2()
        {
            name = "Player2";
            color = "Dark";
            isTurn = false; ;
            playerTokens = new List<Piece>();
        }

        public override StringBuilder ToString()
        {
            throw new NotImplementedException();
        }
    }
}
