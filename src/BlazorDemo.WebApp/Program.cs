using BlazorDemo.Services.Implementations;
using BlazorDemo.Services.Interfaces;
using BlazorDemo.WebApp.Clients;
using BlazorDemo.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddRazorComponents().AddInteractiveServerComponents();

services.AddHttpClient<IProductServices, ProductServices>(
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7225/api/products/");
    });

services.AddHttpClient<ICategoryServices, CategoryServices>(
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7225/api/categories/");
    });

services.AddSingleton<ProductsClient>();
services.AddSingleton<CategoriesClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();