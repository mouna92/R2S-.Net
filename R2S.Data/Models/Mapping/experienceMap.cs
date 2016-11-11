using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class experienceMap : EntityTypeConfiguration<experience>
    {
        public experienceMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.jobTitle)
                .HasMaxLength(255);

            this.Property(t => t.organization)
                .HasMaxLength(255);

            this.Property(t => t.post)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("experience", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dateEnd).HasColumnName("dateEnd");
            this.Property(t => t.dateStart).HasColumnName("dateStart");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.jobTitle).HasColumnName("jobTitle");
            this.Property(t => t.organization).HasColumnName("organization");
            this.Property(t => t.post).HasColumnName("post");
            this.Property(t => t.candidate_cin).HasColumnName("candidate_cin");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.experiences)
                .HasForeignKey(d => d.candidate_cin);

        }
    }
}
