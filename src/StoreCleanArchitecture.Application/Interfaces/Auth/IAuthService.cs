using StoreCleanArchitecture.Application.DTOs.User;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Application.Interfaces.Auth;

public interface IAuthService
{
    public string SignIn(UserSignInDto user);
    public string Register(UserRegisterDto user);
    public string GenerateToken(User user);
}