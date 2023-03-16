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
            string placementOption;
            Player player1 = new(input.GetNameForPlayer(display), input.GetHowManyShips(display));
            Player player2 = new(input.GetNameForPlayer(display), input.GetHowManyShips(display));
            Game game = new(player1.name, player2.name);

            bool printWithShips = true;
            display.PrintPlayerHeader(game.player1Name, game.player2Name);

            display.PrintBoard(game.board1, game.board2, printWithShips);

            placementOption = input.GetManualOrRandomPlacement(display, player1);
            if (placementOption.ToUpper() == "M")
            {

                boardFactory.ManualPlacement(game, player1, game.board1, input, display);
            }
            else
            {
                boardFactory.RandomPlacement(game, player1, game.board1, display);

            }
            placementOption = input.GetManualOrRandomPlacement(display, player2);
            if (placementOption.ToUpper() == "M")
            {

                boardFactory.ManualPlacement(game, player2, game.board2, input, display);
            }
            else
            {
                boardFactory.RandomPlacement(game, player2, game.board2, display);

            }
            game.GameBegins(player1, player2, display, input);

        }
    }
}
