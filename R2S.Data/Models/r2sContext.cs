using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using R2S.Data.Models.Mapping;

namespace R2S.Data.Models
{
    public partial class r2sContext : DbContext
    {
        static r2sContext()
        {
            Database.SetInitializer<r2sContext>(null);
        }

        public r2sContext()
            : base("Name=r2sContext")
        {
        }

        public DbSet<answer> answers { get; set; }
        public DbSet<candidateanswer> candidateanswers { get; set; }
        public DbSet<candidatefield> candidatefields { get; set; }
        public DbSet<candidatefieldvalue> candidatefieldvalues { get; set; }
        public DbSet<candidatejob> candidatejobs { get; set; }
        public DbSet<candidatequizmodel> candidatequizmodels { get; set; }
        public DbSet<candidateskill> candidateskills { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<certification> certifications { get; set; }
        public DbSet<education> educations { get; set; }
        public DbSet<emailmodel> emailmodels { get; set; }
        public DbSet<experience> experiences { get; set; }
        public DbSet<interview> interviews { get; set; }
        public DbSet<job> jobs { get; set; }
        public DbSet<jobfield> jobfields { get; set; }
        public DbSet<jobfieldvalue> jobfieldvalues { get; set; }
        public DbSet<notification> notifications { get; set; }
        public DbSet<question> questions { get; set; }
        public DbSet<quizmodel> quizmodels { get; set; }
        public DbSet<referhash> referhashes { get; set; }
        public DbSet<reward> rewards { get; set; }
        public DbSet<skill> skills { get; set; }
        public DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new answerMap());
            modelBuilder.Configurations.Add(new candidateanswerMap());
            modelBuilder.Configurations.Add(new candidatefieldMap());
            modelBuilder.Configurations.Add(new candidatefieldvalueMap());
            modelBuilder.Configurations.Add(new candidatejobMap());
            modelBuilder.Configurations.Add(new candidatequizmodelMap());
            modelBuilder.Configurations.Add(new candidateskillMap());
            modelBuilder.Configurations.Add(new categoryMap());
            modelBuilder.Configurations.Add(new certificationMap());
            modelBuilder.Configurations.Add(new educationMap());
            modelBuilder.Configurations.Add(new emailmodelMap());
            modelBuilder.Configurations.Add(new experienceMap());
            modelBuilder.Configurations.Add(new interviewMap());
            modelBuilder.Configurations.Add(new jobMap());
            modelBuilder.Configurations.Add(new jobfieldMap());
            modelBuilder.Configurations.Add(new jobfieldvalueMap());
            modelBuilder.Configurations.Add(new notificationMap());
            modelBuilder.Configurations.Add(new questionMap());
            modelBuilder.Configurations.Add(new quizmodelMap());
            modelBuilder.Configurations.Add(new referhashMap());
            modelBuilder.Configurations.Add(new rewardMap());
            modelBuilder.Configurations.Add(new skillMap());
            modelBuilder.Configurations.Add(new userMap());
        }
    }
}
