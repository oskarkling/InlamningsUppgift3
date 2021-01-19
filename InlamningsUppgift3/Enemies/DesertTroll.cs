using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3.Enemies {
    public class DesertTroll : Monster {

        public string MonsterType { get; private set; }

        public DesertTroll() {

        }
        public DesertTroll(int level, int maxAttack, int minAttack, int exp, int health) {
            this.Name = Utility.RandomMonsterName();
            this.Level = level;
            this.MaxAttack = maxAttack;
            this.MinAttack = minAttack;
            this.Exp = exp;
            this.MaxHealth = health;
            this.SetHealth(health);
            this.MonsterType = "Desert Troll";
        }

        public override int Attack() {
            return Utility.RandomInt(this.MinAttack, this.MaxAttack);
        }
    }
}
