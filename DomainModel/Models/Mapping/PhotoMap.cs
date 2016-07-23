using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DomainModel.Models.Mapping
{
    public class PhotoMap : EntityTypeConfiguration<Photo>
    {
        public PhotoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.imageaddress)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Photos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.userid).HasColumnName("userid");
            this.Property(t => t.imageaddress).HasColumnName("imageaddress");
        }
    }
}
