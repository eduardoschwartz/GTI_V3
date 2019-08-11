using Microsoft.EntityFrameworkCore;

namespace GTI_WebCore.Models {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Bairro>().HasKey(c =>new { c.Siglauf, c.Codcidade,c.Codbairro });
            modelBuilder.Entity<Cidade>().HasKey(c => new { c.Siglauf, c.Codcidade });
            modelBuilder.Entity<Mobiliarioevento>().HasKey(c => new { c.Codmobiliario, c.Codtipoevento,c.Seqevento });
            modelBuilder.Entity<Mobiliarioproprietario>().HasKey(c => new { c.Codmobiliario, c.Codcidadao });
        }

        public DbSet<Mobiliario> Mobiliario { get; set; }
        public DbSet<Mobiliarioevento> Mobiliarioevento { get; set; }
        public DbSet<Mobiliarioproprietario> Mobiliarioproprietario { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Cidadao> Cidadao { get; set; }
        public DbSet<Horario_funcionamento> Horario_funcionamento { get; set; }
        public DbSet<Logradouro> Logradouro { get; set; }
        public DbSet<Cep> Cep { get; set; }
    }
}
