using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace InlamningsUppgift3 {
    public class Player : LivingEntity {

        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxAttack { get; set; }
        public int MinAttack { get; set; }
        public int Exp { get; set; }

        private double expSumRequierdPerLevel = 60;

        public Player() {
            //Some Base stats
            SetHealth(200);
            MaxAttack = 10;
            MinAttack = 5;
            Level = 1;
            Exp = 0;
        }
        public Player(int health, int maxAttack, int minAttack, int level) {
            SetHealth(health);
            MaxAttack = maxAttack;
            MinAttack = minAttack;
            Level = level;
            Exp = 0;
        }
        public int Attack() {
            return Utility.RandomInt(MinAttack, MaxAttack);
        }

        public void UpdateExp(int exp) {
            Exp += exp;
            
            if(Exp >= expSumRequierdPerLevel) {
                Level++;
                Console.WriteLine($"You have reached Level {Level}! Congrats!");
                Exp = 0;

                //Exp requierd is +10% per level
                expSumRequierdPerLevel = 1.5 * expSumRequierdPerLevel;
                UpdateStats();
                Console.WriteLine("You have also gained some health!");
                SetHealth(this.MaxHealth);
            }
        }

        private void UpdateStats() {
            //TODO implement stats update. like +10% / Level
        }

        public override string ToString() {
            string s = @$"{Name}
Level: {Level}
Exp needed for next level: {expSumRequierdPerLevel - Exp}
Attack damage: {MinAttack} - {MaxAttack} 
Health: {CurrentHealth} / {MaxHealth}";
            return s;
        }

    }
}
