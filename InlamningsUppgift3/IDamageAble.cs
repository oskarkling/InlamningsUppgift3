using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3 {
    interface IDamageAble {

        double MaxHealth { get; set; }
        double CurrentHealth { get; }
        void TakeDamage(int damage);
    }
}
