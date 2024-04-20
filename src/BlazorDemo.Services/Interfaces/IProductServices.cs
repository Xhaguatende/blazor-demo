// -------------------------------------------------------------------------------------
//  <copyright file="IProductServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Services.Interfaces;

using Models;

public interface IProductServices
{
    Task DeleteProductAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<ProductSummary>> GetProductsAsync(CancellationToken cancellationToken = default);

    Task UpsertProductAsync(Product product, CancellationToken cancellationToken = default);
}