using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class BoardFactory
    {
        public void ManualPlacement(Game game, Player player,Board board, Input input, Display display )
        {
            (bool, bool, bool, bool) canPlaceInAnyDirection;

            for (int shipIndex = 0; shipIndex < player.ships.Count; shipIndex++)
            {
                (int, int) shipCoordinates = input.GetCoordinates(display, player, shipIndex);

                canPlaceInAnyDirection = board.IsPlacementOk(shipCoordinates, player, shipIndex);
                if (canPlaceInAnyDirection != (false,false,false,false))
                {
                    display.PlaceYourShipInDirection(canPlaceInAnyDirection);
                    string direction = input.ChooseDirectionToPlaceShip(display);
                    board.AddCoordinatesToShipAndBoard
                        (direction, shipCoordinates, player, shipIndex, canPlaceInAnyDirection);
                    display.PrintBoard(game.board1, game.board2);
                }
                else
                {
                    display.NoFreeSpaces();
                    ManualPlacement(game, player, board, input, display);
                }
            }
        }
    }
}
