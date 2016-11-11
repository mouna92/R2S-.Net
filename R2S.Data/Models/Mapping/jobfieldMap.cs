using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class jobfieldMap : EntityTypeConfiguration<jobfield>
    {
        public jobfieldMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.fieldName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("jobfield", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.fieldName).HasColumnName("fieldName");
            this.Property(t => t.fieldType).HasColumnName("fieldType");
        }
    }
}
