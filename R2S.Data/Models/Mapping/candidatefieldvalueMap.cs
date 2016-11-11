using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class candidatefieldvalueMap : EntityTypeConfiguration<candidatefieldvalue>
    {
        public candidatefieldvalueMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.value)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("candidatefieldvalue", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.value).HasColumnName("value");
            this.Property(t => t.candidate_cin).HasColumnName("candidate_cin");
            this.Property(t => t.candidateField_id).HasColumnName("candidateField_id");

            // Relationships
            this.HasOptional(t => t.candidatefield)
                .WithMany(t => t.candidatefieldvalues)
                .HasForeignKey(d => d.candidateField_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.candidatefieldvalues)
                .HasForeignKey(d => d.candidate_cin);

        }
    }
}
