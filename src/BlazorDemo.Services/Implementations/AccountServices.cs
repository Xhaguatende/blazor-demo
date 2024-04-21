// -------------------------------------------------------------------------------------
//  <copyright file="AccountServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.Services.Implementations;

using System.Net.Http.Json;
using Dto;
using Interfaces;
using Models;

public class AccountServices : IAccountServices
{
    private readonly HttpClient _httpClient;

    public AccountServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SignInResponse> SignInAsync(
        SignInRequest signInRequest,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "sign-in",
            signInRequest,
            cancellationToken: cancellationToken);

        return await response.Content.ReadFromJsonAsync<SignInResponse>(cancellationToken: cancellationToken) ??
               new SignInResponse
               {
                   Success = false,
                   Message = "An error occurred while signing in."
               };
    }
}