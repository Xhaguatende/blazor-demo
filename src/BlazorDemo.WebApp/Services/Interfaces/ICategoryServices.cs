// -------------------------------------------------------------------------------------
//  <copyright file="ICategoryServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Services.Interfaces;

using Models.Products;

public interface ICategoryServices
{
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}