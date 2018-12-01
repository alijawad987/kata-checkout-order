using System.Collections.Generic;
using System.Linq;

namespace Kata.CheckoutOrderTotal
{
    public class Catalog
    {
        private readonly List<Product> _products;

        public Catalog()
        {
            _products = new List<Product>();
        }

        public Product this[string name] => _products.FirstOrDefault(x => x.Name == name);

        public IEnumerable<Product> Products => _products;

        public void Add(Product product)
        {
            _products.Add(product);
        }
    }
}