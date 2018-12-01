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
                Markdown = null,
                Special = null
            };

            var total = product.Calculate(itemCount: 1);

            Assert.Equal(1.99m, total);
        }
    }
}