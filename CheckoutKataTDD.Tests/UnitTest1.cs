using System;
using Xunit;
using CheckoutKataTDD;

namespace CheckoutKataTDD.Tests {
    public class UnitTest1 {

        //1. Checkout returns a value
        //2. basket stores items
        //3. basket can calculate price on checkout (Without rules)
        //4. basket can recognise multiples of the same item
        //5. basket can calculate price on checkout with pricing rules


        [Fact]
        public void CheckoutReturnsValue() {
            CheckoutKata kata = new CheckoutKata();
            Assert.NotNull(kata.CheckoutBasket());
        }

        [Fact]
        public void BasketStoresItems() {

        }

        [Fact]
        public void BasketPriceCalculatedOnCheckout() {

        }
    }
}
