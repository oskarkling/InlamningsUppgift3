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
            Console.WriteLine("Loading in objects");
            runGame = true;
            player = new Player();
            
        }

        private void Start() {           
            Console.WriteLine(@"
************************
* Welcome to The Game! *
************************");
            //Simple while loop to check if There is a atleast a character in the input.
            while (true) {
                Console.WriteLine("Enter your name: ");
                string input = Console.ReadLine();
                if (input != "" && input != null) {
                    player.Name = input;
                    break;
                }
                Console.WriteLine("You did not enter a name");
            }
            GameLogic();
        }

        private void GameLogic() {
            while(runGame) {
                if(player.Level == 10) {
                    Console.WriteLine("You won the game");
                    runGame = false;
                } else if (player.IsDead == true) {
                      Console.WriteLine("You died and lost the game");
                    runGame = false;
                } else {
                    Menu();
                }
            }
        }

        private void Menu() {
            int nrOfMenuChoices = 3;
            Console.WriteLine(@"
1. Go Adventuring
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

        private void ShowPlayerDetails() {
            Console.WriteLine(player.ToString());
        }

        private void GoAdventure() {
            if(Utility.RandomInt(1, 100) > 10) {
                Battle();
            } else {
                Console.WriteLine(@"Youu see nothing but swaying grass all around you...
[Press enter to continue]");
                Console.ReadKey();
            }
        }

        private void Battle() {
            Console.WriteLine(@"UH OH! A Wild Monster appeared!");

            Monster monster = Utility.GenerateRandomMonster(player);

            




            


            //TODO Implement A battle


        }
        
        #endregion
    }
}
