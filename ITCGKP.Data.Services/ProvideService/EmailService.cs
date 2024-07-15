using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.ProvideService
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"wwwroot/EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpConfig;

        public EmailService(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }        
        public async Task SendTestEmail(UserEmailOptions userEmailOption)
        {
            userEmailOption.Subjet = UpdatePlaceHolder("Hello {{username}} This is test email from the itc lab master", userEmailOption.PlaceHolders);
            userEmailOption.Body = UpdatePlaceHolder(GetEmailBody("TestEmail"),userEmailOption.PlaceHolders);

            await SendEmail(userEmailOption);
        }
        public async Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOption)
        {
            userEmailOption.Subjet = UpdatePlaceHolder("Hello {{username}} reset yout password ", userEmailOption.PlaceHolders);
            userEmailOption.Body = UpdatePlaceHolder(GetEmailBody("EmailConfirm"), userEmailOption.PlaceHolders);

            await SendEmail(userEmailOption);
        }
        public async Task SendEmailForForgotPassword(UserEmailOptions userEmailOption)
        {
            userEmailOption.Subjet = UpdatePlaceHolder("Hello {{username}} Confirm your email id ", userEmailOption.PlaceHolders);
            userEmailOption.Body = UpdatePlaceHolder(GetEmailBody("ForgotPassword"), userEmailOption.PlaceHolders);

            await SendEmail(userEmailOption);
        }
        private async Task SendEmail(UserEmailOptions userEmailOption)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOption.Subjet,
                Body = userEmailOption.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHTML
            };
            foreach (var toEmail in userEmailOption.ToEmails)
            {
                mail.To.Add(toEmail);
            }
            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password );
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network, // form gmail
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential          
            };
           
            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);            
        }
        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }
        private string UpdatePlaceHolder(string text, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
            {
                foreach (var placeHolder in keyValuePairs)
                {
                    if (text.Contains(placeHolder.Key))
                    {
                        text = text.Replace(placeHolder.Key, placeHolder.Value);
                    }
                }
            }
            return text;
        }
    }
}
