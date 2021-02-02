using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard();
            board.DisplayBoard();
            Console.ReadLine();
        }
    }
}
