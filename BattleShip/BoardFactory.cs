using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class BoardFactory
    {
        public void ManualPlacement(Player player,Board board, Input input, Display display )
        {
            for (int i = 0; i < player.ships.Count; i++)
            {

                (int, int) shipCoordinates = input.GetCoordinates(display, player, i);
                int xCoordinate = shipCoordinates.Item1;
                int yCoordinate = shipCoordinates.Item2;

                if(board.IsPlacementOk(shipCoordinates, player, i))
                {
                player.ships[i].PositionOfShip.Add(new Square(shipCoordinates, Square.SquareStatus.ship));

                board.ocean[xCoordinate, yCoordinate]
                    = new Square(shipCoordinates, Square.SquareStatus.ship);
                }
                else
                {
                    display.NoFreeSpaces();
                    ManualPlacement(player, board, input, display);
                }


            }
        }
    }
}
