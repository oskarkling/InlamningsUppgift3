using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3.Enemies {
    public class Wolf : Monster {
        public Wolf() {

        }

        public Wolf(Player player) {
            base.GenerateStats(player, "Wolf");
        }

        public override int Attack() {
            return Utility.RandomInt(this.MinAttack, this.MaxAttack);
        }
    }
}
