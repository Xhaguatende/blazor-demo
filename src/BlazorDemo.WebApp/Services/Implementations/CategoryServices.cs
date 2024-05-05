// -------------------------------------------------------------------------------------
//  <copyright file="CategoryServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Services.Implementations;

using Base;
using Interfaces;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models.Products;

public class CategoryServices : ServiceBase, ICategoryServices
{
    public CategoryServices(HttpClient httpClient, ProtectedSessionStorage sessionStorage)
        : base(httpClient, sessionStorage)
    {
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var categories = await GetAsync<List<Category>>(string.Empty, cancellationToken);

        return categories ?? [];
    }

    public async Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await GetAsync<Category>($"{id}", cancellationToken);

        return category ?? default!;
    }
}