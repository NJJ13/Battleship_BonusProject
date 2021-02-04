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
        public bool restartGame;
        public NavalBattlefield()
        {
            WelcomeMessage();
            Player1 = new Player();
            Player2 = new Player();
            FirstTurnSelector();
        }

        public void RunGame()
        {
            while (Player1.fleetStrength != 0 && Player2.fleetStrength != 0)
            {
                RunTurn();
                Console.Clear();
            }
            if(Player1.fleetStrength == 0)
            {
                EndGameMessage(Player2);
            }
            if (Player2.fleetStrength == 0)
            {
                EndGameMessage(Player1);
            }
        }
        public void RunTurn()
        {
            FireShot(DetermineAttacker(Turn), DetermineDefender(Turn));
            TurnSwitch();
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
                defendingPlayer.fleetStrength--;
            }
            attackingPlayer.DisplayEnemyMap();
            DisplayMapChoice(attackingPlayer);
        }
        public bool ShotValidator(Player player, int row, int column)
        {
            if (player.EnemyMap.radar[row, column] == "| . |")
            {
                return true;
            }
            else
            {
                Console.WriteLine("A shot has already been fired at this coordinate. Choose a different coordinate.");
                return false;
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
        public void EndGameMessage(Player winner)
        {
            Console.WriteLine(winner.playername + " has won the game.");
            Console.WriteLine("Would you like to play again Y/N");
            string response = Console.ReadLine();
            if (response == "Y" || response == "Yes" || response == "yes" || response == "y")
            {
                restartGame = true;
            }
            else
            {
                restartGame = false;
                Console.WriteLine("Thanks for playing Battleship!");
            }
        }
        public void RestartGame(bool restartGame)
        {
            if (restartGame == true)
            {
                Player1.Map.ResetBoard();
                Player1.EnemyMap.ResetBoard();
                Player1.PopulateFleetStrength();
                Player1.PlaceShips();
                Console.Clear();
                Player2.Map.ResetBoard();
                Player2.EnemyMap.ResetBoard();
                Player2.PopulateFleetStrength();
                Player2.PlaceShips();
                RunGame();

            }
        }
    }
}
