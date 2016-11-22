using R2S.Data.Infrastructures;
using R2S.Data.Models;
using R2S.Service.Interfaces;
using Service.pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Service
{
    public class SkillService : ServiceGenerique<skill>, ISkillService
    {
        private static IDataBaseFactory dbfactory = new DataBaseFactory();
        private static UnitOfWork Utw = new UnitOfWork(dbfactory);

        public SkillService() : base(Utw)
        {

        }
    }
}
