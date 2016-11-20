using R2S.Data.Infrastructures;
using R2S.Data.Models;
using Service.pattern;

namespace R2S.Service
{
    public class CandidateFieldService : ServiceGenerique<candidatefield>, ICandidateFieldService
    {
        private static IDataBaseFactory dbfactory = new DataBaseFactory();
        private static UnitOfWork Utw = new UnitOfWork(dbfactory);

        public CandidateFieldService() : base(Utw)
        {

        }

    }
}