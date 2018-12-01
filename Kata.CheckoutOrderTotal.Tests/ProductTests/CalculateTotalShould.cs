using Xunit;

namespace Kata.CheckoutOrderTotal.Tests.ProductTests
{
    public class CalculateTotalShould
    {
        [Fact]
        public void CalculatePriceForSingleUnitWithNoMarkdownOrSpecial()
        {
            var product = new Product
            {
                UnitPrice = 1.99m,
                Markdown = 0.0m,
                Special = null
            };

            var total = product.Calculate(itemCount: 1);

            Assert.Equal(1.99m, total);
        }

        [Fact]
        public void CalculatePriceForMultipleUnitsWithNoMarkdownOrSpecial()
        {
            var product = new Product
            {
                UnitPrice = 1.99m,
                Markdown = 0.0m,
                Special = null
            };

            var total = product.Calculate(itemCount: 2);

            Assert.Equal(3.98m, total);
        }

        [Fact]
        public void CalculatePriceForSingleUnitWithMarkdownButNoSpecial()
        {
            var product = new Product
            {
                UnitPrice = 1.99m,
                Markdown = 0.99m,
                Special = null
            };

            var total = product.Calculate(1);

            Assert.Equal(1.0m, total);
        }
    }
}