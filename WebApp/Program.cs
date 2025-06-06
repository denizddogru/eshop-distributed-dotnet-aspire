using WebApp.ApiClients;
using WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddServiceDefaults();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//// Register CatalogApiClient with HttpClient
//builder.Services.AddHttpClient<CatalogApiClient>(client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "https://localhost:5001");
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
