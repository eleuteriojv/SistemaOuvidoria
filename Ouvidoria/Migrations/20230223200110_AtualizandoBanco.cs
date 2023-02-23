using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ouvidoria.Migrations
{
    public partial class AtualizandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Polos_PoloId",
                table: "Resposta");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Setores_SetorId",
                table: "Resposta");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Solicitacoes_SolicitacaoId",
                table: "Resposta");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_TipoSolicitacoes_TipoSolicitacaoId",
                table: "Resposta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resposta",
                table: "Resposta");

            migrationBuilder.DropIndex(
                name: "IX_Resposta_PoloId",
                table: "Resposta");

            migrationBuilder.DropIndex(
                name: "IX_Resposta_TipoSolicitacaoId",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "PoloId",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "TipoSolicitacaoId",
                table: "Resposta");

            migrationBuilder.RenameTable(
                name: "Resposta",
                newName: "Respostas");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_SolicitacaoId",
                table: "Respostas",
                newName: "IX_Respostas_SolicitacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_SetorId",
                table: "Respostas",
                newName: "IX_Respostas_SetorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Respostas",
                table: "Respostas",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Solicitacoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2023, 2, 23, 17, 1, 10, 64, DateTimeKind.Local).AddTicks(5272));

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Setores_SetorId",
                table: "Respostas",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Solicitacoes_SolicitacaoId",
                table: "Respostas",
                column: "SolicitacaoId",
                principalTable: "Solicitacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Setores_SetorId",
                table: "Respostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Solicitacoes_SolicitacaoId",
                table: "Respostas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Respostas",
                table: "Respostas");

            migrationBuilder.RenameTable(
                name: "Respostas",
                newName: "Resposta");

            migrationBuilder.RenameIndex(
                name: "IX_Respostas_SolicitacaoId",
                table: "Resposta",
                newName: "IX_Resposta_SolicitacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Respostas_SetorId",
                table: "Resposta",
                newName: "IX_Resposta_SetorId");

            migrationBuilder.AddColumn<int>(
                name: "PoloId",
                table: "Resposta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoSolicitacaoId",
                table: "Resposta",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resposta",
                table: "Resposta",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Solicitacoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2023, 2, 23, 15, 16, 7, 261, DateTimeKind.Local).AddTicks(3986));

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_PoloId",
                table: "Resposta",
                column: "PoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_TipoSolicitacaoId",
                table: "Resposta",
                column: "TipoSolicitacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Polos_PoloId",
                table: "Resposta",
                column: "PoloId",
                principalTable: "Polos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Setores_SetorId",
                table: "Resposta",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Solicitacoes_SolicitacaoId",
                table: "Resposta",
                column: "SolicitacaoId",
                principalTable: "Solicitacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_TipoSolicitacoes_TipoSolicitacaoId",
                table: "Resposta",
                column: "TipoSolicitacaoId",
                principalTable: "TipoSolicitacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
