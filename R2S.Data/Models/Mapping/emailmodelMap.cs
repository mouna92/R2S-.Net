using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class emailmodelMap : EntityTypeConfiguration<emailmodel>
    {
        public emailmodelMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.content)
                .HasMaxLength(60000);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("emailmodel", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.recruitmentManager_cin).HasColumnName("recruitmentManager_cin");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.emailmodels)
                .HasForeignKey(d => d.recruitmentManager_cin);

        }
    }
}
