using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ASP.NETCORE5._0.Extensions
{
    public struct AppClaimType
    {
        public const string AccountId = "AccountId";
        public const string Email = "Email";
        public const string Name = "Name";
        public const string Role = "Role";

        public const string SystemAdmin = "SystemAdmin";
        public const string UserId = "UserId";
        public const string Api = "API";
    }
    public static class HttpContextExtension
    {
        private static string GetClaimValue(HttpContext context, string claimName)
        {
            return context.User.Claims.FirstOrDefault(x => x.Type == claimName)?.Value;
        }

        public static string GetName(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.Name);
        }

        public static string GetEmail(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.Email);
        }

        public static string GetUserId(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.UserId);
        }

        public static string GetAccountId(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.AccountId);
        }

        public static bool IsSystemAdmin(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.SystemAdmin) != null;
        }

        /// <summary>
        /// There are 2 roles: Admin and User
        /// </summary>
        public static string GetRole(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.Role);
        }
    }
}