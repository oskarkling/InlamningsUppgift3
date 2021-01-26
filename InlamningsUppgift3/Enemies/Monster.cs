using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3.Enemies {
    abstract public class Monster : LivingEntity, IMonster, IGold {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxAttack { get; set; }
        public int MinAttack { get; set; }
        public int Exp { get; set; }
        public string MonsterType { get; set; }

        public int Gold { get; private set; }

        public Monster() {          
            
        }

        abstract public int Attack();

        /// <summary>
        /// Generate stats for a monster. Based on player Level
        /// </summary>
        /// <param name="player"></param>
        /// <param name="monsterType"></param>
        public void GenerateStats(Player player, string monsterType) {
            this.Name = Utility.RandomMonsterName();
            this.Level = player.Level;
            this.MaxAttack = (player.MaxAttack / 2) * player.Level;
            this.MinAttack = (player.MinAttack / 2) * player.Level;
            this.Exp = 20 * player.Level;
            this.MaxHealth = 50 + Convert.ToInt32(50 + (player.Level * 1.1)); // Need to balance
            this.SetHealth(this.MaxHealth);
            this.MonsterType = monsterType;
            this.Gold = 10 + Convert.ToInt32((1.1 * player.Level));
        }

        public int GetGold() {
            return this.Gold;
        }

    }
}
