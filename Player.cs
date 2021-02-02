using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_
{
    class Player
    {
        GameBoard Map = new GameBoard();
        GameBoard EnemyMap = new GameBoard();
        List<Ship> Fleet = new List<Ship>();
        Ship Destroyer = new Ship("Destroyer", 2, "D");
        Ship Submarine = new Ship("Submarine", 3, "S");
        Ship Battleship = new Ship("Battleship", 4, "B");
        Ship AircraftCarrier = new Ship("Aircraft Carrier", 5, "A");

        public Player()
        {
            Map = new GameBoard();
            EnemyMap = new GameBoard();
            Fleet.Add(Destroyer);
            Fleet.Add(Submarine);
            Fleet.Add(Battleship);
            Fleet.Add(AircraftCarrier);
        }

        public void FireShot()
        {

        }
        
        public void DisplayMap()
        {
            Map.DisplayBoard();
        }
        public void PlaceShips()
        {
            for (int i = 0; i < Fleet.Count; i++)
            {
                Console.WriteLine("Where would you like to place your " + Fleet[i].shipName + "?");
                string position = PositionSelecter(Fleet[i]);
                DisplayMap();
                string numberCoordinate = SelectRowCoordinate();
                int rowCoordinate = int.Parse(numberCoordinate);
                string letterCoordinate = SelectColumnCoordinate();
                int columnCoordinate = Map.LettersToNumberCoordinate(letterCoordinate);
                Map.radar[rowCoordinate, columnCoordinate] = Fleet[i].shipAbbreviation;
                
                if (position == "H")
                {
                    string direction;
                    do
                    {
                        Console.WriteLine("Would you like the ships position to increase or decrease from current position? I or D?");
                        direction = Console.ReadLine();
                    } while (direction != "I" && direction != "D"); 
                }
            }
        }
        public string PositionSelecter(Ship ship)
        {
            string position;
            do
            {
                Console.WriteLine("Would you like " + ship.shipName + " to take a horizontal or vertical position? H or V?");
                position = Console.ReadLine();
            } while (position != "H" && position != "V");
            return position;
        }
        public string SelectRowCoordinate()
        {
            string numberCoordinate;
            do
            {
                Console.WriteLine("Please select the row coordinate: 1-20");
                numberCoordinate = Console.ReadLine();

            } while (numberCoordinate != "1" && numberCoordinate != "2" && numberCoordinate != "3" && numberCoordinate != "4" && numberCoordinate != "5" && numberCoordinate != "6" && numberCoordinate != "7" && numberCoordinate != "8" && numberCoordinate != "9" && numberCoordinate != "10" && numberCoordinate != "11" && numberCoordinate != "12" && numberCoordinate != "13" && numberCoordinate != "14" && numberCoordinate != "15" && numberCoordinate != "16" && numberCoordinate != "17" && numberCoordinate != "18" && numberCoordinate != "19" && numberCoordinate != "20");
            return numberCoordinate;
        }
        public string SelectColumnCoordinate()
        {
            string letterCoordinate;
            do
            {
                Console.WriteLine("Please select the column coordinate: A-T");
                letterCoordinate = Console.ReadLine();

            } while (letterCoordinate != "A" && letterCoordinate != "B" && letterCoordinate != "C" && letterCoordinate != "D" && letterCoordinate != "E" && letterCoordinate != "F" && letterCoordinate != "G" && letterCoordinate != "H" && letterCoordinate != "I" && letterCoordinate != "J" && letterCoordinate != "K" && letterCoordinate != "L" && letterCoordinate != "M" && letterCoordinate != "N" && letterCoordinate != "O" && letterCoordinate != "P" && letterCoordinate != "Q" && letterCoordinate != "R" && letterCoordinate != "S" && letterCoordinate != "T");
            return letterCoordinate;
        }


    }
}
