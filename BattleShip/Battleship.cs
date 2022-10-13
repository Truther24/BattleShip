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
            
            Game game = new();
            bool printWithShips = true;
            display.PrintBoard(game.board1, game.board2, printWithShips);;

            boardFactory.ManualPlacement(0, game, player1, game.board1, input, display);

            boardFactory.ManualPlacement(0, game, player2, game.board2, input, display);

            game.GameBegins(player1, player2, display, input);

        }
    }
}
