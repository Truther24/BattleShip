using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace BattleShip
{
    public class Display
    {
        public void NumberOfShipsMessage()
        {
            Console.Write("Please type the number of ");
            Console.Write($"ships", Color.Red);
            Console.Write(" you would like to have! (min: 3, max: 13)\n");

        }
        public void DisplayWinnerMessage(Player player)
        {
            Console.WriteLine("Congratulation!",Color.FromKnownColor(KnownColor.Highlight));
            Console.Write($"Player ");
            Console.Write($"{player.name}",Color.Red);
            Console.Write(" Won!\n");

        }
        public void ShootMessage(Player player)
        {
            Console.Write("It's time to shoot for player ");
            Console.Write($"{player.name} !\n",Color.Red);
            Console.Write("Coordinate : ");
        }
        public void WrongDirectionMessage()
        {
            Console.Write("Your input ");
            Console.Write("isn't", Color.Red);
            Console.Write(" correct! Try again\n");
        }
        public void PlaceYourShipInDirection
            (AllowedDirection canPlaceInDirection)
        {
            Console.WriteLine("You can place your ship starting with the chosen coordinate" +
                "in the following directions: ");
            if (canPlaceInDirection.Up) { Console.Write("Up: Write U\n",Color.Red); }
            if (canPlaceInDirection.Down) { Console.Write("Down: Write D\n", Color.Red); }
            if (canPlaceInDirection.Left) { Console.Write("Left: Write L\n", Color.Red); }
            if (canPlaceInDirection.Right) { Console.Write("Right: Write R\n", Color.Red); }
        }
        public void NoFreeSpaces()
        {
            Console.Write("You couldn't place your ");
            Console.Write($"ship", Color.Red);
            Console.Write(" because the space was ");
            Console.Write($"occupied", Color.Red);
            Console.Write(" or there were no spaces available to place the ship in any direction!\n");
        }
        public void IncorrectCoordinatesMessage()
        {
            Console.Write("I'm sorry, your ");
            Console.Write("coordinates",Color.Red);
            Console.Write(" aren't valid!\n");
        }
        public void PlaceShipsMessage(Player player, Ship ship)
        {
            Console.Write($"Please place your ", Color.CornflowerBlue);
            Console.Write($"{ship.type}", Color.Red);
            Console.Write($" of length ", Color.CornflowerBlue);
            Console.Write($"{ship.length}, {player.name}\n", Color.Red);
        }
        public void InputForPlayer(int playerCount)
        {
            Console.Write($"Please input the name for ");
            Console.Write($"player {playerCount} :\n\n",Color.RoyalBlue);
        }
        public void Greetings()
        {
            Console.Write("Hello! Welcome to ");
            Console.Write("BattleShip",Color.Aqua);
            Console.Write(" !\n\n",Color.Red);
        }
        public void ManualOrRandomMessage(Player player)
        {
            Console.Write("Player ");
            Console.Write($"{player.name}", Color.Red);
            Console.Write(", select between ");
            Console.Write($"Manual", Color.Red);
            Console.Write(" (m) or ");
            Console.Write($"Random", Color.Red);
            Console.Write(" (r) Ship Placement !\n");

        }

        public void PrintBoard(Board board1, Board board2, bool printWithShips)
        {

            Console.WriteLine();
            Console.Write("    ");

            for (int i = 0; i < board1.nRows; i++)
            {
                Console.Write($"{(char)('A' + i)}  ", Color.Wheat);
            }

            Console.Write("   " + "|" + "       ", Color.Red);

            for (int i = 0; i < board2.nRows; i++)
            {
                Console.Write($"{(char)('A' + i)}  ", Color.Wheat);
            } // First row finish

            for (int row1 = 0, row2 = 0; row1 < board1.nRows && row2 < board2.nRows; row1++, row2++)
            {
                Console.WriteLine();
                Console.Write(row1 < 9 ? $" {row1 + 1} " : row1 + 1 + " ", Color.Wheat);

                for (int col = 0; col < board1.nCols; col++)
                {

                    if (board1.ocean[row1, col] == null)
                    {

                        Console.Write(" ~ ", Color.CadetBlue);
                    }
                    else if (board1.ocean[row1, col].status == Square.SquareStatus.ship)
                    {
                        if (printWithShips)
                        {

                            Console.Write(" S ", Color.LawnGreen);
                        }
                        else
                        {
                            Console.Write(" ~ ", Color.CadetBlue);

                        }
                    }


                    else if (board1.ocean[row1, col].status == Square.SquareStatus.missed)
                    {
                        Console.Write(" M ", Color.DarkGray);

                    }
                    else if (board1.ocean[row1, col].status == Square.SquareStatus.hit)
                    {
                        Console.Write(" H ", Color.BlueViolet);

                    }
                    else if (board1.ocean[row1, col].status == Square.SquareStatus.sunk)
                    {
                        Console.Write(" X ", Color.Red);

                    }
                }
                Console.Write("    " + "|" + "   ", Color.Red);
                Console.Write(row2 < 9 ? $" {row2 + 1} " : row2 + 1 + " ", Color.Wheat);

                for (int col = 0; col < board2.nCols; col++)
                {

                    if (board2.ocean[row2, col] == null)
                    {

                        Console.Write(" ~ ", Color.CadetBlue);
                    }
                    else if (board2.ocean[row1, col].status == Square.SquareStatus.ship)
                    {
                        if (printWithShips)
                        {

                            Console.Write(" S ", Color.LawnGreen);
                        }
                        else
                        {
                            Console.Write(" ~ ", Color.CadetBlue);

                        }
                    }
                    

                    else if (board2.ocean[row1, col].status == Square.SquareStatus.missed)
                    {
                        Console.Write(" M ", Color.DarkGray);

                    }
                    else if (board2.ocean[row1, col].status == Square.SquareStatus.hit)
                    {
                        Console.Write(" H ", Color.BlueViolet);

                    }
                    else if (board2.ocean[row1, col].status == Square.SquareStatus.sunk)
                    {
                        Console.Write(" X ", Color.Red);

                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintPlayerHeader( string player1Name, string player2Name)
        {
            Console.Write("                 ");
            Console.Write($"{player1Name}", Color.Red);
            Console.Write("                 ");
            Console.Write("                  ");
            Console.Write($"{player2Name}\n", Color.Red);
        }

        public void ShipHitMessage(string playerName)
        {
            Console.Write("You hit one of ");
            Console.Write($"{playerName}'s", Color.Red);
            Console.Write(" ships!\n\n");
        }

        internal void ShipSunkMessage(string playerName)
        {
            Console.Write("One of ");
            Console.Write($"{playerName}'s", Color.Red);
            Console.Write(" ships was sunk !\n\n");
        }

        internal void ShipDidntHitMessage()
        {
            Console.Write("It looks like you ");
            Console.Write($"missed", Color.Red);
            Console.Write(" your shot!\n\n");
        }
    }
}
