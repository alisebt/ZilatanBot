using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Models.Mapping;

namespace DAL.Models
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MessageMap());
        }
    }
}
