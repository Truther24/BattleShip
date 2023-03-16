using BattleShip.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip
{
    public class Ship
    {
        public object type;
        public int length;
        public List<Square> PositionOfShip;
        private Random rnd;

        

        public Ship(int i)
        {
            rnd = new();
            if(i > Enum.GetValues(typeof(ShipType)).Length - 1)
            {
                i = rnd.Next(0, Enum.GetValues(typeof(ShipType)).Length);
            }
            PositionOfShip = new();
            
            this.length = rnd.Next(2,6);
            this.type = (ShipType)i;

        }
    }
}
