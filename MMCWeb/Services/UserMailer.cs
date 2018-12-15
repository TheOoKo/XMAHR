using Mvc.Mailer;
using System.Net.Mail;

namespace MMCWeb.Services
{
    public class UserMailer : MailerBase, IUserMailer
    {

        public UserMailer()
        {

            MasterName = "_Layout";
        }

        public virtual MvcMailMessage SendEmail(IEmailInfo emailInfo)
        {
            ViewData.Model = emailInfo;
            return Populate(x =>
            {
                if (emailInfo.Sender != null)
                {
                    x.Sender = new MailAddress(emailInfo.Sender);
                }
                x.Subject = emailInfo.Subject;
                x.ViewName = emailInfo.ViewName;
                x.IsBodyHtml = true;
                x.To.Add(emailInfo.To);
                
                x.From = new MailAddress(emailInfo.From);
                

            });

        }
       
        public virtual MvcMailMessage PasswordReset()
        {

            return Populate(x =>
            {
                x.Subject = "PasswordReset";
                x.ViewName = "PasswordReset";
                x.To.Add("some-email@example.com");
            });
        }
    }
}