﻿using System.Linq;
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
                    UnitPrice = 3.99m,
                    Markdown = 0.50m,
                    Special =
                        new Special
                        {
                            ItemCount = 2,
                            Ratio = 0.50m,
                            Limit = 4
                        }
                });

            var addedProduct = catalog.Products.FirstOrDefault(x => x.Name == "Chicken Noodle Soup");
            Assert.NotNull(addedProduct);
            Assert.Equal("Chicken Noodle Soup", addedProduct.Name);
            Assert.Equal(3.99m, addedProduct.UnitPrice);
            Assert.Equal(0.50m, addedProduct.Markdown);
            Assert.NotNull(addedProduct.Special);
            Assert.Equal(2, addedProduct.Special.ItemCount);
            Assert.Equal(0.50m, addedProduct.Special.Ratio);
            Assert.Equal(4, addedProduct.Special.Limit);
        }
    }
}