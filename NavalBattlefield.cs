using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_
{
    class NavalBattlefield
    {
        public Player Player1 = new Player();
        public Player Player2 = new Player();
        public bool Turn;
        public NavalBattlefield()
        {
            Player1 = new Player();
            Player2 = new Player();
        }

        public void RunGame()
        {

        }
        public void TurnSwitch()
        {
            Turn = !Turn;
        }

    }
}
