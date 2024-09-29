namespace GroceryCheckout.Models.Item;

public class Item(string sku, decimal price)
{
    public string Sku { get; } = sku;
    public decimal Price { get; } = price;
}