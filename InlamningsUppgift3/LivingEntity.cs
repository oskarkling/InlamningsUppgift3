using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3 {
    public abstract class LivingEntity : IDamageAble {

        public int MaxHealth { get; set; }
        public int CurrentHealth { get; private set; }
        public bool IsDead { get; set; }

        public void TakeDamage(int damage) {
            CurrentHealth -= damage;
            if(CurrentHealth <= 0 ) {
                IsDead = true;
            }
        }

        public void SetHealth(int health) {
            MaxHealth = health;
            CurrentHealth = MaxHealth;
        }
    }
}