using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace R2S.Data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.cin);

            // Properties
            this.Property(t => t.user_role)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.city)
                .HasMaxLength(255);

            this.Property(t => t.country)
                .HasMaxLength(255);

            this.Property(t => t.state)
                .HasMaxLength(255);

            this.Property(t => t.street)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.firstname)
                .HasMaxLength(255);

            this.Property(t => t.lastname)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.tel)
                .HasMaxLength(255);

            this.Property(t => t.username)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("users", "r2s");
            this.Property(t => t.user_role).HasColumnName("user_role");
            this.Property(t => t.cin).HasColumnName("cin");
            this.Property(t => t.active).HasColumnName("active");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.country).HasColumnName("country");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.street).HasColumnName("street");
            this.Property(t => t.birthday).HasColumnName("birthday");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.firstname).HasColumnName("firstname");
            this.Property(t => t.gender).HasColumnName("gender");
            this.Property(t => t.lastname).HasColumnName("lastname");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.tel).HasColumnName("tel");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.referee_cin).HasColumnName("referee_cin");
            //Inheritance
            Map<Candidate>(c =>
            {
                c.Requires("IsUser").HasValue(0);

            });
            Map<Employee>(c =>
            {
                c.Requires("IsUser").HasValue(1);

            });
            Map<RecruitementManager>(c =>
            {
                c.Requires("IsUser").HasValue(2);

            });
            Map<ChiefHumanRessource>(c =>
            {
                c.Requires("IsUser").HasValue(3);

            });



            // Relationships
            this.HasOptional(t => t.user1)
                .WithMany(t => t.users1)
                .HasForeignKey(d => d.referee_cin);

        }
    }
}
