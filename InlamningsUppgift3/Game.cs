using InlamningsUppgift3.Enemies;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace InlamningsUppgift3 {
    public class Game {
       
        private bool runGame;
        private Player player;

        public Game() {

        }
        #region Public Methods
        public void Run() {
            Load();
            Start();
        }
        #endregion

        #region Private Methods

        //Method is creating instances of objects
        private void Load() {
            runGame = true;
            player = new Player();
            //Could have made a list here of monsters
            //Or a list of IMonster
        }

        private void Start() {           
            Console.WriteLine(@"************************
* Welcome to The Game! *
************************");
            //Simple while loop to check if There is a atleast one char in the input from user.
            while (true) {
                Console.WriteLine("Enter your name: ");
                string input = Console.ReadLine();
                if (input != "" && input != null) {
                    player.Name = input;
                    Console.Clear();
                    break;
                }
                Console.WriteLine("You did not enter anything for a name.");
            }
            GameLogic();
        }

        //The loop inside GameLogic will loop through the game. If it stops. The game is over in some way.
        private void GameLogic() {
            while(runGame) {
                if(player.Level == 10) {
                    Console.WriteLine("You won the game");
                    runGame = false;
                } else if (player.IsDead) {
                      Console.WriteLine("You died and lost the game");
                    runGame = false;
                } else {
                    Menu();
                }
            }
        }

        //Simple Menu switch with user input.
        private void Menu() {
            int nrOfMenuChoices = 3;
            Console.WriteLine(@"1. Go Adventuring
2. Show details about your character
3. Exit game
");
            switch(Utility.GetIntInputChoice(nrOfMenuChoices)) {
                case 1:
                    Console.Clear();
                    GoAdventure();
                    break;
                case 2:
                    Console.Clear();
                    ShowPlayerDetails();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Bye bye");
                    runGame = false;
                    break;
            }                
        }

        //Overrides the toString() in the player class.
        private void ShowPlayerDetails() {
            Console.WriteLine(player.ToString());
        }

        //Method that randoms if there will be a battle or not.
        private void GoAdventure() {
            if(Utility.RandomInt(1, 100) > 10) {
                Battle();
            } else {
                Console.WriteLine(@"Youu see nothing but swaying grass all around you...
[Press enter to continue]");
                Console.ReadKey();
            }
        }

        //This method is for the battle simulation.
        private void Battle() {
            //Generate a random monster based on stats from player.
            Monster monster = Utility.GenerateRandomMonster(player);

            Console.WriteLine($"Uh oh! A Wild {monster.MonsterType} appeared!");
            Console.WriteLine($"His name is {monster.Name}");
            bool battling = true;
            while(battling) {
                int playerDamage = player.Attack();
                monster.TakeDamage(playerDamage);
                Console.WriteLine($"You hit {monster.Name}, dealing {playerDamage} damage");
                if(monster.IsDead) {
                    Console.WriteLine($"You killed {monster.Name}, gaining {monster.Exp} experience!");
                    player.UpdateExp(monster.Exp);
                    Console.WriteLine($"You are Level {player.Level} and you have {player.Exp} exp and {player.CurrentHealth} hp");
                    battling = false;
                } 
                else {
                    Console.WriteLine("UUooooaah *slurp* ");              
                    int monsterDamage = monster.Attack();
                    player.TakeDamage(monsterDamage);
                    Console.WriteLine($"{monster.Name} hit you dealing {monsterDamage}");
                    if(player.IsDead) {
                        Console.WriteLine($"You were killed by {monster.Name} :(");
                        battling = false;
                    }
                    Console.WriteLine($"{player.Name}: {player.CurrentHealth} hp");
                    Console.WriteLine($"{monster.Name}: {monster.CurrentHealth} hp");
                }               
                Console.WriteLine("[Press enter to continue]");
                Console.ReadKey();
                Console.Clear();                
            }
        }    
        #endregion
    }
}
