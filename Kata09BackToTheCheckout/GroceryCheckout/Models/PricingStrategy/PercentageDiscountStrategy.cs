using GroceryCheckout.Models.PricingStrategy.Interface;

namespace GroceryCheckout.Models.PricingStrategy;

public class PercentageDiscountStrategy : IPricingStrategy
{
    private readonly double _discountPercentage;
    public PercentageDiscountStrategy(double discountPercentage)
    {
        _discountPercentage = discountPercentage;
    }

    public decimal Apply(int itemCount, decimal unitPrice)
    {
        // TODO implement buy 2 get 10 % off
        // here
        return itemCount * unitPrice * (decimal)_discountPercentage;
    }
}