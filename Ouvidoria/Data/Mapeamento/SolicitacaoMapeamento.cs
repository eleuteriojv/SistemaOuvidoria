using Microsoft.EntityFrameworkCore;
using Ouvidoria.Models;

namespace Ouvidoria.Data.Mapeamento
{
    public static class SolicitacaoMapeamento
    {
        public static void MapeamentoSolicitacao(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitacao>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Solicitacao>()
                .HasOne(pe => pe.Setor)
                .WithMany(pe => pe.Solicitacoes)
                .HasForeignKey(pe => pe.SetorId);

            modelBuilder.Entity<Solicitacao>()
                .HasOne(pe => pe.Perfil)
                .WithMany(pe => pe.Solicitacoes)
                .HasForeignKey(pe => pe.PerfilId);

            modelBuilder.Entity<Solicitacao>()
                .HasOne(pe => pe.Polos)
                .WithMany(pe => pe.Solicitacoes)
                .HasForeignKey(pe => pe.PoloId);            
            
            modelBuilder.Entity<Solicitacao>()
                .HasOne(pe => pe.Resposta)
                .WithOne(pe => pe.Solicitacao);
        }
    }
}
