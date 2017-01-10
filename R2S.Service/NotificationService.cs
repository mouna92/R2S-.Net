using R2S.Data.Infrastructures;
using R2S.Data.Models;
using R2S.Service.Interfaces;
using Service.pattern;

namespace R2S.Service
{
    public class NotificationService : ServiceGenerique<notification>, INotificationService
    {
        private static IDataBaseFactory dbfactory = new DataBaseFactory();
        private static UnitOfWork Utw = new UnitOfWork(dbfactory);

        public NotificationService() : base(Utw)
        {

        }

     
    }
}