using System.Data.Entity;
using Repository.Domain;

namespace Repository.Context
{
    public class Contexto : DbContext
    {
        static Contexto()
        {
            Database.SetInitializer<Contexto>(null);
        }

        public Contexto() : base("Name=estudoContext")
        {
        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguration());
        }
    }
}
