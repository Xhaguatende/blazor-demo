// -------------------------------------------------------------------------------------
//  <copyright file="SignIn.cshtml.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Pages;

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services.Interfaces;

public class SignInModel : PageModel
{
    private readonly IAccountServices _accountServices;

    public SignInModel(IAccountServices accountServices)
    {
        _accountServices = accountServices;
    }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var signInRequest = new SignInRequest
        {
            Email = Email,
            Password = Password
        };

        var signInResponse = await _accountServices.SignInAsync(signInRequest);

        if (!signInResponse.Success)
        {
            ModelState.AddModelError(string.Empty, signInResponse.Message);
            return Page();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, Email),  // Assuming you use Email as username
            new("AccessToken", signInResponse.AccessToken, ClaimValueTypes.String),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        // Configure the authentication properties
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTime.UtcNow.AddSeconds(signInResponse.ExpiresIn)
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

        return Redirect("/");
    }
}