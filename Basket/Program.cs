using ServiceDefaults;

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

builder.Services.AddAuthentication() // Sets up .NET auth pipeline
    .AddKeycloakJwtBearer(
    serviceName: "keycloak",
    realm: "eshop",
    configureOptions: options =>
    {
        options.RequireHttpsMetadata = false;
        options.Audience = "account";
    });
builder.Services.AddAuthorization(); 

var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();
app.MapBasketEndpoints();

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();


