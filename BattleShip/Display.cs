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
                    
                    if (board1.myBoard[row1,col] == 0)
                    {
                        
                        Console.Write(" ~ ", Color.FromArgb(rColor, gColor, bColor));
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

                    if (board2.myBoard[row2, col] == 0)
                    {

                        Console.Write(" ~ ", Color.FromArgb(rColor, gColor, bColor));
                    }
                }

            }
            Console.WriteLine();
        }
    }
}
