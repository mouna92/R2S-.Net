using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class certificationMap : EntityTypeConfiguration<certification>
    {
        public certificationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.url)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("certification", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dateEnd).HasColumnName("dateEnd");
            this.Property(t => t.dateStart).HasColumnName("dateStart");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.url).HasColumnName("url");
            this.Property(t => t.candidate_cin).HasColumnName("candidate_cin");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.certifications)
                .HasForeignKey(d => d.candidate_cin);

        }
    }
}
