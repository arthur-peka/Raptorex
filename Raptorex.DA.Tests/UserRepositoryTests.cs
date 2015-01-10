using Raptorex.BO.Entities;
using Raptorex.DA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Raptorex.DA.Tests
{
    public class UserRepositoryTests
    {
        public UserRepositoryTests()
        {
            using (var context = new RaptorexContext())
            {
                context.Database.Delete();
                context.Database.Initialize(force: false);
            }
        }

        [Fact]
        public void TestUserAddition()
        {
            UserRepository ur = new UserRepository();
            string newUsersUsername = "ivan2000";
            var userToAdd = new RaptorexUser() { Email = "ivan@vasja.com", Username = newUsersUsername };

            ur.Insert(userToAdd);

            var userFromDb = ur.GetSingle(u => u.Username == newUsersUsername);

            Assert.True(userFromDb != null);
        }
    }
}
