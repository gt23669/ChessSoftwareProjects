using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MVC.Model
{
    class Move
    {
        public int row;
        public int col;
        public Move(int row, int col)
        {
            this.row = row;
            this.col = col;
            
        }

        public override string ToString()
        {
            return $"Row: {row} Col: {col}";
        }
    }
}
