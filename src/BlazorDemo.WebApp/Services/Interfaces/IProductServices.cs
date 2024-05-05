// -------------------------------------------------------------------------------------
//  <copyright file="IProductServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Services.Interfaces;

using Models.Products;

public interface IProductServices
{
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task UpsertAsync(UpsertProduct product, CancellationToken cancellationToken = default);
}