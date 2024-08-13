using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using StoreCleanArchitecture.Application.Interfaces.Email;

namespace StoreCleanArchitecture.Infrastucture.Services;

public class EmailSender(IConfiguration configuration) : IEmailSender
{
    public async Task<bool> SendEmailAsync(string email, string subject, string htmlMessage)
    {
        string login = configuration["Email:Login"]!;
        string password = configuration["Email:AppPassword"]!;

        SmtpClient client = new SmtpClient
        {
            Port = 587,
            Host = "smtp.gmail.com",
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(login, password)
        };

        var sendingEmailProcess = Task.Run(async () => 
            await client.SendMailAsync(login, email, subject, htmlMessage));

        await sendingEmailProcess;

        return sendingEmailProcess.IsCompleted;
    }
}
