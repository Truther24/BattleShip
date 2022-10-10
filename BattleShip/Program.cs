// See https://aka.ms/new-console-template for more information

namespace BattleShip
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            Board board = new(10, 10);
            Display display = new(board);
            display.PrintBoard();
        }
    }
}