namespace Kata.CheckoutOrderTotal
{
    public class Product
    {
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Markdown { get; set; }

        public Special Special { get; set; }

        public decimal Calculate(int itemCount)
        {
            var markedDownUnitPrice = UnitPrice - Markdown;
            if (Special != null)
            {
                return markedDownUnitPrice + (markedDownUnitPrice * Special.Ratio * (itemCount - 1));
            }

            return markedDownUnitPrice * itemCount;
        }
    }
}