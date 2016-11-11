using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2S.Data.Models;

namespace R2S.Data.Infrastructures
{
   public class UnitOfWork: IUnitOfWork
    {
        private r2sContext context;
        IDataBaseFactory dbfactory;

        public UnitOfWork(IDataBaseFactory dbfactory)

        {
            this.dbfactory = dbfactory;
            context = dbfactory.dbcontext;
        }


        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose(); //libérer l'espace mémoire dans le contexte 
        }

        public RepositoryBase<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(context);

        }

        IRepositoryBase<T> IUnitOfWork.GetRepository<T>()
        {
            throw new NotImplementedException();
        }

    }
}

