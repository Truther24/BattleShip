using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Player
    {
        public string name;
        public List<Ship> ships;

        public Player(string name)
        {
            this.name = name;
            ships = new();
            for (int i = 0; i < 5; i++)
            {
                ships.Add(new Ship(i));
            }
            
        }
    }
}
