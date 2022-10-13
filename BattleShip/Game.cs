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
        public string player1Name;
        public string player2Name;

        public Game(string player1Name, string player2Name)
        {
            board1 = new(10, 10);
            board2 = new(10, 10);
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void GameBegins(Player player1, Player player2, Display display, Input input)
        {
            int playerCounter = 0;
            bool printWithShips = false;
            bool isGameRunning = true;
            bool didShotHit;

            bool player1Won;
            bool player2Won;

            while (isGameRunning)
            {
                playerCounter++;
                player1Won = player2.didPlayerWin();
                player2Won = player1.didPlayerWin();

                display.PrintPlayerHeader(player1.name, player2.name);

                display.PrintBoard(board1, board2, printWithShips);

                if (player1Won || player2Won)
                {
                    if (player1Won)
                    {
                        display.DisplayWinnerMessage(player1);

                    }
                    else
                    {

                        display.DisplayWinnerMessage(player2);
                    }
                    break;
                }
                if (playerCounter % 2 != 0)
                {
                    display.ShootMessage(player1);

                    didShotHit = player2.Shooting(board2, input, display);
                    player2.CheckForSinkingShips(board2, display);
                    if (didShotHit)
                    {
                        display.ShipHitMessage(player2Name);
                        playerCounter--;
                        continue;
                    }
                    else
                    {
                        display.ShipDidntHitMessage();
                    }

                }
                else
                {

                    display.ShootMessage(player2);

                    didShotHit = player1.Shooting(board1, input, display);
                    player1.CheckForSinkingShips(board1, display);
                    if (didShotHit)
                    {
                        display.ShipHitMessage(player1Name);
                        playerCounter--;
                        continue;
                    }
                    else
                    {
                        display.ShipDidntHitMessage();
                    }

                }

            }
        }
    }
}
