﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Knight : Piece
    {

        //char color;
        //int xLoc;
        //int row;

        public Knight(char color, int col, int row)
        {
            base.name = "Knight";
            base.ID = "N";
            base.color = color;
            base.col = col;
            base.row = row;
        }




      
        public override string ToString()
        {
            return ID;
        }

        public override bool Check(Piece[][] gameBoard, int nextRow, int nextCol)
        {
            bool valid = false;
            

            return valid;
        }
    }
}
