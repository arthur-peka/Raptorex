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
        private IBaseRepository<ForumTopic> _topicRepository;

        public ForumThreadsController()
        {
            _topicRepository = new ForumTopicRepository();
        }

        [HttpGet]
        [FormsAuthenticated]
        [Route("all")]
        public List<ForumTopic> GetAll()
        {
            var res = _topicRepository.Filter(x => true).ToList();
            var user = User.Identity.Name;
            return res;
        }
    }
}
