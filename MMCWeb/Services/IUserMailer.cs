using Mvc.Mailer;

namespace MMCWeb.Services
{
    public interface IUserMailer
    {
        MvcMailMessage PasswordReset();
        MvcMailMessage SendEmail(IEmailInfo emailInfo);

    }
}
