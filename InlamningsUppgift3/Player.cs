using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;

namespace InlamningsUppgift3 {
    public class Player : LivingEntity, IGold {

        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxAttack { get; set; }
        public int MinAttack { get; set; }
        public int Exp { get; set; }
        public int Gold { get; private set; }
        public int Strength { get; private set; }
        public int Toughness { get; private set; }

        public bool GodMode { get; private set; }

        private double expSumRequierdPerLevel = 60;

        public Player() {
            //Some Base stats
            this.SetHealth(200);
            this.MaxAttack = 10;
            this.MinAttack = 5;
            this.Level = 1;
            this.Exp = 0;
            this.Gold = 0;
            this.Strength = 5;
            this.Toughness = 2;
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

        //Maybe dont need this
        //public override void TakeDamage(int damage) {         
        //    this.CurrentHealth -= damage;
        //    if (this.CurrentHealth <= 0) {
        //        this.IsDead = true;
        //    }
        //}
        public int PlayerTakeDamage(int damage) {
            damage -= this.Toughness;
            if(damage < 0) {
                damage = 0;
            }
            TakeDamage(damage);
            return damage;
        }

        //TODO Implement strength in attack dmg
        //TODO write Shop.cs
        //

        /// <summary>
        /// Prints a stat summary of the Player.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            Console.Clear();
            string s = @$"{this.Name}
Level: {this.Level}
Exp needed for next level: {expSumRequierdPerLevel - this.Exp}
Attack damage: {this.MinAttack} - {this.MaxAttack} 
Health: {this.CurrentHealth} / {this.MaxHealth}
Strength: {this.Strength}
Toughness: {this.Toughness}
Gold: {this.Gold}";
            return s;
        }
        
        public int GetGold() {
            return this.Gold;
        }

        public void LootGold(int amountGold) {
            this.Gold += amountGold;
        }

        public int GiveGold(int amountGoldToGive) {
            if(this.Gold - amountGoldToGive <= 0) {
                Console.WriteLine("You do not have the gold");
            } 
            else {
                this.Gold -= amountGoldToGive;
            }
            return amountGoldToGive;
        }

        public void OmaeWaMouShindeiru() {
            this.GodMode = true;

            //Power level over 9000.
            this.Level = 9;
            this.SetHealth(9000 + 1);
            this.MaxAttack = 9000 + 1;
            this.MinAttack = 9000;
            this.Gold = 9999;

        }
        #endregion

        #region Private Methods
        private void UpdateStats() {
            //TODO implement stats update. like +10% / Level
        }

        #endregion
    }
}
