using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_
{
    class GameBoard
    {
        public string[,] radar = new string[21, 21];
        public GameBoard()
        {
            CreateBoard();
        }
        public void CreateBoard()
        {
            radar[0, 0] = "| #  |";
            radar[0, 1] = "| A |";
            radar[0, 2] = "| B |";
            radar[0, 3] = "| C |";
            radar[0, 4] = "| D |";
            radar[0, 5] = "| E |";
            radar[0, 6] = "| F |";
            radar[0, 7] = "| G |";
            radar[0, 8] = "| H |";
            radar[0, 9] = "| I |";
            radar[0, 10] = "| J |";
            radar[0, 11] = "| K |";
            radar[0, 12] = "| L |";
            radar[0, 13] = "| M |";
            radar[0, 14] = "| N |";
            radar[0, 15] = "| O |";
            radar[0, 16] = "| P |";
            radar[0, 17] = "| Q |";
            radar[0, 18] = "| R |";
            radar[0, 19] = "| S |";
            radar[0, 20] = "| T |";
            radar[1, 0] = "| 1  |";
            radar[2, 0] = "| 2  |";
            radar[3, 0] = "| 3  |";
            radar[4, 0] = "| 4  |";
            radar[5, 0] = "| 5  |";
            radar[6, 0] = "| 6  |";
            radar[7, 0] = "| 7  |";
            radar[8, 0] = "| 8  |";
            radar[9, 0] = "| 9  |";
            radar[10, 0] = "| 10 |";
            radar[11, 0] = "| 11 |";
            radar[12, 0] = "| 12 |";
            radar[13, 0] = "| 13 |";
            radar[14, 0] = "| 14 |";
            radar[15, 0] = "| 15 |";
            radar[16, 0] = "| 16 |";
            radar[17, 0] = "| 17 |";
            radar[18, 0] = "| 18 |";
            radar[19, 0] = "| 19 |";
            radar[20, 0] = "| 20 |";

            for (int i = 1; i < 21; i++)
            {
                for (int j = 1; j < 21; j++)
                {
                    radar[i, j] = "| . |";
                }
            }
        }
        public void DisplayBoard()
        {
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    Console.Write(radar[i, j]);
                }
                Console.WriteLine();
            }
        }
        public int LettersToNumberCoordinate(string letter)
        {
            int numericalCoordinate;
            if (letter == "A")
            {
                numericalCoordinate = 1;
                return numericalCoordinate;
            }
            else if (letter == "B")
            {
                numericalCoordinate = 2;
                return numericalCoordinate;
            }
            else if (letter == "C")
            {
                numericalCoordinate = 3;
                return numericalCoordinate;
            }
            else if (letter == "D")
            {
                numericalCoordinate = 4;
                return numericalCoordinate;
            }
            else if (letter == "E")
            {
                numericalCoordinate = 5;
                return numericalCoordinate;
            }
            else if (letter == "F")
            {
                numericalCoordinate = 6;
                return numericalCoordinate;
            }
            else if (letter == "G")
            {
                numericalCoordinate = 7;
                return numericalCoordinate;
            }
            else if (letter == "H")
            {
                numericalCoordinate = 8;
                return numericalCoordinate;
            }
            else if (letter == "I")
            {
                numericalCoordinate = 9;
                return numericalCoordinate;
            }
            else if (letter == "J")
            {
                numericalCoordinate = 10;
                return numericalCoordinate;
            }
            else if (letter == "K")
            {
                numericalCoordinate = 11;
                return numericalCoordinate;
            }
            else if (letter == "L")
            {
                numericalCoordinate = 12;
                return numericalCoordinate;
            }
            else if (letter == "M")
            {
                numericalCoordinate = 13;
                return numericalCoordinate;
            }
            else if (letter == "N")
            {
                numericalCoordinate = 14;
                return numericalCoordinate;
            }
            else if (letter == "O")
            {
                numericalCoordinate = 15;
                return numericalCoordinate;
            }
            else if (letter == "P")
            {
                numericalCoordinate = 16;
                return numericalCoordinate;
            }
            else if (letter == "Q")
            {
                numericalCoordinate = 17;
                return numericalCoordinate;
            }
            else if (letter == "R")
            {
                numericalCoordinate = 18;
                return numericalCoordinate;
            }
            else if (letter == "S")
            {
                numericalCoordinate = 19;
                return numericalCoordinate;
            }
            else if (letter == "T")
            {
                numericalCoordinate = 20;
                return numericalCoordinate;
            }
            else
            {
                return 0;
            }
        }
        public string NumbertoLetterCoordinate(int number)
        {
            string letterCoordinate;
            if (number == 1)
            {
                letterCoordinate = "A";
                return letterCoordinate;
            }
            else if (number == 2)
            {
                letterCoordinate = "B";
                return letterCoordinate;
            }
            else if (number == 3)
            {
                letterCoordinate = "C";
                return letterCoordinate;
            }
            else if (number == 4)
            {
                letterCoordinate = "D";
                return letterCoordinate;
            }
            else if (number == 5)
            {
                letterCoordinate = "E";
                return letterCoordinate;
            }
            else if (number == 6)
            {
                letterCoordinate = "F";
                return letterCoordinate;
            }
            else if (number == 7)
            {
                letterCoordinate = "G";
                return letterCoordinate;
            }
            else if (number == 8)
            {
                letterCoordinate = "H";
                return letterCoordinate;
            }
            else if (number == 9)
            {
                letterCoordinate = "I";
                return letterCoordinate;
            }
            else if (number == 10)
            {
                letterCoordinate = "J";
                return letterCoordinate;
            }
            else if (number == 11)
            {
                letterCoordinate = "K";
                return letterCoordinate;
            }
            else if (number == 12)
            {
                letterCoordinate = "L";
                return letterCoordinate;
            }
            else if (number == 13)
            {
                letterCoordinate = "M";
                return letterCoordinate;
            }
            else if (number == 14)
            {
                letterCoordinate = "N";
                return letterCoordinate;
            }
            else if (number == 15)
            {
                letterCoordinate = "O";
                return letterCoordinate;
            }
            else if (number == 16)
            {
                letterCoordinate = "P";
                return letterCoordinate;
            }
            else if (number == 17)
            {
                letterCoordinate = "Q";
                return letterCoordinate;
            }
            else if (number == 18)
            {
                letterCoordinate = "R";
                return letterCoordinate;
            }
            else if (number == 19)
            {
                letterCoordinate = "S";
                return letterCoordinate;
            }
            else if (number == 20)
            {
                letterCoordinate = "T";
                return letterCoordinate;
            }
            else
            {
                return "";
            }
        }
        public void CoordinateValidator(int rowCoordinate, int columnCoordinate)
        {
            if (radar[rowCoordinate, columnCoordinate] != "| . |")
            {
                Console.WriteLine("This coordinate can not be selected.");
            }
        }
        public void ResetBoard()
        {
            CreateBoard();
        }
    }
}
