using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class candidateskillMap : EntityTypeConfiguration<candidateskill>
    {
        public candidateskillMap()
        {
            // Primary Key
            this.HasKey(t => new { t.candidate_cin, t.skill_id });

            // Properties
            this.Property(t => t.candidate_cin)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.skill_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("candidateskill", "r2s");
            this.Property(t => t.level).HasColumnName("level");
            this.Property(t => t.candidate_cin).HasColumnName("candidate_cin");
            this.Property(t => t.skill_id).HasColumnName("skill_id");

            // Relationships
            this.HasRequired(t => t.user)
                .WithMany(t => t.candidateskills)
                .HasForeignKey(d => d.candidate_cin);
            this.HasRequired(t => t.skill)
                .WithMany(t => t.candidateskills)
                .HasForeignKey(d => d.skill_id);

        }
    }
}
