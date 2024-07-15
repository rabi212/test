using System.Threading.Tasks;

namespace ITCGKP.Data.Services.ProvideService
{
    public interface IEmailService
    {        
        Task SendTestEmail(UserEmailOptions userEmailOption);
        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOption);
        Task SendEmailForForgotPassword(UserEmailOptions userEmailOption);
    }
}