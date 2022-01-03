using ASP.NETCORE5._0.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCORE5._0.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        public bool IsSystemAdmin => HttpContext.IsSystemAdmin();

        protected string AccountId => HttpContext.GetAccountId();

        public string UserEmail => HttpContext.GetEmail();

        public string UserName => HttpContext.GetName();

        public string UserCurrentRole => HttpContext.GetRole();

        /// <summary>
        /// The current user logged in.
        /// </summary>
        protected string UserId => HttpContext.GetUserId();
    }
}