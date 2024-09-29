using GroceryCheckout.Models.PricingStrategy.Interface;

namespace GroceryCheckout.Models.PricingRule;

public class PricingRule
{
    public string ItemSku { get; }
    private readonly IPricingStrategy _pricingStrategy;

    public PricingRule(string itemsku, IPricingStrategy pricingStrategy)
    {
        ItemSku = itemsku;
        _pricingStrategy = pricingStrategy;
    }

    public decimal Apply(int itemCount, decimal unitPice)
    {
        return _pricingStrategy.Apply(itemCount, unitPice);
    }
}