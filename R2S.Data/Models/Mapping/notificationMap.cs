using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class notificationMap : EntityTypeConfiguration<notification>
    {
        public notificationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.message)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("notification", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.message).HasColumnName("message");
            this.Property(t => t.job_id).HasColumnName("job_id");
            this.Property(t => t.recruitmentManager_cin).HasColumnName("recruitmentManager_cin");

            // Relationships
            this.HasOptional(t => t.job)
                .WithMany(t => t.notifications)
                .HasForeignKey(d => d.job_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.notifications)
                .HasForeignKey(d => d.recruitmentManager_cin);

        }
    }
}
