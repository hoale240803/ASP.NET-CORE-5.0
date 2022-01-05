using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using static ASP.NETCORE5._0.Utility.EmailLoggerHelper;

namespace ASP.NETCORE5._0.Utility
{
    public static class EmailLogger
    {
        public static Task Throw(EmailExceptionType type, Exception ex)
        {
            var subject = GetSubject(type, ex.Message);

            return SharedEmailHelper.SendEmailAsync(new EmailAddress(SharedAppSettings.EmailSettings.FromEmail, SharedAppSettings.Email.FromName),
                new EmailAddress(SharedAppConst.DevEmailAddress, $"WS {SharedAppSettings.RunningMode}"), subject,
                GetPlainMessage(type, ex), null);
        }

        public static Task Throw(EmailExceptionType type, string message, string htmlContent = null)
        {
            var subject = GetSubject(type, message);

            return SharedEmailHelper.SendEmailAsync(new EmailAddress(SharedAppSettings.EmailSettings.FromEmail, SharedAppSettings.Email.FromName),
                new EmailAddress(SharedAppConst.DevEmailAddress, $"WS {SharedAppSettings.RunningMode}"), subject,
                $"{SharedAppSettings.RunningMode}: {message}", htmlContent);
        }

        public static string GetSubject(EmailExceptionType type, string message)
        {
            string subject;
            if (type == EmailExceptionType.Info)
            {
                subject = $"[{type.ToValue()}] [{SharedAppSettings.RunningMode}]: {message}".Truncate(200);
            }
            else
            {
                subject =
                    $" [{type.ToValue()}] [{SharedAppSettings.RunningMode}] From {Environment.MachineName} - Exception: {message}"
                        .Truncate(200);
            }

            if (SharedAppSettings.RunningMode == AppEnvironment.Local)
            {
                subject = $"From {Environment.UserName}: {subject}";
            }

            return subject;
        }

        private static string GetPlainMessage(EmailExceptionType type, Exception ex)
        {
            if (type == EmailExceptionType.Info)
            {
                return ex.Message;
            }

            return $"Exception message: {ex.Message} StackTrace: {ex.StackTrace}";
        }
    }
}