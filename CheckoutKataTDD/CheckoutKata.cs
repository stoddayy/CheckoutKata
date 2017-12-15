using System;
using System.Linq;
using CheckoutKataTDD;
using System.Collections.Generic;

namespace CheckoutKataTDD {
    public class CheckoutKata {

        public List<Item> basketList;

        public CheckoutKata() {
            basketList = new List<Item>();
        }

        public int CheckoutBasket() {
            int basketPrice = 0;

            List<Item> matchedItems = new List<Item>();

            foreach (Item item in basketList) {

                if (item.rules == null) {
                    basketPrice += item.price;
                } else {
                    if (!matchedItems.Contains(item)) {
                        matchedItems.Add(item);
                        basketPrice += CalculateAllSameItems(basketList, item);
                    }
                }

            }

            return basketPrice;
        }

        public void AddItemToBasket(Item item) {
            basketList.Add(item);
        }

        public void RemoveItemFromBasket(int item){
            if(item > (basketList.Count -1)) {
                throw new IndexOutOfRangeException();
            }
            basketList.RemoveAt(item);
        }


        private int CalculateAllSameItems(List<Item> items, Item matchedItem){
            int price = 0;

            List<Item> itemsOfSameType = new List<Item>();

            for (int i = 0; i < items.Count(); i++) {
                if(items.ElementAt(i).id == matchedItem.id){
                    itemsOfSameType.Add(items.ElementAt(i));
                }
            }


            if(itemsOfSameType.Count() % matchedItem.rules.quantity == 0){
                int multiplier = (itemsOfSameType.Count() / matchedItem.rules.quantity);
                price = matchedItem.rules.price * multiplier;
            } else if (itemsOfSameType.Count() / matchedItem.rules.quantity > 0){
                int remainder = itemsOfSameType.Count() % matchedItem.rules.quantity;

                int x = itemsOfSameType.Count() - remainder;

                int multiplier = (x / matchedItem.rules.quantity);

                price = matchedItem.rules.price * multiplier;
                price += (remainder * matchedItem.price);
            } else {
                price = itemsOfSameType.Count() * matchedItem.price;
            }

            return price;
        }


    }
}
