﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MVC.Model;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Chess Application
            Board a = new Board();
            a.GenerateBoard();
        }
    }
}
