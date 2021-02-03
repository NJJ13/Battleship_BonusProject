using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_
{
    class Player
    {
        public string playername;
        GameBoard Map = new GameBoard();
        GameBoard EnemyMap = new GameBoard();
        List<Ship> Fleet = new List<Ship>();
        Ship Destroyer = new Ship("Destroyer", 2, "| D |");
        Ship Submarine = new Ship("Submarine", 3, "| S |");
        Ship Battleship = new Ship("Battleship", 4, "| B |");
        Ship AircraftCarrier = new Ship("Aircraft Carrier", 5, "| A |");

        public Player()
        {
            Map = new GameBoard();
            EnemyMap = new GameBoard();
            Fleet.Add(Destroyer);
            Fleet.Add(Submarine);
            Fleet.Add(Battleship);
            Fleet.Add(AircraftCarrier);
            PlaceShips();
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
            bool resetBoard = false;
            string position;
            int rowCoordinate;
            int columnCoordinate;
            for (int i = 0; i < Fleet.Count; i++)
            {
                do
                {
                    Console.WriteLine("Where would you like to place your " + Fleet[i].shipName + "?");
                    position = PositionSelecter(Fleet[i]);
                    DisplayMap();
                    rowCoordinate = SelectRowCoordinate();
                    columnCoordinate = SelectColumnCoordinate(Map);
                    Map.CoordinateValidator(rowCoordinate, columnCoordinate);
                } while (Map.radar[rowCoordinate, columnCoordinate] != "| . |");
                Map.radar[rowCoordinate, columnCoordinate] = Fleet[i].shipAbbreviation;

                for (int j = 1; j < Fleet[i].shipSize; j++)
                {
                    for (int k = 0; k < 11; k++)
                    {
                        DisplayMap();
                        if (position == "H")
                        {
                            columnCoordinate = SelectNextColumnCoordinate(columnCoordinate);
                        }
                        if (position == "V")
                        {
                            rowCoordinate = SelectNextRowCoordinate(rowCoordinate);
                        }
                        if (Map.radar[rowCoordinate, columnCoordinate] == "| . |")
                        {
                            break;
                        }
                        if (k == 10)
                        {
                            Console.WriteLine("It looks like you're struggling to place your ships. The board will be reset)");
                            j = Fleet[i].shipSize++;
                            i = Fleet.Count;
                            BoardResetSwitch(resetBoard);
                            break;
                        }
                    }
                    
                    Map.radar[rowCoordinate, columnCoordinate] = Fleet[i].shipAbbreviation;
                }
            }
            if (resetBoard == true)
            {
                Map.ResetBoard();
                PlaceShips();
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
        public int SelectRowCoordinate()
        {
            string numberCoordinate;
            do
            {
                Console.WriteLine("Please select the row coordinate: 1-20");
                numberCoordinate = Console.ReadLine();

            } while (numberCoordinate != "1" && numberCoordinate != "2" && numberCoordinate != "3" && numberCoordinate != "4" && numberCoordinate != "5" && numberCoordinate != "6" && numberCoordinate != "7" && numberCoordinate != "8" && numberCoordinate != "9" && numberCoordinate != "10" && numberCoordinate != "11" && numberCoordinate != "12" && numberCoordinate != "13" && numberCoordinate != "14" && numberCoordinate != "15" && numberCoordinate != "16" && numberCoordinate != "17" && numberCoordinate != "18" && numberCoordinate != "19" && numberCoordinate != "20");
            return int.Parse(numberCoordinate);
        }
        public int SelectColumnCoordinate(GameBoard board)
        {
            string letterCoordinate;
            int letterNumerical;
            do
            {
                Console.WriteLine("Please select the column coordinate: A-T");
                letterCoordinate = Console.ReadLine();

            } while (letterCoordinate != "A" && letterCoordinate != "B" && letterCoordinate != "C" && letterCoordinate != "D" && letterCoordinate != "E" && letterCoordinate != "F" && letterCoordinate != "G" && letterCoordinate != "H" && letterCoordinate != "I" && letterCoordinate != "J" && letterCoordinate != "K" && letterCoordinate != "L" && letterCoordinate != "M" && letterCoordinate != "N" && letterCoordinate != "O" && letterCoordinate != "P" && letterCoordinate != "Q" && letterCoordinate != "R" && letterCoordinate != "S" && letterCoordinate != "T");
            letterNumerical = board.LettersToNumberCoordinate(letterCoordinate);
            return letterNumerical;
        }
        public int SelectNextRowCoordinate(int previousRowCoordinate)
        {
            string numberCoordinate;
            int nextCoordinate;
            do
            {
                Console.WriteLine("Please select the next consecutive row: " + previousRowCoordinate-- + " or " + previousRowCoordinate++);
                Console.WriteLine("(The coordinate must be an open coordinate)");
                numberCoordinate = Console.ReadLine();
                nextCoordinate = int.Parse(numberCoordinate);
                 
            } while (nextCoordinate != previousRowCoordinate-- && nextCoordinate != previousRowCoordinate++);
            return nextCoordinate;
        }
        public int SelectNextColumnCoordinate(int previousColumnCoordinate)
        {
            string letterCoordinate;
            int nextCoordinate;
            do
            {
                Console.WriteLine("Please select the next consecutive column: " + Map.NumbertoLetterCoordinate(previousColumnCoordinate--) + " or " + Map.NumbertoLetterCoordinate(previousColumnCoordinate++));
                Console.WriteLine("(The coordinate must be an open coordinate)");
                letterCoordinate = Console.ReadLine();
            } while (letterCoordinate != Map.NumbertoLetterCoordinate(previousColumnCoordinate--) && letterCoordinate != Map.NumbertoLetterCoordinate(previousColumnCoordinate++));
            nextCoordinate = Map.LettersToNumberCoordinate(letterCoordinate);
            return nextCoordinate;
        }
        public void BoardResetSwitch(bool resetboard)
        {
            resetboard = true;
        }
        public void WritePlayerName()
        {
            Console.WriteLine("Please enter your name:");
            playername = Console.ReadLine();
        }
    }
}
