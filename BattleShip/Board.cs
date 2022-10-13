using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Board
    {
        public Square[,] ocean;
        public int nRows;
        public int nCols;

        public Board(int rows, int cols)
        {
            nRows = rows;
            nCols = cols;
            ocean = new Square[rows, cols];
        }

        public AllowedDirection IsPlacementOk((int, int) coordinates, Player player, int shipIndex)
        {
            bool canPlaceUp = false; bool canPlaceDown = false;
            bool canPlaceLeft = false; bool canPlaceRight = false;

            int x = coordinates.Item1; int y = coordinates.Item2;

            if (x < 0 || x > nRows || y < 0 || y > nCols) 
            { 
                return new AllowedDirection { Up=false, Down=false, Left=false, Right=false };
            }
            if (ocean[x, y] != null) { return new AllowedDirection { Up = false, Down = false, Left = false, Right = false };  }
            /*ocean[x-1,y] Sus*/

            int countFreeSpacesUp = 0; int countFreeSpacesDown = 0;
            int countFreeSpacesLeft = 0; int countFreeSpacesRight = 0;

            for (int i = 1; i <= player.ships[shipIndex].length; i++) // Sus
            {
                if (!(x - i < 0))
                {
                    if (ocean[x - i, y] == null) 
                    { countFreeSpacesUp++; }
                }

                if (!(x + i > nRows - 1))
                {
                    if (ocean[x + i, y] == null) { countFreeSpacesDown++; }
                }

                if (!(y - i < 0))
                {
                    if (ocean[x, y - i] == null) { countFreeSpacesLeft++; }
                }

                if (!(y + i > nRows - 1))
                {
                    if (ocean[x, y + i] == null) { countFreeSpacesRight++; }
                }
                if (countFreeSpacesUp + 1> player.ships[shipIndex].length - 1) { canPlaceUp = true; }
                if (countFreeSpacesDown + 1> player.ships[shipIndex].length - 1) { canPlaceDown = true; }
                if (countFreeSpacesLeft + 1 > player.ships[shipIndex].length - 1) { canPlaceLeft = true; }
                if (countFreeSpacesRight + 1 > player.ships[shipIndex].length - 1) { canPlaceRight = true; }
            }
            return new AllowedDirection { Up = canPlaceUp, Down = canPlaceDown, Left = canPlaceLeft, Right = canPlaceRight};
        }

        public List<string> DeterminePossibleDirections
            (AllowedDirection canPlaceInDirection)
        {
            List<string> listOfPossibleMoves = new();
            if(canPlaceInDirection.Up) { listOfPossibleMoves.Add("U"); }
            if(canPlaceInDirection.Down) { listOfPossibleMoves.Add("D"); }
            if(canPlaceInDirection.Left) { listOfPossibleMoves.Add("L"); }
            if(canPlaceInDirection.Right) { listOfPossibleMoves.Add("R"); }
            return listOfPossibleMoves;
        }


        public void AddCoordinatesToShipAndBoard
            (string direction, (int, int) shipCoordinates, Player player, int shipIndex,
            AllowedDirection canPlaceInDirection)
        {
            int x = shipCoordinates.Item1;
            int y = shipCoordinates.Item2;

            player.ships[shipIndex].PositionOfShip.Add
                        (new Square(shipCoordinates, Square.SquareStatus.ship));

            ocean[shipCoordinates.Item1, shipCoordinates.Item2]
                = new Square(shipCoordinates, Square.SquareStatus.ship);

            if (direction == "U")
            {
                for (int modifier = 1; modifier < player.ships[shipIndex].length; modifier++) // Sus
                {
                    player.ships[shipIndex].PositionOfShip.Add
                        (new Square((x - modifier, y), Square.SquareStatus.ship));

                    ocean[x - modifier, y]
                        = new Square(shipCoordinates, Square.SquareStatus.ship);
                }
            }

            if (direction == "D")
            {
                for (int modifier = 1; modifier < player.ships[shipIndex].length; modifier++) // Sus
                {
                    player.ships[shipIndex].PositionOfShip.Add
                        (new Square((x + modifier, y), Square.SquareStatus.ship));

                    ocean[x + modifier, y]
                        = new Square(shipCoordinates, Square.SquareStatus.ship);
                }
            }

            if (direction == "L")
            {
                for (int modifier = 1; modifier < player.ships[shipIndex].length; modifier++) // Sus
                {
                    player.ships[shipIndex].PositionOfShip.Add
                        (new Square((x, y - modifier), Square.SquareStatus.ship));

                    ocean[x, y - modifier]
                        = new Square(shipCoordinates, Square.SquareStatus.ship);
                }
            }

            if (direction == "R")
            {
                for (int modifier = 1; modifier < player.ships[shipIndex].length; modifier++) // Sus
                {
                    player.ships[shipIndex].PositionOfShip.Add
                        (new Square((x, y + modifier), Square.SquareStatus.ship));

                    ocean[x, y + modifier]
                        = new Square(shipCoordinates, Square.SquareStatus.ship);
                }
            }

        }
    }
}

