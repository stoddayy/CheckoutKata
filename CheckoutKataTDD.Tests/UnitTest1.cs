using System;
using Xunit;
using CheckoutKataTDD;

namespace CheckoutKataTDD.Tests {
    public class UnitTest1 {


        CheckoutKata helper;

        //1. Checkout returns a value -> X
        //2. basket stores items
        //3. can remove item from basket
        //4. cant remove item out of bounds
        //5. basket can calculate price on checkout (Without rules)
        //6. basket can recognise multiples of the same item
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
            Item item1 = new Item();
            item1.name = "A";

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

    }
}
