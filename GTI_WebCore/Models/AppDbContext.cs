using Microsoft.EntityFrameworkCore;

namespace GTI_WebCore.Models {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Bairro>().HasKey(c =>new { c.Siglauf, c.Codcidade,c.Codbairro });
            modelBuilder.Entity<Cep>().HasKey(c => new { c.Codlogr, c.cep, c.Valor1 });
            modelBuilder.Entity<Cidade>().HasKey(c => new { c.Siglauf, c.Codcidade });
            modelBuilder.Entity<Cnaesubclasse>().HasKey(c => new { c.Secao, c.Divisao, c.Grupo, c.Classe, c.Subclasse });
            modelBuilder.Entity<Facequadra>().HasKey(c => new { c.Coddistrito, c.Codsetor, c.Codquadra, c.Codface });
            modelBuilder.Entity<Mobiliariocnae>().HasKey(c => new { c.Codmobiliario, c.Secao, c.Divisao, c.Grupo, c.Classe, c.Subclasse });
            modelBuilder.Entity<Mobiliarioevento>().HasKey(c => new { c.Codmobiliario, c.Codtipoevento,c.Seqevento });
            modelBuilder.Entity<Mobiliarioatividadeiss>().HasKey(c => new { c.Codmobiliario, c.Codtributo, c.Codatividade, c.Seq });
            modelBuilder.Entity<Mobiliarioproprietario>().HasKey(c => new { c.Codmobiliario, c.Codcidadao });
            modelBuilder.Entity<Mobiliariovs>().HasKey(c => new { c.Codigo, c.Cnae, c.Criterio });
            modelBuilder.Entity<Proprietario>().HasKey(c => new { c.Codreduzido, c.Codcidadao });
        }


        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Benfeitoria> Benfeitoria { get; set; }
        public DbSet<Cadimob> Cadimob { get; set; }
        public DbSet<Categprop> Categprop { get; set; }
        public DbSet<Cep> Cep { get; set; }
        public DbSet<Cidadao> Cidadao { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Cnae> Cnae { get; set; }
        public DbSet<Cnaesubclasse> Cnaesubclasse { get; set; }
        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Endentrega> Endentrega { get; set; }
        public DbSet<Facequadra> Facequadra { get; set; }
        public DbSet<Horario_funcionamento> Horario_funcionamento { get; set; }
        public DbSet<Logradouro> Logradouro { get; set; }
        public DbSet<Mobiliario> Mobiliario { get; set; }
        public DbSet<Mobiliarioatividadeiss> Mobiliarioatividadeiss { get; set; }
        public DbSet<Mobiliariocnae> Mobiliariocnae { get; set; }
        public DbSet<Mobiliarioevento> Mobiliarioevento { get; set; }
        public DbSet<Mobiliarioproprietario> Mobiliarioproprietario { get; set; }
        public DbSet<Mobiliariovs> Mobiliariovs { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Pedologia> Pedologia { get; set; }
        public DbSet<Periodomei> Periodomei { get; set; }
        public DbSet<Proprietario> Proprietario { get; set; }
        public DbSet<Situacao> Situacao { get; set; }
        public DbSet<Topografia> Topografia { get; set; }
        public DbSet<Usoterreno> Usoterreno { get; set; }
    }
}
