using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    private readonly int _keySize = 64;
    private readonly int _iterations = 350000;
    private readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;
    public string SignIn(UserSignInDto user)
    {
        // User mappedUser = _mapper.Map<User>(user);
        // return null;
        throw new NotImplementedException();
    }

    public async Task<string> Register(UserRegisterDto user)
    {
        User mappedUser = _mapper.Map<User>(user);
        
        //if email exists in DB return empty string as jwt token 
        if (_usersDbContext.Users.Where(u => u.Email == mappedUser.Email).Count() > 0)
            return string.Empty;
        
        string hashedPassword = HashPasword(user.Password, out byte[] salt);
        
        //init empty properties
        mappedUser.HashedPassword = hashedPassword;
        mappedUser.Salt = Convert.ToHexString(salt);
        mappedUser.Roles = ["User"];
        
        //add new user to db
        await _usersDbContext.Users.AddAsync(mappedUser);
        await _usersDbContext.SaveChangesAsync();
        
        //generate jwt token after saving a new user to DB
        string token = GenerateToken(mappedUser);
        return token;
    }
    
    string HashPasword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(_keySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _iterations,
            _hashAlgorithm,
            _keySize);
        return Convert.ToHexString(hash);
    }
    
    bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashAlgorithm, _keySize);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
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