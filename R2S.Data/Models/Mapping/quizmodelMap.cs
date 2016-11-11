using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class quizmodelMap : EntityTypeConfiguration<quizmodel>
    {
        public quizmodelMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("quizmodel", "r2s");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.answersNumber).HasColumnName("answersNumber");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.penalty).HasColumnName("penalty");
            this.Property(t => t.questionsNumber).HasColumnName("questionsNumber");

            // Relationships
            this.HasMany(t => t.jobs)
                .WithMany(t => t.quizmodels)
                .Map(m =>
                    {
                        m.ToTable("job_quizmodel", "r2s");
                        m.MapLeftKey("quizModel_id");
                        m.MapRightKey("jobs_id");
                    });

            this.HasMany(t => t.questions)
                .WithMany(t => t.quizmodels)
                .Map(m =>
                    {
                        m.ToTable("question_quizmodel", "r2s");
                        m.MapLeftKey("quizModels_id");
                        m.MapRightKey("questions_id");
                    });

            this.HasMany(t => t.answers)
                .WithMany(t => t.quizmodels)
                .Map(m =>
                    {
                        m.ToTable("quizmodel_answer", "r2s");
                        m.MapLeftKey("quizModels_id");
                        m.MapRightKey("answers_id");
                    });


        }
    }
}
