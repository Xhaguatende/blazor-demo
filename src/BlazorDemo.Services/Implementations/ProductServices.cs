// -------------------------------------------------------------------------------------
//  <copyright file="ProductServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Services.Implementations;

using System.Net.Http.Json;
using Interfaces;
using Models;

public class ProductServices : IProductServices
{
    private readonly HttpClient _httpClient;

    public ProductServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _httpClient.DeleteAsync(
            $"{id}",
            cancellationToken);
    }

    public async Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _httpClient.GetFromJsonAsync<Dto.Product>(
            $"{id}",
            cancellationToken: cancellationToken) ?? default!;

        return product.ToProduct();
    }

    public async Task<List<ProductSummary>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        var products = await _httpClient.GetFromJsonAsync<List<Dto.Product>>(
            "",
            cancellationToken: cancellationToken) ?? [];

        return products.Select(p => p.ToSummary()).ToList();
    }

    public async Task UpsertProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostAsJsonAsync(
                "",
                product,
                cancellationToken: cancellationToken).Result.Content
            .ReadFromJsonAsync<Dto.Product>(cancellationToken: cancellationToken);
    }
}