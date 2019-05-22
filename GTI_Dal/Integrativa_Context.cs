using GTI_Models.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GTI_Dal.Classes {
    public class Integrativa_Context : DbContext {
        public Integrativa_Context(string Connection_Name) : base(Connection_Name) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<Eicon_Context>(null);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cancelamentos> Cancelamentos { get; set; }

    }
}
