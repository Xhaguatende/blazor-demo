// -------------------------------------------------------------------------------------
//  <copyright file="Category.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Models;

public class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
}