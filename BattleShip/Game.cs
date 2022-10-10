using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Game
    {
        public Board board1;
        public Board board2;

        public Game()
        {
            board1 = new(10, 10);
            board2 = new(10, 10);
        }
    }
}
