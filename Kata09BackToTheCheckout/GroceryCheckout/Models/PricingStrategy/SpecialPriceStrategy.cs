using GroceryCheckout.Models.PricingStrategy.Interface;

namespace GroceryCheckout.Models.PricingStrategy;

public class SpecialPriceStrategy : IPricingStrategy
{
    private readonly int _minQuantity;
    private readonly decimal _specialPrice;

    public SpecialPriceStrategy(int minQuantity, decimal specialPrice)
    {
        _minQuantity = minQuantity;
        _specialPrice = specialPrice;
    }

    public decimal Apply(int itemCount, decimal unitPrice)
    {
        var discountedSets = itemCount / _minQuantity;
        var remainingItems = itemCount % _minQuantity;
        return (discountedSets * _specialPrice) + (remainingItems * unitPrice);
    }
}