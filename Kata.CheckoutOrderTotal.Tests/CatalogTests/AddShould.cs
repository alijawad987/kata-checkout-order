using System.Linq;
using Xunit;

namespace Kata.CheckoutOrderTotal.Tests.CatalogTests
{
    public class AddShould
    {
        [Fact]
        public void AddProductToCatalog()
        {
            var catalog = new Catalog();
            catalog.Add(
                new Product
                {
                    Name = "Chicken Noodle Soup",
                    UnitPrice = 3.99m
                });

            var addedProduct = catalog.Products.FirstOrDefault(x => x.Name == "Chicken Noodle Soup");
            Assert.NotNull(addedProduct);
            Assert.Equal("Chicken Noodle Soup", addedProduct.Name);
            Assert.Equal(3.99m, addedProduct.UnitPrice);
        }
    }
}