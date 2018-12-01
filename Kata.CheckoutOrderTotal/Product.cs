namespace Kata.CheckoutOrderTotal
{
    public class Product
    {
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Markdown { get; set; }

        public Special Special { get; set; }
    }
}