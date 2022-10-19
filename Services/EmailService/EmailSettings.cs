using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppServices.EmailService
{
    public class EmailSettings
    {
        public string FromEmail { get; set; }
        public string SMTP { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
