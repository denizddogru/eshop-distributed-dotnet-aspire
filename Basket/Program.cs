var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.AddServiceDefaults();
builder.AddRedisDistributedCache("cache");
builder.Services.AddScoped<BasketService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();
app.MapBasketEndpoints();


app.UseHttpsRedirection();


