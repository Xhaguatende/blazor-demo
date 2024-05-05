// -------------------------------------------------------------------------------------
//  <copyright file="RegisterResponse.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Models.Accounts;

public class RegisterResponse
{
    public string Email { get; set; } = default!;
    public bool Success { get; set; }
}