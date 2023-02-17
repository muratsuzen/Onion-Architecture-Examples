using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EmailService : IEmailService
    {
        public bool Send(string to, string subject, string body)
        {
            Console.WriteLine("mail send");
            return true;
        }
    }
}
