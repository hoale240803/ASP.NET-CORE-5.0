using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASP.NETCORE5._0.Utility
{
	public static class EmailLoggerHelper
	{

		public class EmailSettings
		{
			public string SendGridApiKey { get; set; }
			public string MailgunApiKey { get; set; }
			public string FromEmail { get; set; }
		}
		public class SharedAppSettings
		{
			public static string RunningMode { get; set; }

			public static EmailSettings EmailSettings { get; set; }

			//public static DefaultAvailableTimeSetting DefaultAvailableTimeSetting { get; set; }

			//public static FireBase FireBase { get; set; }

			//public static int CalendarEventMaxRecord { get; set; }

			//public static int DaysToScheduleCallInTheFuture { get; set; }

			//public static string ConnectionStringFormat => SharedEnvironmentSetting.ConnectionStringFormat;

			//public static string APIDomain => SharedEnvironmentSetting.APIDomain;

			//public static EnvEmailSetting Email => SharedEnvironmentSetting.Email;

			//public static GoogleSetting GoogleApp => SharedEnvironmentSetting.GoogleApp;

			//public static OutlookSetting OutlookApp => SharedEnvironmentSetting.OutlookApp;

			//public static AwsSetting Aws => SharedEnvironmentSetting.AWS;

			//public static int DefaultCampaignBookingMinuteStep { get; set; }

			//public static int DefaultCampaignBookingTimeSlot { get; set; }
		}

		public enum EmailExceptionType
		{
			[StringValue("Info")] Info,
			[StringValue("Warning")] Warning,
			[StringValue("Error")] Error,
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="_logger">cài extensioni logger</param>
		/// <param name="type"></param>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static Task ErrorWithEmailLogger(this ILogger _logger, EmailExceptionType type, Exception ex)
		{
			_logger.Error(ex);

			var subject = EmailLogger.GetSubject(type, ex.Message);

			return SharedEmailHelper.SendEmailAsync(new EmailAddress(SharedAppSettings.EmailSettings.FromEmail, SharedAppSettings.Email.FromName),
				new EmailAddress(SharedAppConst.DevEmailAddress, $"WS {SharedAppSettings.RunningMode}"), subject,
				$"{SharedAppSettings.RunningMode}: Exception message: {ex.Message} StackTrace: {ex.StackTrace}", null);
		}

		public static Task ErrorWithEmailLogger(this ILogger _logger, EmailExceptionType type, string message)
		{
			_logger.Error(message);

			var subject = EmailLogger.GetSubject(type, message);

			return SharedEmailHelper.SendEmailAsync(new EmailAddress(SharedAppSettings.EmailSettings.FromEmail, SharedAppSettings.Email.FromName),
				new EmailAddress(SharedAppConst.DevEmailAddress, $"WS {SharedAppSettings.RunningMode}"), subject,
				$"{SharedAppSettings.RunningMode}: Exception message: {message}", null);
		}

		
		public struct AppEnvironment
		{
			public const string Local = "Local";
			public const string Dev = "Dev";
			public const string QA = "QA";
			public const string Live = "Live";
		}
		public struct SharedAppConst
		{
			public const string DevEmailAddress = "hoale@gmail.com";
		}

	}
}
