// -------------------------------------------------------------------------------------
//  <copyright file="UpsertProduct.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Models.Products;

using System.ComponentModel.DataAnnotations;

public class UpsertProduct
{
    [Required(ErrorMessage = "The category is required.")]
    public Guid CategoryId { get; set; } = default!;

    [Required]
    [StringLength(500)]
    public string Description { get; set; } = default!;

    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = default!;

    [Range(0.01, 100)]
    public decimal Price { get; set; }

    [Range(1, 1000)]
    public int Stock { get; set; }
}