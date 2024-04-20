// -------------------------------------------------------------------------------------
//  <copyright file="CategoryServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Services.Implementations;

using System.Net.Http.Json;
using Interfaces;
using Models;

public class CategoryServices : ICategoryServices
{
    private readonly HttpClient _httpClient;

    public CategoryServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<List<Category>>(
            "",
            cancellationToken: cancellationToken) ?? [];
    }

    public async Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<Category>(
            $"{id}",
            cancellationToken: cancellationToken) ?? default!;
    }
}