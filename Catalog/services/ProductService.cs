using MassTransit;
using ServiceDefaults.Messaging;

namespace Catalog.services;

public class ProductService(ProductDbContext dbContext, IBus bus)
{

    public async Task<IEnumerable<Product>>GetProductByAsync()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await dbContext.Products.FindAsync(id);
    }


    public async Task CreateProductAsync(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product updatedProduct, Product inputProduct)
    {

        // if price has changed, raise ProductPriceChanged integration event

        if(updatedProduct.Price != inputProduct.Price)
        {
            // Raise integration event here ( Publish Event )
            var integrationEvent = new ProductPriceChangeIntegrationEvent
            {
                ProductId = updatedProduct.Id, // Id comes from the db entity
                Name = updatedProduct.Name,
                Description = updatedProduct.Description,
                Price = updatedProduct.Price,
                ImageUrl = updatedProduct.ImageUrl
            };
            await bus.Publish(integrationEvent);

        }

        // Update the product details into the db -> Outbox pattern or saga pattern solves duality problems that could arise in the write events.
        updatedProduct.Name = inputProduct.Name;
        updatedProduct.Description = inputProduct.Description;
        updatedProduct.Price = inputProduct.Price;
        updatedProduct.ImageUrl = inputProduct.ImageUrl;
        
        dbContext.Products.Update(updatedProduct);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Product product)
    {
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();
    }
}
