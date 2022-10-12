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

        public void GameBegins(Player player1, Player player2, Display display, Input input)
        {
            int playerCounter = 0;
            bool isGameRunning = true;

            while (isGameRunning)
            {
                playerCounter++;
                if (playerCounter % 2 != 0)
                {
                    player1.CheckForSinkingShips(board1);
                    display.ShootMessage(player1);

                    player1.Shooting(board2, input, display);

                }
                else
                {
                    player2.CheckForSinkingShips(board2);

                    display.ShootMessage(player2);

                    player2.Shooting(board1, input, display);

                }
                display.PrintBoard(board1, board2);

            }
        }
    }
}
