using GroceryCheckout.Models.PricingStrategy.Interface;

namespace GroceryCheckout.Models.PricingStrategy;
public class BulkDiscountStrategy : IPricingStrategy
{
    private readonly int _bulkQuantity;
    private readonly decimal _bulkPricePerItem;

    public BulkDiscountStrategy(int bulkQuantity, decimal bulkPricePerItem)
    {
        _bulkQuantity = bulkQuantity;
        _bulkPricePerItem  = bulkPricePerItem;
    }

    public decimal Apply(int itemCount, decimal unitPrice)
    {
        if (itemCount >= _bulkQuantity)
        {
            return itemCount * _bulkPricePerItem;
        }
        return itemCount * unitPrice;
    }
}