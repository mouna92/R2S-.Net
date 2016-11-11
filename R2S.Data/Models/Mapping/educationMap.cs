using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class educationMap : EntityTypeConfiguration<education>
    {
        public educationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.degree)
                .HasMaxLength(255);

            this.Property(t => t.institution)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("education", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dateEnd).HasColumnName("dateEnd");
            this.Property(t => t.dateStart).HasColumnName("dateStart");
            this.Property(t => t.degree).HasColumnName("degree");
            this.Property(t => t.institution).HasColumnName("institution");
            this.Property(t => t.candidate_cin).HasColumnName("candidate_cin");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.educations)
                .HasForeignKey(d => d.candidate_cin);

        }
    }
}
