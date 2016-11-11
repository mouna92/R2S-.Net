using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class candidateanswerMap : EntityTypeConfiguration<candidateanswer>
    {
        public candidateanswerMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("candidateanswer", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.candidateQuizModel_id).HasColumnName("candidateQuizModel_id");

            // Relationships
            this.HasOptional(t => t.candidatequizmodel)
                .WithMany(t => t.candidateanswers)
                .HasForeignKey(d => d.candidateQuizModel_id);

        }
    }
}
