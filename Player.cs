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
        public GameBoard Map = new GameBoard();
        public GameBoard EnemyMap = new GameBoard();
        public List<Ship> Fleet = new List<Ship>();
        public Ship Destroyer = new Ship("Destroyer", 2, "| D |");
        public Ship Submarine = new Ship("Submarine", 3, "| S |");
        public Ship Battleship = new Ship("Battleship", 4, "| B |");
        public Ship AircraftCarrier = new Ship("Aircraft Carrier", 5, "| A |");

        public Player()
        {
            WritePlayerName();
            Map = new GameBoard();
            EnemyMap = new GameBoard();
            Fleet.Add(Destroyer);
            Fleet.Add(Submarine);
            Fleet.Add(Battleship);
            Fleet.Add(AircraftCarrier);
            PlaceShips();
        }

        public int FireShotRow()
        {
            int fireRow;
            DisplayEnemyMap();
            Console.WriteLine("Where would you like to fire your shot:");
            fireRow = SelectRowCoordinate();
            return fireRow;

        }
        public int FireShotColumn()
        {
            int fireColumn;
            fireColumn = SelectColumnCoordinate(EnemyMap);
            return fireColumn;
        }
        public void DisplayMap()
        {
            Map.DisplayBoard();
        }
        public void DisplayEnemyMap()
        {
            EnemyMap.DisplayBoard();
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
                    Console.WriteLine("Where would you like to place your " + Fleet[i].shipName + "? It will take up " + Fleet[i].shipSize + " spaces.");
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
                            columnCoordinate = SelectNextColumnCoordinate(rowCoordinate, columnCoordinate);
                        }
                        if (position == "V")
                        {
                            rowCoordinate = SelectNextRowCoordinate(rowCoordinate, columnCoordinate);
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
        public int SelectNextRowCoordinate(int previousRowCoordinate, int previousColumnCoordinate)
        {
            string numberRowCoordinate;
            int nextRowCoordinate;
            do
            {
                Console.WriteLine("Please select the next consecutive row:");
                if((previousRowCoordinate-1) > 0)
                {
                    Console.WriteLine((previousRowCoordinate - 1));
                }
                if ((previousRowCoordinate+1) < 21)
                {
                    Console.WriteLine((previousRowCoordinate + 1));
                }
                Console.WriteLine("(The coordinate must be an open coordinate)");
                numberRowCoordinate = Console.ReadLine();
                nextRowCoordinate = int.Parse(numberRowCoordinate);
                
            } while (BoardValidator(nextRowCoordinate, previousColumnCoordinate) != "Valid");
            return nextRowCoordinate;
        }
        public int SelectNextColumnCoordinate(int previousRowCoordinate, int previousColumnCoordinate)
        {
            string letterCoordinate;
            int nextColumnCoordinate;
            do
            {
                Console.WriteLine("Please select the next consecutive column: " + Map.NumbertoLetterCoordinate((previousColumnCoordinate-1)) + " or " + Map.NumbertoLetterCoordinate((previousColumnCoordinate+1)));
                if ((previousColumnCoordinate - 1) > 0)
                {
                    Console.WriteLine(Map.NumbertoLetterCoordinate((previousColumnCoordinate - 1)));
                }
                if ((previousColumnCoordinate + 1) < 21)
                {
                    Console.WriteLine(Map.NumbertoLetterCoordinate((previousColumnCoordinate + 1)));
                }
                Console.WriteLine("(The coordinate must be an open coordinate)");
                letterCoordinate = Console.ReadLine();
                nextColumnCoordinate = Map.LettersToNumberCoordinate(letterCoordinate);
            } while (BoardValidator(previousRowCoordinate, nextColumnCoordinate) != "Valid");
            return nextColumnCoordinate;
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
        public string BoardValidator(int rowCoordinate, int columnCoordinate)
        {
            if (Map.radar[rowCoordinate, columnCoordinate] != "| . |")
            {
                Console.WriteLine("Not a valid coordinate");
                return "NV";
            }
            else
            {
                return "Valid";
            }
        }
    }
}
