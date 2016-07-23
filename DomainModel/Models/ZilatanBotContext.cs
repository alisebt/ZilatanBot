using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DomainModel.Models.Mapping;

namespace DomainModel.Models
{
    public partial class ZilatanBotContext : DbContext
    {
        static ZilatanBotContext()
        {
            Database.SetInitializer<ZilatanBotContext>(null);
        }

        public ZilatanBotContext()
            : base("Name=ZilatanBotContext")
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
