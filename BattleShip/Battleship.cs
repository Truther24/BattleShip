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
        private BoardFactory boardFactory;

        public Battleship()
        {
            display = new();
            input = new();
            boardFactory = new();
        }
        public void Run()
        {
            display.Greetings();
            Player player1 = new(input.GetNameForPlayer(display));
            Player player2 = new(input.GetNameForPlayer(display));
            foreach (var ship in player1.ships)
            {
                Console.WriteLine(ship.length);
            }
            Game game = new();
            display.PrintBoard(game.board1, game.board2);

            boardFactory.ManualPlacement(player1, game.board1, input, display);

            boardFactory.ManualPlacement(player2, game.board2, input, display);

            display.PrintBoard(game.board1, game.board2);


        }
    }
}
