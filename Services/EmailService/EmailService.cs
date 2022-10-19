using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace TestAppServices.EmailService
{
    public class EmailService:IEmailService
    {
        EmailSettings setting;
        public EmailService(EmailSettings _settings) { 
           setting = _settings; 
        }
        /// <summary>
        /// Method used to send the email
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public UserServiceResponse<bool> SendEmail(string toEmail,string html) {
            UserServiceResponse<bool> userServiceResponse = new UserServiceResponse<bool>();
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(setting.FromEmail);
                message.To.Add(new MailAddress(toEmail));
                message.Subject = Constant.SIGNUP_EMAIL;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = html;
                smtp.Port = setting.Port;
                smtp.Host = setting.SMTP; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(setting.Username, setting.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                userServiceResponse.Success = true;
            }
            catch (Exception ex) {
                userServiceResponse.Success = false;
                userServiceResponse.Error=ex.Message;
            }
            return userServiceResponse;
        }
    }
}
