using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{

    public class Battleship
    {
        private Display display;
        private Input input;

        public Battleship()
        {
            display = new();
            input = new();
        }
        public void Run()
        {
            Game game = new();
            display.PrintBoard(game.board1, game.board2);
        }
    }
}
