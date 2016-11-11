using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class interviewMap : EntityTypeConfiguration<interview>
    {
        public interviewMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("interview", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.candidate_cin).HasColumnName("candidate_cin");
            this.Property(t => t.job_id).HasColumnName("job_id");
            this.Property(t => t.recruitmentManager_cin).HasColumnName("recruitmentManager_cin");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.interviews)
                .HasForeignKey(d => d.candidate_cin);
            this.HasOptional(t => t.job)
                .WithMany(t => t.interviews)
                .HasForeignKey(d => d.job_id);
            this.HasOptional(t => t.user1)
                .WithMany(t => t.interviews1)
                .HasForeignKey(d => d.recruitmentManager_cin);

        }
    }
}
