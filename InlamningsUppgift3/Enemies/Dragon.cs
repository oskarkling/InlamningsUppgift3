using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3.Enemies {
    public class Dragon : Monster {

        public Dragon() {
                       
        }

        public Dragon(Player player) {
            base.GenerateStats(player, "Dragon");
        }


        public override int Attack() {
            return Utility.RandomInt(this.MinAttack, this.MaxAttack);
        }
    }
}
