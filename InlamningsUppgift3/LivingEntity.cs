using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3 {
    public abstract class LivingEntity : IDamageAble {

        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public bool IsDead { get; set; }

        public virtual void TakeDamage(int damage) {
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
            MaxHealth = Convert.ToInt32(health);
            CurrentHealth = MaxHealth;
        }
    }
}