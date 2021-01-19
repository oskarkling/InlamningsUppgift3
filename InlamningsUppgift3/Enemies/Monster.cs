using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3.Enemies {
    abstract public class Monster : LivingEntity, IMonster {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxAttack { get; set; }
        public int MinAttack { get; set; }
        public int Exp { get; set; }

        public Monster() {          
            
        }

        abstract public int Attack();

    }
}
