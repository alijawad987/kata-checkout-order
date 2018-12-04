using Xunit;

namespace Kata.CheckoutOrderTotal.Tests.BasketTests
{
    public class CalculateTotalShould
    {
        private readonly Catalog catalog;

        public CalculateTotalShould()
        {
            catalog = new Catalog();
            catalog.Add(new Product
            {
                Name = "soup",
                UnitPrice = 1.50m,
                Markdown = 0.25m
            });
            catalog.Add(new Product
            {
                Name = "mushrooms",
                UnitPrice = 2.0m,
                Markdown = 1.0m,
                Special = new Special { BuyCount = 1, SpecialCount = 1, Limit = 0, Ratio = 0.50m }
            });
            catalog.Add(new Product
            {
                Name = "munster cheese",
                UnitPrice = 4.0m,
                Markdown = 0.0m,
                Special = new Special { BuyCount = 2, SpecialCount = 1, Limit = 1, Ratio = 0.0m }
            });
        }

        [Fact]
        public void CalculateBasket()
        {
            var basket = new Basket(catalog);
            basket.Add("soup"); // should be $2.50 total (with the 2 soups)
            basket.Add("soup");
            basket.Add("mushrooms"); // should be $2.50 total also (with all 3 mushrooms)
            basket.Add("mushrooms");
            basket.Add("mushrooms");

            var total = basket.CalculateTotal();

            Assert.Equal(5.0m, total);
        }
    }
}