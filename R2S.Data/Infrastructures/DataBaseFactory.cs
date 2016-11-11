using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2S.Data.Models;

namespace R2S.Data.Infrastructures
{
   public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        public r2sContext dbcontext { get { return context; } }
        private r2sContext context;

        public DataBaseFactory()
        {
            this.context = new r2sContext();
        }

        protected override void DisposeCore()
        {
            if (dbcontext != null)
                dbcontext.Dispose();
        }

    }
}
