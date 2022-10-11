using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Square
    {
        public (int, int) Position;
        private enum SquareStatus
        {
            empty, ship, hit, missed
        }
    }
}
