namespace StoreCleanArchitecture.Application.DTOs.User;

public class UserSignInDto
{
    public required string Name { get; set; }
    public required string Password { get; set; }
}