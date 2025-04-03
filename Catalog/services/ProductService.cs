namespace Catalog.services;

public class ProductService(ProductDbContext dbContext)
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
