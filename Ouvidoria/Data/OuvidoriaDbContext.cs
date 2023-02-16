using Microsoft.EntityFrameworkCore;
using Ouvidoria.Data.Seeds;
using Ouvidoria.Models;
using System.Security.Cryptography.X509Certificates;

namespace Ouvidoria.Data
{
    public class OuvidoriaDbContext : DbContext
    {
        public OuvidoriaDbContext(DbContextOptions<OuvidoriaDbContext> options) : base(options)
        { }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Polo> Polos { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<TipoSolicitacao> TipoSolicitacoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.PopulateDataBase();
        }
    }
}
