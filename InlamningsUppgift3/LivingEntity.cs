using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3 {
    public abstract class LivingEntity : IDamageAble {

        public double MaxHealth { get; set; }
        public double CurrentHealth { get; private set; }
        public bool IsDead { get; set; }

        public void TakeDamage(int damage) {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) {
                IsDead = true;
            }
        }

        /// <summary>
        /// Sets the heath of a "Living object."
        /// </summary>
        /// <param name="health"></param>
        public void SetHealth(int health) {
            MaxHealth = health;
            CurrentHealth = MaxHealth;
        }

        /// <summary>
        /// Sets the health of a "Living object"
        /// </summary>
        /// <param name="health"></param>
        public void SetHealth(double health) {
            MaxHealth = health;
            CurrentHealth = MaxHealth;
        }
    }
}