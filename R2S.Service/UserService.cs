using R2S.Data.Models;
using Service.pattern;
using R2S.Data.Infrastructures;
using R2S.Data.Models;
using Service.pattern;
namespace R2S.Service

{
    public class UserService : ServiceGenerique<user>, IUserService
    {
        private static IDataBaseFactory dbfactory = new DataBaseFactory();
        private static UnitOfWork Utw = new UnitOfWork(dbfactory);

        public UserService() : base(Utw)
        {

        }
    }
}