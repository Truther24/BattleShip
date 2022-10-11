using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Square
    {
        public SquareStatus status;

        public (int, int) Position;
        public enum SquareStatus
        {
            empty, ship, hit, missed
        }
        public Square((int,int) position, SquareStatus status)
        {
            this.Position = position;
            this.status = status;   
            
        }
    }
}
