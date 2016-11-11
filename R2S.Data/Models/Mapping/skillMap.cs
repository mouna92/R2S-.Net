using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class skillMap : EntityTypeConfiguration<skill>
    {
        public skillMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("skill", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");

            // Relationships
            this.HasMany(t => t.jobs)
                .WithMany(t => t.skills)
                .Map(m =>
                    {
                        m.ToTable("skill_job", "r2s");
                        m.MapLeftKey("skills_id");
                        m.MapRightKey("jobs_id");
                    });


        }
    }
}
