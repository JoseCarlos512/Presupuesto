using System.Net.Mail;
using Presupuestos.Application.Abstractions.Email;

namespace Presupuestos.Infrastructure.Email;

public class EmailServices : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailServices(EmailSettings emailSettings)
    {
        _emailSettings = emailSettings;
    }

    public async Task SendAsnyc(string correoElectronico, string subject, string body)
    {
        using var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
        {
            Credentials = new System.Net.NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword),
            EnableSsl = true
        };

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(_emailSettings.SenderEmail);
        mailMessage.Subject = subject;
        mailMessage.Body = body;
        mailMessage.IsBodyHtml = false;
    

        mailMessage.To.Add(correoElectronico);

        await smtpClient.SendMailAsync(mailMessage);
    }
}