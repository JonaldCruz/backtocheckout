using GroceryCheckout.Models.Item;
using GroceryCheckout.Models.PricingRule;

namespace GroceryCheckout.Services;
public class CheckoutService
{
    private readonly Dictionary<string, Item> _itemsInventory;
    private List<PricingRule> _pricingRules;
    private readonly CartService _cartService;
    private decimal _runningTotal = 0m;

    public CheckoutService(List<PricingRule>  pricingRules, Dictionary<string, Item> itemsInventory, CartService cartService)
    {
        _pricingRules = pricingRules;
        _itemsInventory = itemsInventory;
        _cartService = cartService;
        _runningTotal = 0m;
    }
    
    public void Scan(string itemsSku, int quantity = 1)
    {
        var item = _itemsInventory.FirstOrDefault(i => i.Key.Equals(itemsSku)).Value;
        
        if (item is null) throw new Exception($"SKU {itemsSku} not found");
        
        _cartService.AddToCart(itemsSku, quantity);

        ComputeRunningTotal(item, quantity);
    }

    private void ComputeRunningTotal(Item item, int quantity)
    {
        var pricingRule = _pricingRules.FirstOrDefault(p => p.ItemSku.Equals(item.Sku));
        var curItemCount = _cartService.GetItemQuantity(item.Sku);
        
        if (pricingRule is not null)
        {
            var oldItemSubTotal = pricingRule.Apply(curItemCount - quantity, item.Price); 
            var newItemSubTotal = pricingRule.Apply(curItemCount, item.Price);
            _runningTotal += newItemSubTotal - oldItemSubTotal;
        }
        else
        {
            _runningTotal += curItemCount * item.Price;
        }
    }

    public decimal ComputeTotal()
    {
       return _runningTotal;
    }
    
    public void SetPricingRules(List<PricingRule> pricingRules)
    {
        _pricingRules = pricingRules;
    }
}