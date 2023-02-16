using Microsoft.EntityFrameworkCore.Migrations;

namespace Ouvidoria.Migrations
{
    public partial class AdicionandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Polos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSolicitacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSolicitacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assunto = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalhes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: false),
                    SetorId = table.Column<int>(type: "int", nullable: false),
                    PoloId = table.Column<int>(type: "int", nullable: false),
                    TipoReclamacaoId = table.Column<int>(type: "int", nullable: false),
                    TipoSolicitacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Polos_PoloId",
                        column: x => x.PoloId,
                        principalTable: "Polos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_TipoSolicitacoes_TipoSolicitacaoId",
                        column: x => x.TipoSolicitacaoId,
                        principalTable: "TipoSolicitacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Perfis",
                columns: new[] { "Id", "TipoPerfil" },
                values: new object[,]
                {
                    { 1, "Funcionário" },
                    { 2, "Aluno" },
                    { 3, "Visitante" }
                });

            migrationBuilder.InsertData(
                table: "Polos",
                columns: new[] { "Id", "Campus" },
                values: new object[,]
                {
                    { 1, "Volta Redonda" },
                    { 2, "Barra do Piraí" },
                    { 3, "Nova Iguaçu" }
                });

            migrationBuilder.InsertData(
                table: "Setores",
                columns: new[] { "Id", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, "testeouvidoria23", "Nead" },
                    { 2, "testeouvidoria23", "Financeiro" },
                    { 3, "testeouvidoria23", "Centro de Atendimento" }
                });

            migrationBuilder.InsertData(
                table: "TipoSolicitacoes",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Positiva" },
                    { 2, "Negativa" },
                    { 3, "Sugestão" }
                });

            migrationBuilder.InsertData(
                table: "Solicitacoes",
                columns: new[] { "Id", "Assunto", "Celular", "Detalhes", "Email", "Nome", "PerfilId", "PoloId", "SetorId", "TipoReclamacaoId", "TipoSolicitacaoId" },
                values: new object[] { 1, "Atendimento excelente", "24988677507", "Gostei muito do atendimento feito na instituição, atendeu todas as minhas expectativas", "joaovr2012@outlook.com", "João Vitor Eleutério de Sousa", 1, 1, 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_PerfilId",
                table: "Solicitacoes",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_PoloId",
                table: "Solicitacoes",
                column: "PoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_SetorId",
                table: "Solicitacoes",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_TipoSolicitacaoId",
                table: "Solicitacoes",
                column: "TipoSolicitacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Polos");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropTable(
                name: "TipoSolicitacoes");
        }
    }
}
