using AutoMapper;
using Raptorex.BO.Entities;
using Raptorex.DA.Repositories;
using Raptorex.Filters;
using Raptorex.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Security;

namespace Raptorex.Controllers.api
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private IBaseRepository<RaptorexUser> _userRepository;

        public AccountController()
        {
            _userRepository = new UserRepository();
        }

        public AccountController(IBaseRepository<RaptorexUser> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [ValidateModel]
        [Route("login")]
        public HttpResponseMessage Login(LoginModel loginInfo)
        {
            if (!CheckCredentials(loginInfo.Username, loginInfo.Password))
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            InsertAuthCookie(loginInfo.Username, response, DateTime.Now.AddMilliseconds(FormsAuthentication.Timeout.Milliseconds));

            return response;
        }

        [HttpPost]
        [Route("logOff")]
        public HttpResponseMessage LogOff()
        {
            string currentUsername = GetCurrentUsername();

            if (String.IsNullOrEmpty(currentUsername))
                return new HttpResponseMessage(HttpStatusCode.OK);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            var emptyAuthCookie = new CookieHeaderValue(FormsAuthentication.FormsCookieName, "");

            response.Headers.AddCookies(new CookieHeaderValue[] { emptyAuthCookie });

            return response;
        }

        [HttpPost]
        [ValidateModel]
        [Route("add")]
        public HttpResponseMessage Add(UserAccountModel userModel)
        {
            RaptorexUser userToInsert = Mapper.Map<UserAccountModel, RaptorexUser>(userModel);

            _userRepository.Insert(userToInsert);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [CacheControl(MaxAgeSeconds=1, NoCache=true)]
        [Route("currentUser")]
        public string GetCurrentUsername()
        {
            Collection<CookieHeaderValue> headerCookies = ActionContext.Request.Headers
                .GetCookies(FormsAuthentication.FormsCookieName);

            if (headerCookies == null || headerCookies.Count == 0)
                return null;

            var userCookie = headerCookies.First().Cookies.FirstOrDefault(c => c.Name == FormsAuthentication.FormsCookieName);

            if (userCookie == null || String.IsNullOrEmpty(userCookie.Value))
                return null;

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(userCookie.Value);

            if (ticket != null)
            {
                return ticket.Name;
            }

            return null;
        }

        private static void InsertAuthCookie(string username, HttpResponseMessage response, DateTime expirationDate)
        {
            FormsAuthenticationTicket authTicket =
                new FormsAuthenticationTicket(
                    version: 1,
                    name: username,
                    issueDate: DateTime.Now,
                    expiration: expirationDate,
                    isPersistent: false,
                    userData: username,
                    cookiePath: FormsAuthentication.FormsCookiePath);

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new CookieHeaderValue(FormsAuthentication.FormsCookieName, encryptedTicket);

            response.Headers.AddCookies(new CookieHeaderValue[] { authCookie });
        }

        private bool CheckCredentials(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                return false;

            RaptorexUser existingUser = _userRepository.GetSingle(u => u.Username == username);

            if (existingUser == null)
                return false;

            bool isCorrect = Crypto.VerifyHashedPassword(existingUser.PasswordHash, password);

            return isCorrect;
        }
    }
}
