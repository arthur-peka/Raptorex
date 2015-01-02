using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http.Headers;

namespace Raptorex.Filters
{
    public class CacheControlAttribute : ActionFilterAttribute
    {
        public int MaxAgeSeconds { get; set; }
        public bool NoCache { get; set; }

        public CacheControlAttribute()
        {
            MaxAgeSeconds = 3600;
            NoCache = false;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromSeconds(MaxAgeSeconds),
                NoCache = this.NoCache
            };

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}