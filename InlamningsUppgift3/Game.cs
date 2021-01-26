using InlamningsUppgift3.Enemies;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace InlamningsUppgift3 {
    public class Game {
        
        public bool RunGame { get; set; }
        public Player Player1 { get; set; }

        public Shop Shop1 { get; set; }

        public Game() {
            Load();
        }
        #region Public Methods
        public void Run() {           
            Console.WriteLine(@"************************
* Welcome to The Game! *
************************");           
            GetPlayerName();
            GameLogic();
        }
        #endregion

        #region Private Methods
        //Method is creating instances of objects
        private void Load() {
            RunGame = true;
            Player1 = new Player();
            
            Shop1 = new Shop();
            //Could have made a list here of monsters
            //Or a list of IMonster
        }

        //Simple method with while loop to check if There is a atleast one char in the input from user.
        private void GetPlayerName() {
            while (true) {
                Console.WriteLine("Enter your name: ");
                string input = Console.ReadLine();
                if (Utility.IsThisSenpai(input)) {
                    Player1.OmaeWaMouShindeiru();
                }
                if (input != "" && input != null) {
                    Player1.Name = input;
                    Console.Clear();
                    break;
                }
                Console.WriteLine("You did not enter anything for a name.");
            }
        }


        //The loop inside GameLogic will loop through the game. If it stops. The game is over in some way.
        private void GameLogic() {
            while(RunGame) {
                if(Player1.Level == 10) {
                    Console.WriteLine("You won the game");
                    RunGame = false;
                } 
                else if (Player1.IsDead) {
                      Console.WriteLine("You died and lost the game");
                    RunGame = false;
                } 
                else {
                    Menu();
                }
            }
        }

        //Simple Menu switch with user input.
        private void Menu() {
            int nrOfMenuChoices = 4;
            Console.WriteLine(@"1. Go Adventuring
2. Show details about your character
3. Go to shop
4. Exit game
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
                    ShopMenu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Bye bye");
                    RunGame = false;
                    break;
            }                
        }

        private void ShopMenu() {
            Shop1.ShopMenu(Player1);
        }

        //Overrides the toString() in the player class.
        private void ShowPlayerDetails() {
            Console.WriteLine(Player1.ToString());
        }

        //Method that randoms if there will be a battle or not.
        private void GoAdventure() {
            if(Utility.RandomInt(1, 100) > 10) {
                Battle();
            } 
            else {
                Console.WriteLine(@"Youu see nothing but swaying grass all around you...
[Press enter to continue]");
                Console.ReadKey();
            }
        }

        //This method is for the battle simulation.
        private void Battle() {
            //Generate a random monster based on stats from player.          
            Monster monster = Utility.GenerateRandomMonster(Player1);
            Console.WriteLine($"Uh oh! A Wild {monster.MonsterType} appeared!");
            Console.WriteLine($"His name is {monster.Name}");
            Utility.Nani(Player1, monster);
            bool battling = true;
            while(battling) {
                int playerDamage = Player1.Attack();
                monster.TakeDamage(playerDamage);
                Console.WriteLine($"You hit {monster.Name}, dealing {playerDamage} damage");
                if(monster.IsDead) {
                    Console.WriteLine($"You killed {monster.Name}, gaining {monster.Exp} experience!");
                    Player1.UpdateExp(monster.Exp);
                    Player1.LootGold(monster.GetGold());
                    Console.WriteLine($"You are Level {Player1.Level} and you have {Player1.Exp} exp and {Player1.CurrentHealth} hp");
                    battling = false;
                } 
                else {
                    Console.WriteLine("UUooooaah *slurp* ");
                    Console.WriteLine(" MONSTER ATTACK " + monster.Attack());
                    int monsterDamage = Player1.PlayerTakeDamage(monster.Attack());
                    Console.WriteLine($"{monster.Name} hit you dealing {monsterDamage}");
                    if(Player1.IsDead) {
                        Console.WriteLine($"You were killed by {monster.Name} :(");
                        battling = false;
                    }
                    Console.WriteLine($"{Player1.Name}: {Player1.CurrentHealth} hp");
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
