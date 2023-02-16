using Microsoft.EntityFrameworkCore;
using Ouvidoria.Models;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Ouvidoria.Data.Seeds
{
    public static class PopulateSeeds
    {
        public static void PopulateDataBase(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>().HasData(
                new Perfil { Id = 1, TipoPerfil = "Funcionário" },
                new Perfil { Id = 2, TipoPerfil = "Aluno" },
                new Perfil { Id = 3, TipoPerfil = "Visitante" }
                );
            modelBuilder.Entity<Polo>().HasData(
               new Polo() { Id = 1, Campus = "Volta Redonda" },
               new Polo() { Id = 2, Campus = "Barra do Piraí" },
               new Polo() { Id = 3, Campus = "Nova Iguaçu" }
               );
            modelBuilder.Entity<Setor>().HasData(
                new Setor() { Id = 1, Nome = "Nead", Email = "testeouvidoria23" },
                new Setor() { Id = 2, Nome = "Financeiro", Email = "testeouvidoria23" },
                new Setor() { Id = 3, Nome = "Centro de Atendimento", Email = "testeouvidoria23" }
                );
            modelBuilder.Entity<TipoSolicitacao>().HasData(
               new TipoSolicitacao() { Id = 1, Tipo = "Positiva" },
               new TipoSolicitacao() { Id = 2, Tipo = "Negativa" },
               new TipoSolicitacao() { Id = 3, Tipo = "Sugestão" }
               );


            modelBuilder.Entity<Solicitacao>().HasData(
                new Solicitacao
                {
                    Id = 1,
                    PerfilId = 1,
                    SetorId = 1,
                    TipoReclamacaoId = 1,
                    PoloId = 1,
                    Nome = "João Vitor Eleutério de Sousa",
                    Email = "joaovr2012@outlook.com",
                    Celular = "24988677507",
                    Assunto = "Atendimento excelente",                    
                    Detalhes = "Gostei muito do atendimento feito na instituição, atendeu todas as minhas expectativas",                    
                });
        }
    }
}
