using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3 {
    public class Player : LivingEntity {

        public string Name { get; set; }
        public int Level { get; set; }
        public int AttackDamage { get; set; }

        public Player() {
            Health = 100;
            AttackDamage = 10;
        }
        public int Attack() {
            return AttackDamage;
        }


    }
}
