using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class candidatejobMap : EntityTypeConfiguration<candidatejob>
    {
        public candidatejobMap()
        {
            // Primary Key
            this.HasKey(t => new { t.candidate_cin, t.job_id });

            // Properties
            this.Property(t => t.candidate_cin)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.job_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("candidatejob", "r2s");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.progress).HasColumnName("progress");
            this.Property(t => t.candidate_cin).HasColumnName("candidate_cin");
            this.Property(t => t.job_id).HasColumnName("job_id");

            // Relationships
            this.HasRequired(t => t.job)
                .WithMany(t => t.candidatejobs)
                .HasForeignKey(d => d.job_id);
            this.HasRequired(t => t.user)
                .WithMany(t => t.candidatejobs)
                .HasForeignKey(d => d.candidate_cin);

        }
    }
}
