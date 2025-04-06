using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.Services;

//  Add caching logic.
public class BasketService(IDistributedCache cache, CatalogApiClient catalogApiClient) // Using primary constructor
{
    public async Task<ShoppingCart?> GetBasket(string userName)
    {
        var basket = await cache.GetStringAsync(userName);
        if (string.IsNullOrEmpty(basket))
            return null;
        return JsonSerializer.Deserialize<ShoppingCart>(basket);
    }

    public async Task UpdateBasket(ShoppingCart basket)
    {

        // Before updating basket, we should call Catalog ms GetProductById
        // Get latest product information and set Price and ProductName when adding item

        foreach(var item in basket.Items)
        {
            var product = await catalogApiClient.GetProductById(item.ProductId);
            item.Price = product.Price;
            item.ProductName = product.Name;
        }
        // Set the basket in the cache
        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));
    }

    public async Task DeleteBasket(string userName)
    {
        await cache.RemoveAsync(userName);
    }
}
