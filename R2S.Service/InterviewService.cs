using R2S.Data.Infrastructures;
using R2S.Data.Models;
using R2S.Service.Interfaces;
using Service.pattern;

namespace R2S.Service
{
    public class InterviewService : ServiceGenerique<interview>, IInterviewService
    {
        private static IDataBaseFactory dbfactory = new DataBaseFactory();
        private static UnitOfWork Utw = new UnitOfWork(dbfactory);

        public InterviewService() : base(Utw)
        {

        }

        public void refresh(interview interview)
        {
            dbfactory.dbcontext.Entry(interview).Reload();
        }
    }
}