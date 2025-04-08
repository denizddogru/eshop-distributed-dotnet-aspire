using Basket.ApiClients;
using ServiceDefaults;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.AddServiceDefaults();
builder.AddRedisDistributedCache(connectionName: "cache");
builder.Services.AddScoped<BasketService>();

builder.Services.AddHttpClient<CatalogApiClient>(client =>
{
    //client.BaseAddress = new Uri(builder.Configuration["ApiUrls:Catalog"]);
    client.BaseAddress = new("https+http://catalog");
});



//Assembly → .NET’te bir derleme (DLL).
//GetExecutingAssembly() → Şu an çalışan assembly’yi alır.
//AddMassTransitWithAssemblies(...) → Belirtilen assembly’lerdeki tüketicileri otomatik ekler.

builder.Services.AddMassTransitWithAssemblies(Assembly.GetExecutingAssembly());

var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();
app.MapBasketEndpoints();


app.UseHttpsRedirection();

app.Run();


