using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppServices.EmailService
{
    public interface IEmailService
    {
        UserServiceResponse<bool> SendEmail(string toEmail, string html);
    }
}
