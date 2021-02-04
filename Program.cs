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
            NavalBattlefield navalBattlefield = new NavalBattlefield();
            navalBattlefield.RunGame();
            navalBattlefield.RestartGame(navalBattlefield.restartGame);
            Console.ReadLine();
        }
    }
}
