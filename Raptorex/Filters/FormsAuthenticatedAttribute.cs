using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Web.Security;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;
using System.Web.Http.Controllers;
using System.Security;
using System.Net;

namespace Raptorex.Filters
{
    public class FormsAuthenticatedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                var controller = actionContext.ControllerContext.Controller;
                Collection<CookieHeaderValue> headerCookies = actionContext.Request.Headers
                    .GetCookies(FormsAuthentication.FormsCookieName);

                if (headerCookies == null || headerCookies.Count == 0)
                    throw new SecurityException();

                var userCookie = headerCookies.First().Cookies.FirstOrDefault(c => c.Name == FormsAuthentication.FormsCookieName);

                if (userCookie == null || userCookie.Value == null)
                    throw new SecurityException();

                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(userCookie.Value);

                base.OnActionExecuting(actionContext);
            }
            catch (SecurityException)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized) { 
                    Content = new StringContent("Authorization required") };
            }
        }
    }
}