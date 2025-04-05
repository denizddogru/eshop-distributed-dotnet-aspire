namespace Basket.Models;

public class ShoppingCart
{
    public string UserName { get; set; } = string.Empty;
    public List<ShoppingCartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
}
