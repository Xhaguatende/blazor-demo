// -------------------------------------------------------------------------------------
//  <copyright file="Product.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Services.Dto;

using Models;

public class Product
{
    public Category Category { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Models.Product ToProduct()
    {
        return new Models.Product
        {
            CategoryId = Category.Id,
            Description = Description,
            Id = Id,
            Name = Name,
            Price = Price,
            Stock = Stock
        };
    }

    public ProductSummary ToSummary()
    {
        return new ProductSummary
        {
            Category = new Models.Category
            {
                Id = Category.Id,
                Name = Category.Name
            },
            Id = Id,
            Name = Name,
            Price = Price,
            Stock = Stock
        };
    }
}