namespace Catalog.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpotins(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");

        // GET all

        group.MapGet("/", async (ProductService productService) =>
        {
            var products = await productService.GetProductByAsync();
            return Results.Ok(products);
        })
        .WithName("GetAllProducts")
            .Produces<IEnumerable<Product>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

        // GET by id
        group.MapGet("/{id:int}", async (int id, ProductService productService) =>
        {
            var product = await productService.GetProductByIdAsync(id);
            return product is not null ? Results.Ok(product) : Results.NotFound();
        }).WithName
        ("GetProductById")
            .Produces<Product>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);

        // POST Create  
        group.MapPost("/", async (Product product, ProductService productService) =>
        {
            await productService.CreateProductAsync(product);
            return Results.Created($"/products/{product.Id}", product);
        }).WithName("CreateProduct")
            .Produces<Product>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        // PUT Update
        group.MapPut("/{id:int}", async (int id, Product inputProduct, ProductService productService) =>
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product is null)
                return Results.NotFound();
            await productService.UpdateProductAsync(product, inputProduct);
            return Results.NoContent();
        }).WithName("UpdateProduct")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);

        // DELETE 
        group.MapDelete("/{id:int}", async (int id, ProductService productService) =>
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product is null)
                return Results.NotFound();
            await productService.DeleteProductAsync(product);
            return Results.NoContent();
        }).WithName("DeleteProduct")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);
    }
}
