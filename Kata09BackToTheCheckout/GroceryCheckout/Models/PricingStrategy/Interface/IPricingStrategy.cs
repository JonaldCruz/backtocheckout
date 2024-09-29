namespace GroceryCheckout.Models.PricingStrategy.Interface;

public interface IPricingStrategy
{ 
    decimal Apply(int itemCount, decimal unitPrice);
}