using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreCleanArchitecture.Application.DTOs.User;
using StoreCleanArchitecture.Application.Extentions;
using StoreCleanArchitecture.Application.Interfaces.Auth;
using StoreCleanArchitecture.Domain.Entities;
using StoreCleanArchitecture.Infrastructure.DbContexts;

namespace StoreCleanArchitecture.Infrastructure.Services;

public class AuthService(UsersDbContext _usersDbContext, IMapper _mapper, IConfiguration _configuration) : IAuthService
{
    private readonly int _keySize = 64;
    private readonly int _iterations = 350000;
    private readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA256;
    public string SignIn(UserSignInDto user)
    {
        // User mappedUser = _mapper.Map<User>(user);
        // return null;
        throw new NotImplementedException();
    }

    public async Task<string> Register(UserRegisterDto user)
    {
        User mappedUser = _mapper.Map<User>(user);
        
        //if request email not valid return empty string
        if (!mappedUser.ValidateEmail())
            throw new ValidationException("Email not valid");
        
        //if email exists in DB return empty string as jwt token 
        if (_usersDbContext.Users.Any(u => u.Email == mappedUser.Email))
            throw new ArgumentException("Email already exists");
        
        string hashedPassword = HashPasword(user.Password, out byte[] salt);
        
        //init empty properties
        mappedUser.HashedPassword = hashedPassword;
        mappedUser.Salt = Convert.ToHexString(salt);
        mappedUser.Role = "User";
        
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
        List<Claim> claimsForToken =
        [
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        ];
        
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claimsForToken,
            issuer: _configuration.GetSection("Jwt:Issuer").Value,
            audience: _configuration.GetSection("Jwt:Audience").Value,
            signingCredentials: credentials,
            expires: DateTime.Now.AddHours(6)
        );
            
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}