using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class AllowedDirection
    {
        public bool Down { get; set; }
        public bool Up { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }

        public bool AnyDirectionAllowed()
        {
            return Down || Up || Left || Right;
        }
    }
    public class BoardFactory
    {
        public void ManualPlacement(int shipIndex, Game game, Player player,Board board, Input input, Display display )
        {
            bool printWithShips = true;

            for (; shipIndex < player.ships.Count; shipIndex++)
            {
                display.PlaceShipsMessage(player, player.ships[shipIndex]);

                (int, int) shipCoordinates = input.GetCoordinatesToGame(display);

                var canPlaceInAnyDirection = board.IsPlacementOk(shipCoordinates, player, shipIndex);
                if (canPlaceInAnyDirection.AnyDirectionAllowed())
                {
                    List<string> listOfPossibleMoves = board.DeterminePossibleDirections(canPlaceInAnyDirection);
                    display.PlaceYourShipInDirection(canPlaceInAnyDirection);
                    string direction = input.ChooseDirectionToPlaceShip(display, listOfPossibleMoves);

                    board.AddCoordinatesToShipAndBoard
                        (direction, shipCoordinates, player, shipIndex, canPlaceInAnyDirection);
                    display.PrintBoard(game.board1, game.board2, printWithShips);
                }
                else
                {
                    display.NoFreeSpaces();
                    ManualPlacement(shipIndex, game, player, board, input, display);
                }
            }
        }
        public void RandomPlacement(int shipIndex, Game game, Player player, Board board, Input input, Display display)
        {
            Random rnd = new();

            for (; shipIndex < player.ships.Count; shipIndex++)
            {
                bool printWithShips = true;

                (int, int) shipCoordinates = (rnd.Next(0, board.nRows), rnd.Next(0, board.nCols));

                var canPlaceInAnyDirection = board.IsPlacementOk(shipCoordinates, player, shipIndex);
                if (canPlaceInAnyDirection.AnyDirectionAllowed())
                {
                    List<string> listOfPossibleMoves = board.DeterminePossibleDirections(canPlaceInAnyDirection);

                    string direction = listOfPossibleMoves[rnd.Next(listOfPossibleMoves.Count)];

                    board.AddCoordinatesToShipAndBoard
                        (direction, shipCoordinates, player, shipIndex, canPlaceInAnyDirection);
                    display.PrintBoard(game.board1, game.board2, printWithShips);
                }
                else
                {
                    
                    RandomPlacement(shipIndex, game, player, board, input, display);
                }
            }

        }
    }
}
