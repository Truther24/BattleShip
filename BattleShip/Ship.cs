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
            /* var values = Enum.GetValues(typeof(ShipType)).Cast<ShipType>().ToList();*/
            /*this.type = values[indexOfEnum];*/
            /*if (values[indexOfEnum] == ShipType.Carrier)
            {
                this.length = 5;
            }
            if (values[indexOfEnum] == ShipType.Battleship)
            {
                this.length = 4;
            }
            if (values[indexOfEnum] == ShipType.Cruiser || values[indexOfEnum] == ShipType.Submarine)
            {
                this.length = 3;
            }
            if (values[indexOfEnum] == ShipType.Destroyer)
            {
                this.length = 2;
            }*/
            this.length = rnd.Next(1,6);
            this.type = (ShipType)i;

        }
    }
}
