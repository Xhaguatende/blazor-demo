using BlazorDemo.Services.Implementations;
using BlazorDemo.Services.Interfaces;
using BlazorDemo.WebApp.Clients;
using BlazorDemo.WebApp.Components;
using BlazorDemo.WebApp.Extensions;
using BlazorDemo.WebApp.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddRazorPages();
services.AddRazorComponents().AddInteractiveServerComponents();

services.AddHttpContextAccessor();

builder.Services.AddOptions<ApiSettings>()
    .Bind(builder.Configuration.GetSection(nameof(ApiSettings)));

var apiSettingsOptions = services.GetRequiredService<IOptions<ApiSettings>>();

var apiSettings = apiSettingsOptions.Value;

services.AddHttpClient<IAccountServices, AccountServices>(
    client =>
    {
        client.BaseAddress = new Uri($"{apiSettings.BaseUrl}{apiSettings.AccountsRoute}");
    });

services.AddHttpClient<IProductServices, ProductServices>(
    client =>
    {
        client.BaseAddress = new Uri($"{apiSettings.BaseUrl}{apiSettings.ProductsRoute}");
    });

services.AddHttpClient<ICategoryServices, CategoryServices>(
    client =>
    {
        client.BaseAddress = new Uri($"{apiSettings.BaseUrl}{apiSettings.CategoriesRoute}");
    });

services.AddSingleton<ProductsClient>();
services.AddSingleton<CategoriesClient>();

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.Cookie.SecurePolicy = CookieSecurePolicy.None;// env.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
        option.Cookie.Name = "Test";
        option.Cookie.HttpOnly = true;
        option.Cookie.SameSite = SameSiteMode.Lax;
        option.LoginPath = "/sign-in";
        option.LogoutPath = "/sing-out";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        option.SlidingExpiration = true;
    });

 

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();