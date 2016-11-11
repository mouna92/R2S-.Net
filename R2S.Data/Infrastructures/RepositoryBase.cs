using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using R2S.Data.Models;

namespace R2S.Data.Infrastructures
{
   public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private r2sContext context;
        private IDbSet<T> dbSet;

        public RepositoryBase(r2sContext context) //béch mano93odech à chaque fois na3mél T ninstancie context
        {
            this.context = new r2sContext();
            dbSet = context.Set<T>(); //to avoid recalling DbSet
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteByCondition(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> obj = dbSet.Where(condition);
            foreach (T elem in obj)
            {
                dbSet.Remove(elem);
            }
        }

        public T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);

        }

        public IEnumerable<T> GetMany(System.Linq.Expressions.Expression<Func<T, bool>> condition = null, System.Linq.Expressions.Expression<Func<T, bool>> orderBy = null)
        {
            {

                if (condition != null && orderBy == null)
                {
                    return dbSet.Where(condition);
                }
                if (orderBy != null && condition == null)
                {
                    return dbSet.OrderBy(orderBy);
                }
                if (orderBy != null && condition != null)
                {
                    return dbSet.Where(condition).OrderBy(orderBy);
                }
                return dbSet;
            }

        }

        public void Update(T entity)
        {
            dbSet.Attach(entity); // on attache l'entity to dbset
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
