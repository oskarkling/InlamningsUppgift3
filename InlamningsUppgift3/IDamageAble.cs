using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3 {
    interface IDamageAble {

        int MaxHealth { get; set; }
        int CurrentHealth { get; }
        void TakeDamage(int damage);
    }
}
