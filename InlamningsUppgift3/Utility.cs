using System;
using InlamningsUppgift3.Enemies;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml;
using System.Threading;

namespace InlamningsUppgift3 {
    public static class Utility {

        /// <summary>
        /// Returns A random number from min to max.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RandomInt(int min, int max) {
            Random random = new Random();
            return random.Next(min, max + 1);
        }

        /// <summary>
        /// Takes in an string and checks if its an int and if the int is in the range of menuchoices.
        /// </summary>
        /// <param name="nrOfMenuChoices"></param>
        /// <returns></returns>
        public static int GetIntInputChoice(int nrOfMenuChoices) {
            int menuChoice;
            while (true) {
                try {
                    string input = Console.ReadLine();                   
                    menuChoice = Convert.ToInt32(input);
                    if (menuChoice <= nrOfMenuChoices && menuChoice != 0) {
                        break;
                    }
                    else {
                        Console.WriteLine($"Please enter a number from 1 to {nrOfMenuChoices}");
                    }
                }
                catch {
                    Console.WriteLine("You did not enter a number");
                }
            }
            return menuChoice;
        }

        


        /// <summary>
        /// Just returns a nanme in a stored string of names
        /// </summary>
        /// <returns></returns>
        public static string RandomMonsterName() {
            string[] names = new string[5] { "Darf Veder", "Steven", "Arthas", "Peter Stordalen", "Lasse Kongo" };
            string name = names[RandomInt(0, names.Length - 1)];
            return name;
        }

        /// <summary>
        /// Returns a random monster based on player level
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static Monster GenerateRandomMonster(Player player) {
            Monster monster = new Dragon();

            int random = RandomInt(1, 3);
            switch (random) {
                case 1:
                    monster = new Dragon(player);
                    break;
                case 2:
                    monster = new Wolf(player);
                    //monster = new DesertTroll();
                    break;
                case 3:
                    monster = new DesertTroll(player);
                    //monster = new Wolf();
                    break;
            }
            return monster;
        }

        /// <summary>
        /// Checking if the player name is someone of importance ^^
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsThisSenpai(string input) {
            bool res = false;
            input = input.ToLower();
            if (input == "robin" || input == "kakashi" || input == "senpai") {
                res = true;
            }
            return res;
        }

        /// <summary>
        /// If the player got God Mode true. A sequence of Nani in popculture shows.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="monster"></param>
        public static void Nani(Player player, Monster monster) {
            if (player.GodMode) {
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine($"\n{player.Name}: Omae Wa Mou Shindeiru");
                Thread.Sleep(3000);               
                Console.WriteLine($"\n{monster.Name}: NANI?\n");              
                Thread.Sleep(2000);
                Animations anim = new Animations();
                anim.ExplosionGodMode(player, monster);
            }
        }
    }
}
