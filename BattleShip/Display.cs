using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace BattleShip
{
    public class Display
    {
        public void ShootMessage(Player player)
        {
            System.Console.WriteLine($"It's time to shoot for player {player.name} ");
        }
        public void WrongDirectionMessage()
        {
            Console.WriteLine("The direction you inputted isn't correct! Choose another one");
        }
        public void PlaceYourShipInDirection
            (AllowedDirection canPlaceInDirection)
        {
            Console.WriteLine("You can place your ship starting with the chosen coordinate" +
                "in the following directions: ");
            if (canPlaceInDirection.Up) { Console.WriteLine("Up: Write U"); }
            if (canPlaceInDirection.Down) { Console.WriteLine("Down: Write D"); }
            if (canPlaceInDirection.Left) { Console.WriteLine("Left: Write L"); }
            if (canPlaceInDirection.Right) { Console.WriteLine("Right: Write R"); }
        }
        public void NoFreeSpaces()
        {
            Console.WriteLine("You couldn't place your ship " +
                "because the space was occupied or there were no spaces available to place the ship in any direction!");
        }
        public void IncorrectCoordinatesMessage()
        {
            Console.WriteLine("I'm sorry, your coordinates aren't valid!");
        }
        public void PlaceShipsMessage(Player player, Ship ship)
        {
            Console.Write($"Please place your ", Color.CornflowerBlue);
            Console.Write($"{ship.type}", Color.Red);
            Console.Write($" of length ", Color.CornflowerBlue);
            Console.Write($"{ship.length}, {player.name}", Color.Red);
            System.Console.WriteLine();
        }
        public void InputForPlayer(int playerCount)
        {
            Console.WriteLine($"Please input the name for player {playerCount}");
        }
        public void Greetings()
        {
            Console.WriteLine("Hello! Welcome to BattleShip");
        }

        public void PrintBoard(Board board1, Board board2, bool printWithShips)
        {
            // Cadet Blue color values
            int rColor = 95;
            int gColor = 158;
            int bColor = 160;

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

                    bColor += 4;
                    if (bColor > 220)
                    {
                        bColor = 160;
                    }

                    if (board1.ocean[row1, col] == null)
                    {

                        Console.Write(" ~ ", Color.FromArgb(rColor, gColor, bColor));
                    }
                    else if (board1.ocean[row1, col].status == Square.SquareStatus.ship)
                    {
                        if (printWithShips)
                        {

                            Console.Write(" S ", Color.Red);
                        }
                        else
                        {
                            Console.Write(" ~ ", Color.FromArgb(rColor, gColor, bColor));

                        }
                    }


                    else if (board1.ocean[row1, col].status == Square.SquareStatus.missed)
                    {
                        Console.Write(" M ", Color.Crimson);

                    }
                    else if (board1.ocean[row1, col].status == Square.SquareStatus.hit)
                    {
                        Console.Write(" H ", Color.LightGoldenrodYellow);

                    }
                    else if (board1.ocean[row1, col].status == Square.SquareStatus.sunk)
                    {
                        Console.Write(" X ", Color.LightGoldenrodYellow);

                    }
                }
                Console.Write("    " + "|" + "   ", Color.Red);
                Console.Write(row2 < 9 ? $" {row2 + 1} " : row2 + 1 + " ", Color.Wheat);

                for (int col = 0; col < board2.nCols; col++)
                {
                    bColor += 4;
                    if (bColor > 220)
                    {
                        bColor = 160;
                    }

                    if (board2.ocean[row2, col] == null)
                    {

                        Console.Write(" ~ ", Color.FromArgb(rColor, gColor, bColor));
                    }
                    else if (board2.ocean[row1, col].status == Square.SquareStatus.ship)
                    {
                        if (printWithShips)
                        {

                            Console.Write(" S ", Color.Red);
                        }
                        else
                        {
                            Console.Write(" ~ ", Color.FromArgb(rColor, gColor, bColor));

                        }
                    }
                    

                    else if (board2.ocean[row1, col].status == Square.SquareStatus.missed)
                    {
                        Console.Write(" M ", Color.Crimson);

                    }
                    else if (board2.ocean[row1, col].status == Square.SquareStatus.hit)
                    {
                        Console.Write(" H ", Color.LightGoldenrodYellow);

                    }
                    else if (board2.ocean[row1, col].status == Square.SquareStatus.sunk)
                    {
                        Console.Write(" X ", Color.LightGoldenrodYellow);

                    }
                }

            }
            Console.WriteLine();
        }


    }
}
