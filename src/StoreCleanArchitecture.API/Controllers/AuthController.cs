using Microsoft.AspNetCore.Mvc;
using StoreCleanArchitecture.Application.DTOs.User;
using StoreCleanArchitecture.Application.Interfaces.Auth;

namespace StoreCleanArchitecture.API.Controllers;

public class AuthController : Controller
{
    private IAuthService AuthService { get; set; }
    public AuthController(IAuthService authService)
    {
        AuthService = authService;
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegisterDto user)
    {
        string token = await AuthService.Register(user);
        if (token == string.Empty)
            return BadRequest("Email already exists");
        
        return Ok(token);
    }
}