using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class referhashMap : EntityTypeConfiguration<referhash>
    {
        public referhashMap()
        {
            // Primary Key
            this.HasKey(t => t.hash);

            // Properties
            this.Property(t => t.hash)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("referhash", "r2s");
            this.Property(t => t.hash).HasColumnName("hash");
            this.Property(t => t.generateAt).HasColumnName("generateAt");
            this.Property(t => t.employee_cin).HasColumnName("employee_cin");
            this.Property(t => t.job_id).HasColumnName("job_id");

            // Relationships
            this.HasOptional(t => t.job)
                .WithMany(t => t.referhashes)
                .HasForeignKey(d => d.job_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.referhashes)
                .HasForeignKey(d => d.employee_cin);

        }
    }
}
