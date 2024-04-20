// -------------------------------------------------------------------------------------
//  <copyright file="ICategoryServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Services.Interfaces;

using Models;

public interface ICategoryServices
{
    Task<List<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default);

    Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default);
}