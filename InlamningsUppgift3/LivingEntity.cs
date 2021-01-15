using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3 {
    public class LivingEntity : IDamageAble {

        private int health;
        private bool isDead;
        public int Health {
            get { return health;}
            set { health = value; }
        }

        public bool IsDeaD {
            get { return isDead; }
        }
        
        public void TakeDamage(int damage) {
            health -= damage;
            if(health < 0 ) {
                isDead = true;
            }
        }
    }
}