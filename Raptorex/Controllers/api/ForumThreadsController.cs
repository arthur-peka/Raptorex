using Raptorex.BO.Entities;
using Raptorex.DA.Repositories;
using Raptorex.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Raptorex.Controllers.api
{
    [RoutePrefix("api/threads")]
    public class ForumThreadsController : ApiController
    {
        [HttpGet]
        [FormsAuthenticated]
        [Route("all")]
        public List<ForumTopic> GetAll()
        {
            var res = ForumThreadRepository.Instance.Filter(x => true).ToList();
            var user = User.Identity.Name;
            return res;
        }
    }
}
