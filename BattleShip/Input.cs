using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Input
    {
        public int playerCount;
        public string GetNameForPlayer(Display display)
        {
            playerCount++;
            display.InputForPlayer(playerCount);
            string playerName = Console.ReadLine();

            return playerName;
            
        }
    }
}
