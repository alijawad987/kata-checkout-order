using System.Collections.Generic;

namespace Kata.CheckoutOrderTotal
{
    public class Basket
    {
        private readonly Catalog _catalog;
        private readonly Dictionary<string, int> _contents;

        public Basket(Catalog catalog)
        {
            _catalog = catalog;
            _contents = new Dictionary<string, int>();
        }

        public void Add(string productName)
        {
            if (_contents.ContainsKey(productName))
            {
                _contents[productName] += 1;
            }
            else
            {
                _contents.Add(productName, 1);
            }
        }

        public void Remove(string productName)
        {
            if (_contents.ContainsKey(productName))
            {
                var count = _contents[productName];
                count--;
                if (count < 0)
                {
                    count = 0;
                }

                _contents[productName] = count;
            }
        }

        public int this[string productName] => _contents[productName];

        public decimal CalculateTotal()
        {
            var sum = 0.0m;
            foreach (var productCountPair in _contents)
            {
                var product = _catalog[productCountPair.Key];
                sum += product.Calculate(productCountPair.Value);
            }

            return sum;
        }
    }
}