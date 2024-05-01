using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Service.Interfaces.Auth
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string email, string message, string subject);
    }
}
