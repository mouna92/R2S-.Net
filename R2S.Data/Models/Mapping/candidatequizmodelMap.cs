using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class candidatequizmodelMap : EntityTypeConfiguration<candidatequizmodel>
    {
        public candidatequizmodelMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("candidatequizmodel", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.passingDate).HasColumnName("passingDate");
            this.Property(t => t.candidate_cin).HasColumnName("candidate_cin");
            this.Property(t => t.job_id).HasColumnName("job_id");
            this.Property(t => t.quizModel_id).HasColumnName("quizModel_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.candidatequizmodels)
                .HasForeignKey(d => d.candidate_cin);
            this.HasOptional(t => t.job)
                .WithMany(t => t.candidatequizmodels)
                .HasForeignKey(d => d.job_id);
            this.HasOptional(t => t.quizmodel)
                .WithMany(t => t.candidatequizmodels)
                .HasForeignKey(d => d.quizModel_id);

        }
    }
}
