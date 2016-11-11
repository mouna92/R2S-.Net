using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using R2S.Data.Infrastructures;

namespace Service.pattern
{
  public  class ServiceGenerique<T> : IServiceGenerique<T> where T : class
    {
        private UnitOfWork itw;

        protected ServiceGenerique(UnitOfWork itw)
        {
            this.itw = itw;
        }

        public virtual void Add(T entity)
        {
            itw.GetRepository<T>().Add(entity);
        }

        public virtual void commit()
        {
            itw.Commit();
        }

        public virtual void Delete(T entity)
        {
            itw.GetRepository<T>().Delete(entity);
        }

        public virtual void DeleteByCondition(Expression<Func<T, bool>> condition)
        {
            itw.GetRepository<T>().DeleteByCondition(condition);
        }

        public virtual void Dispose()
        {
            itw.Dispose();
        }

        public virtual T GetById(string id)
        {
            return itw.GetRepository<T>().GetById(id);
        }

        public virtual T GetById(int id)
        {
            return itw.GetRepository<T>().GetById(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> OrderBy = null)
        {
            return itw.GetRepository<T>().GetMany(condition, OrderBy);
        }

        public virtual void Update(T entity)
        {
            itw.GetRepository<T>().Update(entity);
        }
    }
}
