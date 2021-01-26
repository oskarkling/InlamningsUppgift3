using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InlamningsUppgift3 {
    public class Shop {

        public List<Item> Items { get; private set; }
        public int BankGold { get; private set; }

        private int playerLevel;
        private const int basePriceAmuletToughness = 20;
        private const int basePriceAmuletStrength = 30;

        public Shop() {
            Items = new List<Item>();

            this.Items.Add(new Item("Amulet of Tougness", basePriceAmuletToughness, "Toughness", 2));
            this.Items.Add(new Item("Amulet of Strength", basePriceAmuletStrength, "Strength", 3));
            this.BankGold = 0;
            playerLevel = 1;
        }

        /// <summary>
        /// Returns a List of added items from shop.
        /// </summary>
        /// <returns></returns>
        public List<Item> GetItemsFromShop() {
            return this.Items;
        }


        /// <summary>
        /// The shop menu. Where player decide what items should be bought.
        /// </summary>
        /// <param name="player"></param>
        public void ShopMenu(Player player) {
            CheckPlayerLevel(player);
            if(Items.Count == 0) {
                Console.WriteLine("No items for sale right now. \nLevel up and check in again");
            }
            else {
                Console.WriteLine(@$"Welcome! What do you want to buy?
You have {player.Gold} gold.");
                while(true) {
                    for(int i = 0; i < Items.Count; i++) {
                        Console.WriteLine($"{i + 1}. {Items[i].Name} (+ {Items[i].StatValue} {Items[i].StatName}) - {Items[i].Price} gold");
                    }
                    Console.WriteLine("E. Exit shop");
                    if (Items.Count > 0) {                       
                        int input;
                        string inputString = Console.ReadLine();
                        try {
                            input = Convert.ToInt32(inputString);
                            if(input < Items.Count) {
                                if (player.Gold >= Items[input - 1].Price) {
                                    Console.Clear();
                                    Console.WriteLine($"You bought {Items[input - 1].Name}");
                                    Console.WriteLine("You can feel its power");
                                    player.EquipItem(Items[input - 1]);
                                    player.GiveGold(Items[input - 1].Price);
                                    Items.RemoveAt(input - 1);
                                    Console.WriteLine($"You have {player.GetGold()} gold.");
                                }
                                else {
                                    Console.WriteLine("You do not have the money");
                                }
                            }
                            else {
                                Console.WriteLine($"You must enter a number from 1 to {Items.Count}");
                            }

                        }
                        catch {
                            inputString = inputString.ToLower();
                            if (inputString == "e") {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else {
                        Console.WriteLine("Shop is now out of stock");
                        Console.WriteLine("[press enter to continu]");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }                                      
                }
            }
        }

        /// <summary>
        /// Checking player level if shop should be updated with new items
        /// </summary>
        /// <param name="player"></param>
        private void CheckPlayerLevel(Player player) {
            if (player.Level > playerLevel) {
                UpdateShop(player);
                playerLevel = player.Level;
            }
        }

        /// <summary>
        /// Adding more items to Shop, scaling +20% from player level. Only price so far.
        /// </summary>
        /// <param name="player"></param>
        private void UpdateShop(Player player) {
            double newPriceTou = Convert.ToDouble(basePriceAmuletToughness);
            double newPriceStr = Convert.ToDouble(basePriceAmuletStrength);

            for(int i = 0; i < player.Level; i++) {
                newPriceTou = newPriceTou * 1.2;
                newPriceStr = newPriceStr * 1.2;
            }

            this.Items.Add(new Item("Amulet of Tougness", Convert.ToInt32(newPriceTou), "Toughness", 2));
            this.Items.Add(new Item("Amulet of Strength", Convert.ToInt32(newPriceStr), "Strength", 3));
        }
    }
}
