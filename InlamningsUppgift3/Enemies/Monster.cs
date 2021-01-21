using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3.Enemies {
    abstract public class Monster : LivingEntity, IMonster {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxAttack { get; set; }
        public int MinAttack { get; set; }
        public int Exp { get; set; }
        public string MonsterType { get; set; }

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
            this.MaxAttack = player.MaxAttack / 2;
            this.MinAttack = player.MinAttack / 2;
            this.Exp = 20 * player.Level;
            this.MaxHealth = player.MaxHealth / 4;
            this.SetHealth(this.MaxHealth);
            this.MonsterType = monsterType;
            
        }

    }
}
