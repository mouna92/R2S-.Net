using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Data.Infrastructures
{
   public interface IUnitOfWork: IDisposable
    {
        IRepositoryBase<T> GetRepository<T>() where T : class;
        void Commit();
    }
}
