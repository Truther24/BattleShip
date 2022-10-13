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
            bool printWithShips = false;
            bool isGameRunning = true;
            bool didShotHit = false;

            bool player1Won = false;
            bool player2Won = false;

            while (isGameRunning)
            {
                player1Won = board1.didPlayerWin(player1);
                player2Won = board2.didPlayerWin(player2);

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
                
                playerCounter++;
                display.PrintBoard(board1, board2, printWithShips);
                if (playerCounter % 2 != 0)
                {
                    display.ShootMessage(player1);

                    didShotHit = player1.Shooting(board2, input, display);
                    player1.CheckForSinkingShips(board2);
                    if(didShotHit) 
                    {
                        playerCounter--;
                        continue;
                    }

                }
                else
                {

                    display.ShootMessage(player2);

                    didShotHit = player2.Shooting(board1, input, display);
                    player2.CheckForSinkingShips(board1);
                    if (didShotHit)
                    {
                        playerCounter--;
                        continue;
                    }

                }

            }
        }
    }
}
