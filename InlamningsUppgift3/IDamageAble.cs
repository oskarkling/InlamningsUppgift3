using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningsUppgift3 {
    interface IDamageAble {

        int Health { get; set; }
        void TakeDamage(int damage);
    }
}
