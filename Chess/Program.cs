using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Chess.MVC.Controller;
using Chess.MVC.Model;

namespace Chess
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GameSetup.Setup(args);
            GameSetup.Move(args);
        }
    }
}
