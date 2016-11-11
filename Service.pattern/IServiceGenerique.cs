using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.pattern
{
  public  interface IServiceGenerique<T> : IDisposable where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        T GetById(int id);
        T GetById(String id);
        // IEnumerable<T> GetAll(); les 2 méthodes GetAll etGet Many en une seule méthode condition peut etre nulle
        IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> OrderBy = null); //type de l'expression lamda <Func<T,bool>>
        void DeleteByCondition(Expression<Func<T, bool>> condition);
        void commit();
    }
}
