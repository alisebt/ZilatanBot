using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DomainModel.Models.Mapping
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.from_username)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.text)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Messages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.message_Id).HasColumnName("message_Id");
            this.Property(t => t.from_id).HasColumnName("from_id");
            this.Property(t => t.from_username).HasColumnName("from_username");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.text).HasColumnName("text");
            this.Property(t => t.createDate).HasColumnName("createDate");
        }
    }
}
