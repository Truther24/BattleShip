using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Board
    {
        public Square[,] ocean;
        public int nRows;
        public int nCols;

        public Board(int rows, int cols)
        {
            nRows = rows;
            nCols = cols;
            ocean = new Square[rows, cols];
        }

        public bool IsPlacementOk((int, int) coordinates, Player player, int shipIndex)
        {
            int x = coordinates.Item1;
            int y = coordinates.Item2;
            int countFreeSpaces = 0;

            if (x < 0 || x > nRows || y < 0 || y > nCols) { return false; }
            if (ocean[x, y] != null) { return false; }
            /*ocean[x-1,y] Sus*/

            for (int i = 1; i <= player.ships[shipIndex].length; i++) // Sus
            {
                if (x - i < 0 || x > nRows)
                {
                    continue;
                }
                else
                {

                    if (ocean[x - i, y] == null) { countFreeSpaces++; }
                }
                
            }
            if(countFreeSpaces + 1 >= player.ships[shipIndex].length) { return true; }
            return false;

        }
    }
}
