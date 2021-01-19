using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3.Enemies {
    public class DesertTroll : Monster {

        public DesertTroll() {

        }
        public DesertTroll(Player player) {
            base.GenerateStats(player, "Desert Troll");
        }

        public override int Attack() {
            return Utility.RandomInt(this.MinAttack, this.MaxAttack);
        }
    }
}
