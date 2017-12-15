using System;
namespace CheckoutKataTDD {
    
    public class Item {

        public int id { get; set; }
        public int price { get; set; }
        public String name { get; set; }
        public PricingRules rules { get; set; }

        public Item() {
        }


    }
}
