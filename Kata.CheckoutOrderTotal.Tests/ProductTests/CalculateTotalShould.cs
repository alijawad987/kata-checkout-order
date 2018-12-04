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
                        BuyCount = 1,
                        SpecialCount = 1,
                        Limit = 0,
                        Ratio = 0.5m, // Buy one get one 50% off
                    }
            };

            var total = product.Calculate(2);

            Assert.Equal(3.0m, total);
        }

        [Fact]
        public void CalculatePriceWithBothMarkdownAndSpecialWithExceededItemCountLimit()
        {
            var product = new Product
            {
                UnitPrice = 2.0m,
                Markdown = 1.0m,
                Special =
                    new Special
                    {
                        BuyCount = 1, // Buy one get one at special price...
                        SpecialCount = 1, // Special applies to 1 count of item...
                        Ratio = 0.5m, // ... Special price is 50% of marked down unit price
                        Limit = 2 // Only max of 2 items will be given special pricing
                    }
            };

            // 4 x $1 for markdown price
            // 2 x $0.50 for special price
            // Total should be $5.00
            var total = product.Calculate(6);

            Assert.Equal(5.0m, total);
        }

        [Fact]
        public void CalculatePriceWithNotEnoughItemsToMeetSpecialRequirements()
        {
            var product = new Product
            {
                UnitPrice = 2.0m,
                Markdown = 1.0m,
                Special = new Special { BuyCount = 7, SpecialCount = 1, Limit = 0, Ratio = 0.50m }
            };

            var total = product.Calculate(6);

            Assert.Equal(6.0m, total);
        }
    }
}