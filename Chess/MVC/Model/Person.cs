﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    abstract class Person
    {
       public string color;
       public bool isTurn;
       public bool isInCheck;
       public bool isInCheckMate;
       public List<Piece> piecesTaken;
        public int moveNumber;


        public abstract StringBuilder ToString();
    }
}