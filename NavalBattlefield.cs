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
            WelcomeMessage();
            Player1 = new Player();
            Player2 = new Player();
            FirstTurnSelector();
        }

        public void RunGame()
        {

        }
        public void TurnSwitch()
        {
            Turn = !Turn;
        }
        public Player DetermineAttacker(bool Turn)
        {
            if (Turn == true)
            {
                return Player1;
            }
            else
            {
                return Player2;
            }
        }
        public Player DetermineDefender(bool Turn)
        {
            if(Turn == true)
            {
                return Player2;
            }
            else
            {
                return Player1;
            }
        }
        public void FirstTurnSelector()
        {
            Random random1 = new Random();
            Random random2 = new Random();
            int player1 = random1.Next(10);
            int player2 = random2.Next(10);
            if(player1 > player2)
            {
                Turn = true;
            }
            else
            {
                Turn = false;
            }
        }
        public void FireShot(Player attackingPlayer, Player defendingPlayer)
        {
            int fireRow;
            int fireColumn;
            Console.WriteLine("It's " + attackingPlayer.playername + "'s turn.");
            Console.ReadLine();
            do
            {
                attackingPlayer.DisplayEnemyMap();
                fireRow = attackingPlayer.FireShotRow();
                fireColumn = attackingPlayer.FireShotColumn();
            } while (ShotValidator(attackingPlayer, fireRow, fireColumn) == false);
            
            if (defendingPlayer.Map.radar[fireRow,fireColumn] == "| . |")
            {
                Console.WriteLine(attackingPlayer + " missed the shot.");
                attackingPlayer.EnemyMap.radar[fireRow, fireColumn] = "| M |";
            }
            else
            {
                Console.WriteLine(attackingPlayer + " hit the shot.");
                attackingPlayer.EnemyMap.radar[fireRow, fireColumn] = "| H |";
                defendingPlayer.Map.radar[fireRow, fireColumn] = "| H |";
                attackingPlayer.score++;
            }
            attackingPlayer.DisplayEnemyMap();
            DisplayMapChoice(attackingPlayer);
        }
        public bool ShotValidator(Player player, int row, int column)
        {
            bool valid;
            if (player.EnemyMap.radar[row, column] == "| . |")
            {
                valid = true;
                return valid;
            }
            else
            {
                valid = false;
                Console.WriteLine("A shot has already been fired at this coordinate. Choose a different coordinate.");
                return valid;
            }
        }
        public void DisplayMapChoice(Player player)
        {
            Console.WriteLine("Would you like to view your map? Y/N");
            string response = Console.ReadLine();
            if (response == "Y" || response == "Yes" || response == "yes" || response == "y")
            {
                player.Map.DisplayBoard();   
            }
        }
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Each player will get a chance to place their ships before the battle commences.");
            Console.WriteLine("The first turn will be randomly selected, from there, each player will take turns firing shots at their opponents board.");
            Console.WriteLine("A winner will be determined by the first player to sink the other players ship.");
            Console.WriteLine("Let's get started!");
        }

    }
}
