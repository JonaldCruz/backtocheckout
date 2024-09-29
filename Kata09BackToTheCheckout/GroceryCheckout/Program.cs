
using GroceryCheckout.Models.Item;
using GroceryCheckout.Models.PricingRule;
using GroceryCheckout.Models.PricingStrategy;
using GroceryCheckout.Services;

public class Program
{
    // not percentage
    // item count
    // dates avaiolable
    
    public static void Main(string[] args)
    {

        var item1 = new Item("COK-12OZ", 4);
        var item2 = new Item("NPL-WATER-16OZ", 30);
        var item3 = new Item("ARP-16OZ", 12);
        var item4 = new Item("FANTA-16OZ", 12);

        var itemsInventory = new Dictionary<string, Item>
        {
            { "COK-12OZ", item1 },
            { "NPL-WATER-16OZ", item2 },
            { "ARP-16OZ", item3 },
            { "FANTA-16OZ", item4}
        };
        
        
        var pricingRule1 = new PricingRule("COK-12OZ", new SpecialPriceStrategy(3, 10));
        var pricingRule2 = new PricingRule("NPL-WATER-16OZ", new BuyOneGetOneFreeStrategy());
        var pricingRule3 = new PricingRule("ARP-16OZ", new BulkDiscountStrategy(3, 10));
        var pricingRule4 = new PricingRule("FANTA-16OZ", new PercentageDiscountStrategy(0.50));
        //other pricing rules: 10% off; get 1 item free
        
        var pricingRules = new List<PricingRule>()
        {
            pricingRule1, pricingRule2 , pricingRule3, pricingRule4
        };
        

        var checkout = new CheckoutService(pricingRules, itemsInventory, new CartService());
        checkout.Scan("COK-12OZ");
        checkout.Scan("NPL-WATER-16OZ");
        checkout.Scan("NPL-WATER-16OZ");
        checkout.Scan("COK-12OZ");
        checkout.Scan("ARP-16OZ");
        checkout.Scan("ARP-16OZ");
        checkout.Scan("COK-12OZ");
        checkout.Scan("ARP-16OZ");
        checkout.Scan( "FANTA-16OZ");
       

        var total = checkout.ComputeTotal();
        Console.Write("Total Price: " + total);

    }
}