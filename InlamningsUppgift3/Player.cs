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
        public int Toughness { get; set; }
        public bool GodMode { get; private set; }
        public double ExpSumRequierdPerLevel { get; set; }
        public List<Item> EquippedItems { get; set; }

        public Player() {
            //Some Base stats
            this.SetHealth(200);
            this.MaxAttack = 5;
            this.MinAttack = 2;
            this.Level = 1;
            this.Exp = 0;
            this.Gold = 0;
            this.Strength = 3;
            this.Toughness = 1;
            this.ExpSumRequierdPerLevel = 60;
            this.EquippedItems = new List<Item>();
        }

        #region Public Methods

        /// <summary>
        /// Returns an int of attack damage. Based on a random value between MinAttack and MaxAttack with added strength.
        /// </summary>
        /// <returns></returns>
        public int Attack() {
            return Utility.RandomInt(this.MinAttack + this.Strength, this.MaxAttack + this.Strength);
        }


        /// <summary>
        /// Updates the Exp of the player. 
        /// If player have more experience than experience needed for next level- the player will level up 
        /// </summary>
        /// <param name="exp"></param>
        public void UpdateExp(int exp) {
            Exp += exp;
            if (Exp >= this.ExpSumRequierdPerLevel) {
                Level++;
                Console.WriteLine($"You have reached Level {this.Level}! Congrats!");
                Console.WriteLine("You have also gained some health!");
                base.SetHealth(this.MaxHealth);

                this.ExpSumRequierdPerLevel = (this.ExpSumRequierdPerLevel + this.ExpSumRequierdPerLevel) * 1.1;
                //UpdateStats();
            }
        }

        public int PlayerTakeDamage(int damage) {
            damage -= this.Toughness;
            if(damage < 0) {
                damage = 0;
            }
            base.TakeDamage(damage);
            return damage;
        }

        /// <summary>
        /// Prints a stat summary of the Player.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            Console.Clear();
            string s = @$"**********
* Name: {this.Name}
* Level: {this.Level}
* Hp: {this.CurrentHealth} / {this.MaxHealth}
* Exp: {this.Exp} / {Convert.ToInt32(this.ExpSumRequierdPerLevel)}
* Gold: {this.Gold}
* Strength: {this.Strength}
* Toughness: {this.Toughness}
**********
";
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
                Console.WriteLine("You do not have that amount of gold.");
            } 
            else {
                this.Gold -= amountGoldToGive;
            }
            return amountGoldToGive;
        }

        /// <summary>
        /// Gives player over 9000 in stats.
        /// </summary>
        public void OmaeWaMouShindeiru() {
            this.GodMode = true;

            //Power level over 9000.
            this.Level = 9;
            this.SetHealth(9000 + 1);
            this.MaxAttack = 9000 + 1;
            this.MinAttack = 9000;
            this.Gold = 9999;

        }
        /// <summary>
        /// Player equip the item and adds it in a list containing item.
        /// </summary>
        /// <param name="item"></param>
        public void EquipItem(Item item) {
            EquippedItems.Add(item);
            UpdateStats();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Updates player stats depending whats inside the item list.
        /// </summary>
        private void UpdateStats() {
            foreach (Item item in EquippedItems) {
                if (item.StatName == "Toughness") {
                    Console.WriteLine("updating toughness");
                    this.Toughness += item.StatValue;
                }
                else if (item.StatName == "Strength") {
                    this.Strength += item.StatValue;
                }
            }
        }
        #endregion
    }
}
