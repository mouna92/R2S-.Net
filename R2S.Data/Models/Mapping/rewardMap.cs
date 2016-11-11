using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class rewardMap : EntityTypeConfiguration<reward>
    {
        public rewardMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.points)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("reward", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.points).HasColumnName("points");
            this.Property(t => t.progress).HasColumnName("progress");
            this.Property(t => t.job_id).HasColumnName("job_id");

            // Relationships
            this.HasOptional(t => t.job)
                .WithMany(t => t.rewards)
                .HasForeignKey(d => d.job_id);

        }
    }
}
