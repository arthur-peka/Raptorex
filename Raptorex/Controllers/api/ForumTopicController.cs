using Raptorex.BO.Entities;
using Raptorex.DA.Repositories;
using Raptorex.Filters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Security;

namespace Raptorex.Controllers.api
{
    [RoutePrefix("api/forum")]
    public class ForumTopicController : ApiController
    {
        private IBaseRepository<ForumTopic> _topicRepository;
        private IBaseRepository<Subforum> _subforumRepository;

        public ForumTopicController()
        {
            _topicRepository = new ForumTopicRepository();
            _subforumRepository = new SubforumRepository();
        }

        [HttpGet]
        [Route("all")]
        public List<ForumTopic> GetAll()
        {
            var res = _topicRepository.Filter(x => true).ToList();
            var user = User.Identity.Name;
            return res;
        }

        [HttpGet]
        [Route("subforums")]
        public List<Subforum> GetAllSubforums()
        {
            var subforums = _subforumRepository.Filter(s => true).ToList();

            return subforums;
        }

        [HttpGet]
        [Route("subforum/{subforumId}")]
        public List<ForumTopic> GetBySubforum(Guid subforumId)
        {
            var topics = _topicRepository.Filter(t => t.TopicSubforumId == subforumId).ToList();

            return topics;
        }
    }
}
