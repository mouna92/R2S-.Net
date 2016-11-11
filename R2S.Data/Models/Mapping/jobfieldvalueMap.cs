using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class jobfieldvalueMap : EntityTypeConfiguration<jobfieldvalue>
    {
        public jobfieldvalueMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.value)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("jobfieldvalue", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.value).HasColumnName("value");
            this.Property(t => t.job_id).HasColumnName("job_id");
            this.Property(t => t.jobField_id).HasColumnName("jobField_id");

            // Relationships
            this.HasOptional(t => t.job)
                .WithMany(t => t.jobfieldvalues)
                .HasForeignKey(d => d.job_id);
            this.HasOptional(t => t.jobfield)
                .WithMany(t => t.jobfieldvalues)
                .HasForeignKey(d => d.jobField_id);

        }
    }
}
