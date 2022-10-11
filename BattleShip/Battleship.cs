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

        public Battleship()
        {
            display = new();
            input = new();
        }
        public void Run()
        {
            display.Greetings();
            Player player1 = new(input.GetNameForPlayer(display));
            Player player2 = new(input.GetNameForPlayer(display));
            foreach (var ship in player1.ships)
            {
                Console.WriteLine(ship.length);
            }
            Game game = new();
            display.PrintBoard(game.board1, game.board2);

            for (int i = 0; i < player1.ships.Count; i++)
            {

                (int,int) shipCoordinates = input.GetCoordinates(display, player1, i);
                int xCoordinate = shipCoordinates.Item1;
                int yCoordinate = shipCoordinates.Item2;
                shipCoordinates = (xCoordinate, yCoordinate);

                player1.ships[i].PositionOfShip.Add(new Square(shipCoordinates, Square.SquareStatus.ship));

                game.board1.myBoard[xCoordinate, yCoordinate]
                    = new Square(shipCoordinates, Square.SquareStatus.ship);
            }

            for (int i = 0; i < player2.ships.Count; i++)
            {

                (int, int) shipCoordinates = input.GetCoordinates(display, player2, i);
                int xCoordinate = shipCoordinates.Item1;
                int yCoordinate = shipCoordinates.Item2;
                shipCoordinates = (xCoordinate, yCoordinate);
                player2.ships[i].PositionOfShip.Add
                    (new Square(shipCoordinates, Square.SquareStatus.ship));

                game.board2.myBoard[xCoordinate, yCoordinate]
                    = new Square(shipCoordinates, Square.SquareStatus.ship);
            }
            display.PrintBoard(game.board1, game.board2);


        }
    }
}
