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

       


        public enum ShipType 
        {
            Carrier , Cruiser, Battleship, Submarine, Destroyer
        }

        public Ship(int indexOfEnum)
        {
            var values = Enum.GetValues(typeof(ShipType)).Cast<ShipType>().ToList();
            this.type = values[indexOfEnum];
            
        }
    }
}
