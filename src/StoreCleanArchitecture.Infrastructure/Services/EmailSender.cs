using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using StoreCleanArchitecture.Application.Interfaces.Email;

namespace StoreCleanArchitecture.Infrastructure.Services;

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
        {
            var message = new MailMessage(login, email, subject, htmlMessage);
            message.IsBodyHtml = true;
            await client.SendMailAsync(message);
        });

        await sendingEmailProcess;

        return sendingEmailProcess.IsCompleted;
    }
}
