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
        private Board board;
        public Display(Board board)
        {
            this.board = board;
        }

       

        public void PrintBoard()
        {
            Console.WriteLine();
            Console.Write("    ");
            for (int i = 0; i < board.nRows; i++)
            {
                Console.Write($"{(char)('A'+i)}  ", Color.Wheat);
            }

            for (int row = 0; row < board.nRows; row++)
            {
                Console.WriteLine();
                Console.Write(row < 9 ? $" {row + 1} " : row + 1 + " ", Color.Wheat); ;

                for (int col = 0; col < board.nCols; col++)
                {
                    if (board.myBoard[row,col] == 0)
                    {
                        
                        Console.Write(" ~ ", Color.CadetBlue);
                    }
                }

            }
        }
    }
}
