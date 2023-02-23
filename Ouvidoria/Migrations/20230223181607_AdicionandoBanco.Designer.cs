﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ouvidoria.Data;

namespace Ouvidoria.Migrations
{
    [DbContext(typeof(OuvidoriaDbContext))]
    [Migration("20230223181607_AdicionandoBanco")]
    partial class AdicionandoBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ouvidoria.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoPerfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Perfis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TipoPerfil = "Funcionário"
                        },
                        new
                        {
                            Id = 2,
                            TipoPerfil = "Aluno"
                        },
                        new
                        {
                            Id = 3,
                            TipoPerfil = "Visitante"
                        });
                });

            modelBuilder.Entity("Ouvidoria.Models.Polo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Campus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Polos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Campus = "Volta Redonda"
                        },
                        new
                        {
                            Id = 2,
                            Campus = "Barra do Piraí"
                        },
                        new
                        {
                            Id = 3,
                            Campus = "Nova Iguaçu"
                        });
                });

            modelBuilder.Entity("Ouvidoria.Models.Resposta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PoloId")
                        .HasColumnType("int");

                    b.Property<int?>("SetorId")
                        .HasColumnType("int");

                    b.Property<int>("SolicitacaoId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoSolicitacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PoloId");

                    b.HasIndex("SetorId");

                    b.HasIndex("SolicitacaoId")
                        .IsUnique();

                    b.HasIndex("TipoSolicitacaoId");

                    b.ToTable("Resposta");
                });

            modelBuilder.Entity("Ouvidoria.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "testeouvidoria23@gmail.com",
                            Nome = "Nead"
                        },
                        new
                        {
                            Id = 2,
                            Email = "testeouvidoria23@gmail.com",
                            Nome = "Financeiro"
                        },
                        new
                        {
                            Id = 3,
                            Email = "testeouvidoria23@gmail.com",
                            Nome = "Centro de Atendimento"
                        });
                });

            modelBuilder.Entity("Ouvidoria.Models.Solicitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Curso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detalhes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<int>("PoloId")
                        .HasColumnType("int");

                    b.Property<int>("SetorId")
                        .HasColumnType("int");

                    b.Property<int>("TipoSolicitacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.HasIndex("PoloId");

                    b.HasIndex("SetorId");

                    b.HasIndex("TipoSolicitacaoId");

                    b.ToTable("Solicitacoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assunto = "Atendimento excelente",
                            Celular = "24988677507",
                            DataCadastro = new DateTime(2023, 2, 23, 15, 16, 7, 261, DateTimeKind.Local).AddTicks(3986),
                            Detalhes = "Gostei muito do atendimento feito na instituição, atendeu todas as minhas expectativas",
                            Email = "joaovr2012@outlook.com",
                            Nome = "João Vitor Eleutério de Sousa",
                            PerfilId = 1,
                            PoloId = 1,
                            SetorId = 1,
                            TipoSolicitacaoId = 1
                        });
                });

            modelBuilder.Entity("Ouvidoria.Models.TipoSolicitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoSolicitacoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Tipo = "Positiva"
                        },
                        new
                        {
                            Id = 2,
                            Tipo = "Negativa"
                        },
                        new
                        {
                            Id = 3,
                            Tipo = "Sugestão"
                        });
                });

            modelBuilder.Entity("Ouvidoria.Models.Resposta", b =>
                {
                    b.HasOne("Ouvidoria.Models.Polo", "Polo")
                        .WithMany()
                        .HasForeignKey("PoloId");

                    b.HasOne("Ouvidoria.Models.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("SetorId");

                    b.HasOne("Ouvidoria.Models.Solicitacao", "Solicitacao")
                        .WithOne("Resposta")
                        .HasForeignKey("Ouvidoria.Models.Resposta", "SolicitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ouvidoria.Models.TipoSolicitacao", "TipoSolicitacao")
                        .WithMany()
                        .HasForeignKey("TipoSolicitacaoId");

                    b.Navigation("Polo");

                    b.Navigation("Setor");

                    b.Navigation("Solicitacao");

                    b.Navigation("TipoSolicitacao");
                });

            modelBuilder.Entity("Ouvidoria.Models.Solicitacao", b =>
                {
                    b.HasOne("Ouvidoria.Models.Perfil", "Perfil")
                        .WithMany("Solicitacoes")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ouvidoria.Models.Polo", "Polos")
                        .WithMany("Solicitacoes")
                        .HasForeignKey("PoloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ouvidoria.Models.Setor", "Setor")
                        .WithMany("Solicitacoes")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ouvidoria.Models.TipoSolicitacao", "TipoSolicitacoes")
                        .WithMany("Solicitacoes")
                        .HasForeignKey("TipoSolicitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Polos");

                    b.Navigation("Setor");

                    b.Navigation("TipoSolicitacoes");
                });

            modelBuilder.Entity("Ouvidoria.Models.Perfil", b =>
                {
                    b.Navigation("Solicitacoes");
                });

            modelBuilder.Entity("Ouvidoria.Models.Polo", b =>
                {
                    b.Navigation("Solicitacoes");
                });

            modelBuilder.Entity("Ouvidoria.Models.Setor", b =>
                {
                    b.Navigation("Solicitacoes");
                });

            modelBuilder.Entity("Ouvidoria.Models.Solicitacao", b =>
                {
                    b.Navigation("Resposta");
                });

            modelBuilder.Entity("Ouvidoria.Models.TipoSolicitacao", b =>
                {
                    b.Navigation("Solicitacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
