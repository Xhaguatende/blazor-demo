// -------------------------------------------------------------------------------------
//  <copyright file="ProductServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Services.Implementations;

using Base;
using Interfaces;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models.Products;

public class ProductServices : ServiceBase, IProductServices
{
    public ProductServices(HttpClient httpClient, ProtectedSessionStorage sessionStorage)
        : base(httpClient, sessionStorage)
    {
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await this.DeleteAsync($"{id}", cancellationToken);
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await this.GetAsync<List<Product>>(string.Empty, cancellationToken);

        return products ?? [];
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await this.GetAsync<Product>($"{id}", cancellationToken) ?? default!;

        return product;
    }

    public async Task UpsertAsync(UpsertProduct product, CancellationToken cancellationToken = default)
    {
        await this.PostAsync(string.Empty, product, cancellationToken);
    }
}