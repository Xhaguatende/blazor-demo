// -------------------------------------------------------------------------------------
//  <copyright file="IAccountServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Services.Interfaces;

using Dto;
using Models;

public interface IAccountServices
{
    Task<SignInResponse> SignInAsync(
        SignInRequest signInRequest,
        CancellationToken cancellationToken = default);
}