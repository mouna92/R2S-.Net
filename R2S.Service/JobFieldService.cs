using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2S.Data.Infrastructures;
using R2S.Data.Models;
using Service.pattern;

namespace R2S.Service
{
    public class JobFieldService : ServiceGenerique<jobfield>, IJobFieldService
    {
        private static IDataBaseFactory dbfactory = new DataBaseFactory();
        private static UnitOfWork Utw = new UnitOfWork(dbfactory);

        public JobFieldService() : base(Utw)
        {

        }
    }
}
