using System;
using System.Collections.Generic;

namespace CheckoutKataTDD {
    public class CheckoutKata {

        public List<Item> basketList;

        public CheckoutKata() {
            basketList = new List<Item>();
        }

        public Double CheckoutBasket() {
            return 12.0;
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
