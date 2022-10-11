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
            display.Greetings();
            Player player1 = new(input.GetNameForPlayer(display));
            Player player2 = new(input.GetNameForPlayer(display));
            foreach (var ship in player1.ships)
            {
                Console.WriteLine(ship.type);
            }

            Game game = new();
            display.PrintBoard(game.board1, game.board2);
        }
    }
}
