using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Player
    {
        public string name;
        public List<Ship> ships;

        public Player(string name)
        {
            this.name = name;
            ships = new();
            for (int i = 0; i < 5; i++)
            {
                ships.Add(new Ship(i));
            }
        }
        public void Shooting(Board board, Input input, Display display)
        {
            (int, int) coordinates = input.GetCoordinates(display);
            if (board.ocean[coordinates.Item1, coordinates.Item2] == null)
            {
                board.ocean[coordinates.Item1, coordinates.Item2]
                    = new Square(coordinates, Square.SquareStatus.missed);

            }
            if (board.ocean[coordinates.Item1, coordinates.Item2].status == Square.SquareStatus.ship)
            {
                board.ocean[coordinates.Item1, coordinates.Item2]
                    = new Square(coordinates, Square.SquareStatus.hit);

                for (int i = 0; i < ships.Count; i++)
                {

                    for (int j = 0; j < ships[i].PositionOfShip.Count; j++)
                    {
                        if (coordinates == ships[i].PositionOfShip[j].Position)
                        {
                            ships[i].PositionOfShip[j] = new Square(coordinates, Square.SquareStatus.hit);
                        }
                    }

                }
            }
        }
        public void CheckForSinkingShips(Board board)
        {
            for (int shipIndex = 0; shipIndex < ships.Count; shipIndex++)
            {
                if (ships[shipIndex].PositionOfShip.All(ship => ship.status == Square.SquareStatus.hit))
                {
                    foreach (Square ship in ships[shipIndex].PositionOfShip)
                    {
                        (int, int) coordinates = ship.Position;
                        ship.status = Square.SquareStatus.sunk;
                        board.ocean[coordinates.Item1, coordinates.Item2].status = Square.SquareStatus.sunk;
                    }
                }
            }
        }
    }
}
