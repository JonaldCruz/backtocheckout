namespace GroceryCheckout.Services;

public class CartService
{
    private readonly Dictionary<string, int> _scannedItems = new();
    
    public void AddToCart(string sku, int quantity = 1)
    {
        if (_scannedItems.TryGetValue(sku, out int count))
        {
            _scannedItems[sku] = count + quantity;
        }
        else
        {
            _scannedItems[sku] = quantity;
        }
    }

    public void RemoveFromCart(string sku, int quantity = 1)
    {
        
    }

    public int GetItemQuantity(string itemSku)
    {
        return _scannedItems.FirstOrDefault(x => x.Key == itemSku).Value;
    }
}