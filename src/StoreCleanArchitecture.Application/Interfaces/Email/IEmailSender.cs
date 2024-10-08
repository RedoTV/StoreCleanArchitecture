namespace StoreCleanArchitecture.Application.Interfaces.Email;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(string email, string subject, string htmlMessage);
}
