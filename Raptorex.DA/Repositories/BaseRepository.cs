﻿using Raptorex.BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Raptorex.DA.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> Filter(Expression<Func<T,bool>> condition)
        {
            using (var context = new RaptorexContext())
            {
                return context.Set<T>().Where(condition);
            }
        }

        public T GetSingle(Expression<Func<T, bool>> condition)
        {
            using (var context = new RaptorexContext())
            {
                return context.Set<T>().SingleOrDefault(condition);
            }
        }

        public void Insert(T obj)
        {
            using (var context = new RaptorexContext())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
        }

        public void Update(T obj)
        {
            using (var context = new RaptorexContext())
            {
                context.Entry<T>(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Remove(Guid id)
        {
            using (var context = new RaptorexContext())
            {
                T entity = context.Set<T>().SingleOrDefault(e => e.ID == id);
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
