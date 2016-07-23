using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DomainModel.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.telegram_username)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.profilephoto)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.telegram_userid).HasColumnName("telegram_userid");
            this.Property(t => t.telegram_username).HasColumnName("telegram_username");
            this.Property(t => t.profilephoto).HasColumnName("profilephoto");
            this.Property(t => t.createdate).HasColumnName("createdate");
        }
    }
}
