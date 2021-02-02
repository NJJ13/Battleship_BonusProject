using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_
{
    class Ship
    {
        public int shipSize;
        public string shipName;
        public string shipAbbreviation;

        public Ship(string name, int size, string abbreviation)
        {
            shipSize = size;
            shipName = name;
            shipAbbreviation = abbreviation;
        }
    }
}
