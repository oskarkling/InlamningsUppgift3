using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace InlamningsUppgift3 {
    public class Item {

        public string Name { get; private set; }
        public int Price { get; private set; }
        public string StatName { get; private set; }

        public int StatValue { get; private set; }

        public Item() {

        }

        public Item(string name, int price, string statName, int statValue) {
            this.Name = name;
            this.Price = price;
            this.StatName = statName;
            this.StatValue = statValue;
        }
    }
}
