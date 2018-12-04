using Xunit;

namespace Kata.CheckoutOrderTotal.Tests.BasketTests
{
    public class AddShould
    {
        private readonly Catalog _catalog;
        private readonly Basket _basket;

        public AddShould()
        {
            _catalog = new Catalog();
            _catalog.Add(new Product { Name = "cheese wheel", UnitPrice = 1.0m });
            _catalog.Add(new Product { Name = "donut", UnitPrice = 2.0m });
            _catalog.Add(new Product { Name = "pizza", UnitPrice = 10.0m });

            _basket = new Basket(_catalog);
        }

        [Fact]
        public void AddOneItemIntoTheBasket()
        {
            _basket.Add("pizza");

            Assert.Equal(1, _basket.Count);
        }

        [Fact]
        public void AddSeveralPizzaItemsIntoTheBasket()
        {
            _basket.Add("pizza");
            _basket.Add("pizza");

            Assert.Equal(2, _basket["pizza"]);
        }

        [Fact]
        public void AddItemsToBasketThenRemoveOne()
        {
            _basket.Add("donut");
            _basket.Add("donut");
            _basket.Add("donut");

            _basket.Remove("donut");

            Assert.Equal(2, _basket["donut"]);
        }
    }
}