using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class answerMap : EntityTypeConfiguration<answer>
    {
        public answerMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.answer1)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("answer", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.answer1).HasColumnName("answer");
            this.Property(t => t.correct).HasColumnName("correct");
            this.Property(t => t.candidateAnswer_id).HasColumnName("candidateAnswer_id");
            this.Property(t => t.question_id).HasColumnName("question_id");

            // Relationships
            this.HasOptional(t => t.candidateanswer)
                .WithMany(t => t.answers)
                .HasForeignKey(d => d.candidateAnswer_id);
            this.HasOptional(t => t.question)
                .WithMany(t => t.answers)
                .HasForeignKey(d => d.question_id);

        }
    }
}
