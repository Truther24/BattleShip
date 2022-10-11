using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Input
    {
        public int playerCount;
        public string GetNameForPlayer(Display display)
        {
            playerCount++;
            display.InputForPlayer(playerCount);
            string playerName = Console.ReadLine();

            return playerName;
            
        }

        public (int, int) GetCoordinates(Display display, Player player, int index)
        {
            int userCol=0;
            int userRow=0;
            
                display.PlaceShipsMessage(player, player.ships[index]);

                string userOption = Console.ReadLine();
                if (ValidateInput(userOption))
                {
                    string[] option = userOption.Split(" ");
                    userCol = int.Parse(option[1]);
                    userRow = userOption.ToUpper().ToCharArray()[0] - 'A';
                    return (userCol - 1, userRow);
                }
            display.IncorrectCoordinatesMessage();
            GetCoordinates(display, player, index);
            return (userCol - 1, userRow);

        }
        private bool ValidateInput(string userOption)
        {
            string delimiter = " ";
            int userRow = -1;
            int userCol = -1;
            bool getInput = true;

            while (getInput)
            {

                if (userOption != null && userOption.Length < 5 && userOption.Contains(delimiter))
                {
                    string[] option = userOption.Split(delimiter);
                    if (char.IsLetter(userOption[0]) && char.ToUpper(userOption[0]) - 65 < 10)
                    {
                        if ((int.TryParse(option[1], out userCol) == true))
                        {
                            /*Console.WriteLine("Valid Input");*/
                            userRow = userOption.ToUpper().ToCharArray()[0] - 'A';
                            /*                            Console.WriteLine(((userCol - 1, userRow)));
                            */
                            return true;
                        }
                        Console.WriteLine("The number isn't withing the bounds of the board");
                    }
                    Console.WriteLine("The first letter isn't within the bounds of the board !");
                }
                Console.WriteLine("I'm sorry, your input was incorrect !");
            }
            return true;
        }
    }
}
