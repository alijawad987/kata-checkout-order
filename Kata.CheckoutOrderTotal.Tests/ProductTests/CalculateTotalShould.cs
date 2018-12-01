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

        [Fact]
        public void CalculatePriceForMultipleUnitsWithMarkdownButNoSpecial()
        {
            var product = new Product
            {
                UnitPrice = 1.99m,
                Markdown = 0.99m,
                Special = null
            };

            var total = product.Calculate(2);

            Assert.Equal(2.0m, total);
        }

        [Fact]
        public void CalculatePriceWithSpecialOnly()
        {
            var product = new Product
            {
                UnitPrice = 2.0m,
                Markdown = 0.0m,
                Special =
                    new Special
                    {
                        Ratio = 0.5m, // Buy one get one 50% off
                        Limit = 2
                    }
            };

            var total = product.Calculate(2);

            Assert.Equal(3.0m, total);
        }
    }
}