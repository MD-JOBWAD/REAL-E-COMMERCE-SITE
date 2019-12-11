using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Library.SentEmail
{
    public class SentEmail : ISentEmail
    {
        private readonly IHostingEnvironment _env;
        public SentEmail(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
                var configuration = builder.Build();


                var SenderName = configuration["EmailSettings:SenderName"]; 
                var Sender = configuration["EmailSettings:Sender"];
                var MailServer = configuration["EmailSettings:MailServer"];
                var MailPort = int.Parse(configuration["EmailSettings:MailPort"]); 
                var Password = configuration["EmailSettings:Password"];

                var mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress(SenderName, Sender));

                mimeMessage.To.Add(new MailboxAddress(email));

                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (_env.IsDevelopment())
                    {
                        await client.ConnectAsync(MailServer, MailPort, true);
                    }
                    else
                    {
                        await client.ConnectAsync(MailServer);
                    }

                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync(Sender, Password);

                    await client.SendAsync(mimeMessage);

                    await client.DisconnectAsync(true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
