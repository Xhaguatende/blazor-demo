// -------------------------------------------------------------------------------------
//  <copyright file="ProductsClient.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Clients;

using Models;
using Services.Interfaces;

public class ProductsClient
{
    private readonly IProductServices _productServices;

    public ProductsClient(IProductServices productServices)
    {
        _productServices = productServices;
    }

    public async Task AddProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _productServices.UpsertProductAsync(product, cancellationToken);
    }

    public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _productServices.DeleteProductAsync(id, cancellationToken);
    }

    public async Task<Product> GetProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _productServices.GetProductByIdAsync(id, cancellationToken);

        return product;
    }

    public async Task<List<ProductSummary>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        var products = await _productServices.GetProductsAsync(cancellationToken);

        return products;
    }

    public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _productServices.UpsertProductAsync(product, cancellationToken);
    }
}