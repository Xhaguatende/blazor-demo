// -------------------------------------------------------------------------------------
//  <copyright file="SignInSimpleResponse.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Models;

public class SignInSimpleResponse
{
    public string Message { get; set; } = default!;
    public bool Success { get; set; }
}