using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}
