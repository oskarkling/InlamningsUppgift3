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
            this.MaxAttack = maxAttack;
            this.MinAttack = minAttack;
            this.Level = level;
            this.Exp = 0;
        }

        #region Public Methods
        public int Attack() {
            return Utility.RandomInt(this.MinAttack, this.MaxAttack);
        }

        public void UpdateExp(int exp) {
            Exp += exp;

            if (Exp >= expSumRequierdPerLevel) {
                Level++;
                Console.WriteLine($"You have reached Level {this.Level}! Congrats!");
                Exp = 0;

                //Exp requierd is +10% per level
                expSumRequierdPerLevel = 1.5 * expSumRequierdPerLevel;
                UpdateStats();
                Console.WriteLine("You have also gained some health!");
                SetHealth(this.MaxHealth);
            }
        }


        public override string ToString() {
            string s = @$"{this.Name}
Level: {this.Level}
Exp needed for next level: {expSumRequierdPerLevel - this.Exp}
Attack damage: {this.MinAttack} - {this.MaxAttack} 
Health: {Convert.ToInt32(this.CurrentHealth)} / {Convert.ToInt32(this.MaxHealth)}";
            return s;
        }
        #endregion

        #region Private Methods
        private void UpdateStats() {
            //TODO implement stats update. like +10% / Level
        }
        #endregion
    }
}
