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
    public class JobService : ServiceGenerique<job>, IJobService
    {
        private static IDataBaseFactory dbfactory = new DataBaseFactory();
        private static UnitOfWork Utw = new UnitOfWork(dbfactory);

        public JobService() : base(Utw)
        {

        }

        public int StatisticJobClosed()
        {

            var results = from g in dbfactory.dbcontext.jobs

                where g.status.Equals("Open")

                select g;
            return results.Count();
        }

        public int StatisticJobOpen()
        {

            var results = from g in dbfactory.dbcontext.jobs

                where g.status.Equals("Closed")

                select g;
            return results.Count();
        }

        public double HighestSalary()
        {
            var max = dbfactory.dbcontext.jobs.Max(b => b.salary);
            return (double) max;
        }

        public double LowestSalary()
        {
            var min = dbfactory.dbcontext.jobs.Min(b => b.salary);
            return (double) min;
        }

        public double Moy()
        {
            List<job> jobs = this.GetMany().ToList();
            double average = 0;
            foreach (var job in jobs)
            {
                average +=(double) job.salary;
            }
          
            return average/jobs.Count;

        }
    }
}

