using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Application.Interfaces.Auth;

public interface IAuthService
{
    public string GenerateToken(User user);
}