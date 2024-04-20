// -------------------------------------------------------------------------------------
//  <copyright file="CategoriesClient.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Clients;

using Models;
using Services.Interfaces;

public class CategoriesClient
{
    private readonly ICategoryServices _categoryServices;

    public CategoriesClient(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public async Task<List<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _categoryServices.GetCategoriesAsync(cancellationToken);
    }
}