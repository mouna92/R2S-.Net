using R2S.Data.Models;
using Service.pattern;
using R2S.Data.Infrastructures;


namespace R2S.Service

{
    public class UserService : ServiceGenerique<user>, IUserService
    {
        private static IDataBaseFactory dbfactory = new DataBaseFactory();
        private static UnitOfWork Utw = new UnitOfWork(dbfactory);

        public UserService() : base(Utw)
        {

        }

        public user GetById(long id)
        {
            return dbfactory.dbcontext.users.Find(id);
        }
    }
}