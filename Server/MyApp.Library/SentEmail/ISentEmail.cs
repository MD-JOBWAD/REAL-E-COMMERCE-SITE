using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Library.SentEmail
{
    public interface ISentEmail
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}
