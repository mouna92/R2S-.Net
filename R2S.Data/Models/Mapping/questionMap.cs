using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class questionMap : EntityTypeConfiguration<question>
    {
        public questionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.question1)
                .HasMaxLength(255);

            this.Property(t => t.score)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("question", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.question1).HasColumnName("question");
            this.Property(t => t.score).HasColumnName("score");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.candidateAnswer_id).HasColumnName("candidateAnswer_id");
            this.Property(t => t.category_id).HasColumnName("category_id");

            // Relationships
            this.HasMany(t => t.categories)
                .WithMany(t => t.questions1)
                .Map(m =>
                    {
                        m.ToTable("category_question", "r2s");
                        m.MapLeftKey("questions_id");
                        m.MapRightKey("categories_id");
                    });

            this.HasOptional(t => t.candidateanswer)
                .WithMany(t => t.questions)
                .HasForeignKey(d => d.candidateAnswer_id);
            this.HasOptional(t => t.category)
                .WithMany(t => t.questions)
                .HasForeignKey(d => d.category_id);

        }
    }
}
