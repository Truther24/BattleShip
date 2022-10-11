using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace BattleShip
{
    public class Display
    { 
        public void NoFreeSpaces()
        {
            System.Console.WriteLine("You couldn't place your ship " +
                "because there were no free spaces up");
        }
        public void IncorrectCoordinatesMessage()
        {
            System.Console.WriteLine("I'm sorry, your coordinates aren't valid!");
        }
        public void PlaceShipsMessage(Player player, Ship ship)
        {
            System.Console.WriteLine($"Please place your {ship.type} of length {ship.length}, {player.name}");
        }
        public void InputForPlayer(int playerCount)
        {
            System.Console.WriteLine($"Please input the name for player {playerCount}");
        }
        public void Greetings()
        {
            System.Console.WriteLine("Hello! Welcome to BattleShip");
        }

        public void PrintBoard(Board board1, Board board2)
        {
            // Cadet Blue color values
            int rColor = 95;
            int gColor = 158;
            int bColor = 160;

            Console.WriteLine();
            Console.Write("    ");

            for (int i = 0; i < board1.nRows; i++)
            {
                Console.Write($"{(char)('A'+i)}  ", Color.Wheat);
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
                    
                    if (board1.ocean[row1,col] == null)
                    {
                        
                        Console.Write(" ~ ", Color.FromArgb(rColor, gColor, bColor));
                    }
                    else if (board1.ocean[row1, col].status == Square.SquareStatus.ship)
                    {

                        Console.Write(" S ", Color.Red);
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

                        Console.Write(" S ", Color.Red);
                    }
                }

            }
            Console.WriteLine();
        }
    }
}
