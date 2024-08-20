using Microsoft.AspNetCore.Mvc;
using StoreCleanArchitecture.Application.DTOs.User;
using StoreCleanArchitecture.Application.Interfaces.Auth;

namespace StoreCleanArchitecture.API.Controllers;

public class AuthController : Controller
{
    private IAuthService AuthService { get; }
    public ILogger<AuthController> Logger { get; }

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        AuthService = authService;
        Logger = logger;
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegisterDto user)
    {
        try
        {
            string token = await AuthService.Register(user);
            return Ok(token);
        }
        catch (Exception exc)
        {
            Logger.LogError(exc.Message);
            return BadRequest(exc.Message);
        }
    }
}