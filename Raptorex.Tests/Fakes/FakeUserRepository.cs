using Raptorex.BO.Entities;
using Raptorex.DA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.Tests.Fakes
{
    public class FakeUserRepository : IBaseRepository<RaptorexUser>
    {
        private IList<RaptorexUser> _users;

        public FakeUserRepository()
        {
            _users = new List<RaptorexUser>();
        }

        public IEnumerable<RaptorexUser> Filter(Expression<Func<RaptorexUser, bool>> condition)
        {
            return _users.Where(condition.Compile());
        }

        public RaptorexUser GetSingle(System.Linq.Expressions.Expression<Func<RaptorexUser, bool>> condition)
        {
            return _users.SingleOrDefault(condition.Compile());
        }

        public void Insert(RaptorexUser obj)
        {
            _users.Add(obj);
        }

        public void Update(RaptorexUser obj)
        {
            
        }

        public void Remove(Guid id)
        {
            
        }


        public RaptorexUser GetByPrimaryKey(Guid id)
        {
            return _users.SingleOrDefault(u => u.ID == id);
        }
    }
}
