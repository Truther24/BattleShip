using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.utils
{
    public enum ShipType
    {
        Carrier,
        Cruiser,
        Battleship,
        Submarine,
        Destroyer,
        
    }

    public static class Utils
    {
        public static int GetShipTypeMaxValue()
        {
            return Enum.GetValues(typeof(ShipType)).Cast<int>().Max();
        }
    }
}
