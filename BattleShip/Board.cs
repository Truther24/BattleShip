using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Board
    {
        public int[,] myBoard { get; set; }
        public int nRows;
        public int nCols;

        public Board(int rows, int cols)
        {
            nRows = rows;
            nCols = cols;
            myBoard = new int[rows, cols];
        }
    }
}
