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

        public (int, int) GetCoordinatesToGame(Display display)
        {
            return GetCoordinates(display);
        }

        private (int, int) GetCoordinates(Display display)
        {
            int userCol = 0;
            int userRow = 0;


            string userOption = Console.ReadLine();
            if (ValidateInput(userOption) && userOption != "")
            {
                string[] option = userOption.Split(" ");
                userCol = int.Parse(option[1]);
                userRow = userOption.ToUpper().ToCharArray()[0] - 'A';
                return (userCol - 1, userRow);
            }
            display.IncorrectCoordinatesMessage();
            return GetCoordinates(display);

        }
        private bool ValidateInput(string userOption)
        {
            string delimiter = " ";
            int userRow = -1;
            int userCol = -1;

            if (userOption != null && userOption.Length < 5 && userOption.Contains(delimiter))
            {
                string[] option = userOption.Split(delimiter);
                if (char.IsLetter(userOption[0]) && char.ToUpper(userOption[0]) - 65 < 10)
                {
                    if ((int.TryParse(option[1], out userCol) == true))
                    {
                        return true;
                    }
                }
            }
            return false;


        }

        public string ChooseDirectionToPlaceShip(Display display, List<string> listOfPossibleMoves)
        {
            string direction = Console.ReadLine();
            foreach (var possibleDirection in listOfPossibleMoves)
            {
                if (direction.ToUpper() == possibleDirection) { return direction.ToUpper(); }
            }
            display.WrongDirectionMessage();
            return ChooseDirectionToPlaceShip(display, listOfPossibleMoves);
        }

        public string GetManualOrRandomPlacement(Display display, Player player)
        {
            display.ManualOrRandomMessage(player);
            string selection = Console.ReadLine();
            if (selection.ToUpper() != "M" && selection.ToUpper() != "R")
            {
                display.WrongDirectionMessage();
                return GetManualOrRandomPlacement(display, player);
            }
            return selection;
        }
        public int GetHowManyShips(Display display)
        {
            int number;
            display.NumberOfShipsMessage();
            string numberOfShips = Console.ReadLine();
            if (int.TryParse(numberOfShips, out number))
            {
                if (number > 2 && number < 14)
                {
                return number;
                }
            }
            display.WrongDirectionMessage();
            return GetHowManyShips(display);
        }
    }
}
