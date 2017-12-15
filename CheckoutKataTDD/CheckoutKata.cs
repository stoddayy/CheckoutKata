using System;
using System.Linq;

using System.Collections.Generic;

namespace CheckoutKataTDD {
    public class CheckoutKata {

        public List<Item> basketList;

        public CheckoutKata() {
            basketList = new List<Item>();
        }

        public int CheckoutBasket() {
            int basketPrice = 0;


            foreach (Item item in basketList) {
                basketPrice += item.price;
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
    }
}
