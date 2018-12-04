using System;

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
            if (Special == null)
            {
                return markedDownUnitPrice * itemCount;
            }

            var specialPricing = markedDownUnitPrice * Special.Ratio;
            var itemsAtRegularPricing = 0;
            var itemsAtSpecialPricing = 0;
            var specialsApplied = 0;
            while (itemCount > 0)
            {
                if (itemCount - (Special.BuyCount + Special.SpecialCount) < 0)
                {
                    itemsAtRegularPricing += itemCount;
                    break;
                }

                itemsAtRegularPricing += Special.BuyCount;
                itemsAtSpecialPricing += Special.SpecialCount;
                itemCount = itemCount - (Special.BuyCount + Special.SpecialCount);
                specialsApplied++;
                if (specialsApplied == Special.Limit)
                {
                    itemsAtRegularPricing += itemCount;
                    break;
                }
            }

            if (itemCount < 0)
            {
                throw new InvalidOperationException("Did not expect itemCount to be negative.");
            }

            return
                itemsAtRegularPricing * markedDownUnitPrice +
                itemsAtSpecialPricing * specialPricing;

            //var itemsAtMarkDownPricing = itemCount - (itemCount % Special.BuyCount);
            //var itemsAtSpecialPricing = 0;
            //var specialsUsed = 0;
            //while(itemCount > 0)
            //{
            //    if(specialsUsed >= Special.Limit)
            //    {
            //        itemsAtMarkDownPricing++;
            //        itemCount--;
            //        continue;
            //    }

            //    itemsAtMarkDownPricing += Special.BuyCount;
            //    itemsAtSpecialPricing += Special.SpecialCount;

            //}

            //var itemCountForMarkedDownUnitPrice = itemCount - Special.SpecialCount;
            //var itemCountAtSpecialPrice = itemCount - Special.BuyCount;
            //if (Special.Limit != 0 && itemCountAtSpecialPrice > Special.Limit)
            //{
            //    itemCountAtSpecialPrice = Special.Limit;
            //}

            //return
            //    itemCountForMarkedDownUnitPrice * markedDownUnitPrice +
            //    itemCountAtSpecialPrice * markedDownUnitPrice;

            //var countOfItemsAtMarkedDownUnitPrice = itemCount - Special.BuyCount;
            //var countOfItemsAtSpecialPrice = itemCount - Special.Limit;
            //return countOfItemsAtMarkedDownUnitPrice * markedDownUnitPrice + countOfItemsAtSpecialPrice * markedDownUnitPrice;

            //if (itemCount > Special.BuyCount)
            //{
            //    // Quota of item count exceeds the amount for the special to kick in.
            //    // We can apply the special pricing on the [special count] amount.
            //    var countOfItemsToApplySpecialPricingOn = itemCount - Special.BuyCount;
            //    if (Special.Limit != null && countOfItemsToApplySpecialPricingOn > Special.Limit)
            //    {
            //        countOfItemsToApplySpecialPricingOn = Special.Limit.Value;
            //    }

            //    var specialPricing = markedDownUnitPrice * Special.Ratio;
            //    return markedDownUnitPrice * Special.BuyCount + specialPricing * countOfItemsToApplySpecialPricingOn;
            //}

            //return markedDownUnitPrice * itemCount;
        }
    }
}