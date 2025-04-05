namespace Basket.Models;

public class ShoppingCartItem
{
    public int Quantity { get; set; } = default!;
    public string Color { get; set; } = string.Empty;
    public int ProductId { get; set; } = default!;

    // These below will come from the Catalog microservices
    public decimal Price { get; set; } = default!;
    public string ProductName { get; set; } = string.Empty;
}
