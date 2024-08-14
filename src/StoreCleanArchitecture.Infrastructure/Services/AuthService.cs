using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StoreCleanArchitecture.Application.DTOs.User;
using StoreCleanArchitecture.Application.Interfaces.Auth;
using StoreCleanArchitecture.Domain.Entities;
using StoreCleanArchitecture.Domain.Settings.Auth;
using StoreCleanArchitecture.Infrastructure.DbContexts;

namespace StoreCleanArchitecture.Infrastructure.Services;

public class AuthService(UsersDbContext _usersDbContext, IMapper _mapper) : IAuthService
{
    public string SignIn(UserSignInDto user)
    {
        // User mappedUser = _mapper.Map<User>(user);
        // return null;
        throw new NotImplementedException();
    }

    public string Register(UserRegisterDto user)
    {
        throw new NotImplementedException();
    }

    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AuthSettings.PrivateKey);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
    
    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));

        foreach (var role in user.Roles)
            claims.AddClaim(new Claim(ClaimTypes.Role, role));

        return claims;
    }
}