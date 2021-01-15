using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InlamningsUppgift3 {
    public class Game {

        private bool lostGame, wonGame;
        private Player player;


        public Game() {

        }
        #region Public Methods
        public void Run() {
            Console.WriteLine("Running game");
            Load();
            Start();
        }
        #endregion

        #region Private Methods
        private void Load() {
            Console.WriteLine("Loading in objects");
            player = new Player();

        }

        private void Start() {
            Console.WriteLine(@"
************************
* Welcome to The Game! *
************************
Enter your name: ");
            string input = Console.ReadLine();            
            player.Name = input;




        }
        #endregion
    }
}
