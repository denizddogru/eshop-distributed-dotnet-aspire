using ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<ProductDbContext>(connectionName: "catalogDb");
builder.Services.AddScoped<ProductService>();
builder.Services.AddMassTransitWithAssemblies(Assembly.GetExecutingAssembly());


var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();

app.UseMigration();

// Expose product for CatalogAPI
app.MapProductEndpoints();

app.UseHttpsRedirection();

app.Run();

