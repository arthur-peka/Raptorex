using Raptorex.BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.DA.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Filter(Expression<Func<T, bool>> condition);
        T GetSingle(Expression<Func<T, bool>> condition);
        void Insert(T obj);
        void Update(T obj);
        void Remove(Guid id);
    }
}
