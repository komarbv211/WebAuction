using Core.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace Core.Services
{
    public class EmailService : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var data = _configuration.GetSection(nameof(MailData)).Get<MailData>()!;

            // Create the email message
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(data.Email));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = htmlMessage };

            // Send the email
            using var smtp = new SmtpClient();
            try
            {
                await smtp.ConnectAsync(data.Host, data.Port, SecureSocketOptions.SslOnConnect); 
                await smtp.AuthenticateAsync(data.Email, data.Password);
                await smtp.SendAsync(message);
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, rethrow, etc.)
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
            finally
            {
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
