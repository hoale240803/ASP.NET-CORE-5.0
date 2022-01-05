using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static ASP.NETCORE5._0.Utility.EmailLoggerHelper;

namespace ASP.NETCORE5._0.Utility
{
    public static class SharedEmailHelper
    {
        public static async Task<bool> SendEmailAsync(EmailAddress from, EmailAddress to, string subject, string plainTextContent,
            string htmlContent, EmailAddress replyTo = null, List<Attachment> attachments = null)
        {
            if (SharedAppSettings.RunningMode == AppEnvironment.Local)
                return true;

            var client = new SendGridClient(new SendGridClientOptions
            {
                ApiKey = SharedAppSettings.EmailSettings.SendGridApiKey,
                UrlPath = "mail/send",
                Version = "v3"
            });

            var emailMessage = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            if (attachments.NotNullOrEmpty())
                emailMessage.Attachments = attachments;

            if (replyTo != null)
            {
                emailMessage.ReplyTo = replyTo;
            }

            // Calling api to send email
            var response = await client.SendEmailAsync(emailMessage);

            // Return result
            return response.StatusCode == HttpStatusCode.Accepted;
        }
    }
}