// -------------------------------------------------------------------------------------
//  <copyright file="ProductSummary.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Models;

public class ProductSummary
{
    public Category Category { get; set; } = default!;
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}