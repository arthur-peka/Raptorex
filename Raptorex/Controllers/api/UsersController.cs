using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Raptorex.BO.Entities;
using Raptorex.DA;
using Raptorex.DA.Repositories;

namespace Raptorex.Controllers.api
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private IBaseRepository<RaptorexUser> _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        public UsersController(IBaseRepository<RaptorexUser> userRepository)
        {
            _userRepository = userRepository;
        }

        private RaptorexContext db = new RaptorexContext();

        [HttpGet]
        [Route("all")]
        public IList<RaptorexUser> GetUsers()
        {
            var res = _userRepository.Filter(u => true).ToList();
            return res;
        }

        [HttpGet]
        [Route("user")]
        public RaptorexUser GetUser(Guid userId)
        {
            var user = _userRepository.GetByPrimaryKey(userId);
            return user;
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(Guid id, RaptorexUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.ID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(RaptorexUser))]
        public IHttpActionResult PostUser(RaptorexUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(RaptorexUser))]
        public IHttpActionResult DeleteUser(Guid id)
        {
            RaptorexUser user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(Guid id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
    }
}