using System;
using Xunit;
using CheckoutKataTDD;
using System.Collections.Generic;

namespace CheckoutKataTDD.Tests {
    public class UnitTest1 {


  //      Item Unit      Special
  //   Price     Price
  //--------------------------
    //A     50       3 for 130
    //B     30       2 for 45
    //C     20
    //D     15

        CheckoutKata helper;

        //1. Checkout returns a value -> X
        //2. basket stores items -> X
        //3. can remove item from basket -> X
        //4. cant remove item out of bounds -> X
        //5. basket can calculate price on checkout (Without rules) -> X
        //6. Can calculate basket with rules where all items are the same
        //7. basket can calculate price on checkout with pricing rules

        public UnitTest1(){
            helper = new CheckoutKata();
        }


        [Fact]
        public void CheckoutReturnsValue() {
            Assert.NotNull(helper.CheckoutBasket());
        }

        [Fact]
        public void BasketStoresItems() {
            Item item1 = new Item {
                name = "A"
            };
            Item item2 = new Item();
            item1.name = "B";

            helper.AddItemToBasket(item1);
            helper.AddItemToBasket(item2);

            Assert.True(helper.basketList.Count > 0);
            Assert.True(helper.basketList.Count == 2);

        }


        [Fact]
        public void CanRemoveItemFromBasket(){
            Item item1 = new Item();
            item1.name = "A";

            helper.AddItemToBasket(item1);
            helper.AddItemToBasket(item1);

            helper.RemoveItemFromBasket(1);

            Assert.True(helper.basketList.Count == 1);
        }


        [Fact]
        public void CanNotRemoveItemOutOfBounds(){
            Item item1 = new Item();
            item1.name = "A";

            helper.AddItemToBasket(item1);
            helper.AddItemToBasket(item1);

            Exception e = Assert.Throws<IndexOutOfRangeException>(() => { helper.RemoveItemFromBasket(2); });
        }

        [Fact]
        public void CanCalculateBasketPriceWithoutRules(){
            Item item1 = new Item();
            item1.name = "A";
            item1.price = 50;

            Item item2 = new Item();
            item2.name = "B";
            item2.price = 30;

            helper.AddItemToBasket(item1);
            helper.AddItemToBasket(item2);

            int basketPrice = helper.CheckoutBasket();

            Assert.Equal(80, basketPrice);

        }


        [Fact]
        public void CanCalculateBasketPriceWithSameItemsAndRules() {
            Item item1 = new Item {
                id = 1,
                name = "A",
                price = 50
            };
            PricingRules rules = new PricingRules {
                quantity = 3,
                price = 120
            };

            item1.rules = rules;


            helper.AddItemToBasket(item1);
            helper.AddItemToBasket(item1);
            helper.AddItemToBasket(item1);

            int basketPrice = helper.CheckoutBasket();

            Assert.Equal(120, basketPrice);
        }
    }
}
