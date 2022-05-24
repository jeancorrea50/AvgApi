using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvgApi.Migrations
{
    public partial class populartabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Cpf", "DataAgora", "DataNascimento", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, "06348303179", new DateTime(2022, 5, 24, 11, 12, 47, 499, DateTimeKind.Local).AddTicks(8323), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(278), "Pedro Henrique", "José", null },
                    { 2, "454321321", new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1791), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1796), "João Pereira", "Antonia", null },
                    { 4, "4542123113", new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1799), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1800), "Raimunda", "Rafael", null },
                    { 5, "789456231", new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1801), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1803), "Ronaldo", "Pinto", null },
                    { 7, "4562313", new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1804), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1805), "Cleuso", "Reinaldo", null },
                    { 8, "06348303179", new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1807), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1808), "Paulo", "José", null }
                });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Lauro" },
                    { 2, "Roberto" },
                    { 3, "Ronaldo" },
                    { 4, "Rodrigo" },
                    { 5, "Alexandre" }
                });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "Nome", "ProfessorId" },
                values: new object[,]
                {
                    { 1, "Matemática", 1 },
                    { 2, "Física", 2 },
                    { 3, "Português", 3 },
                    { 4, "Inglês", 4 },
                    { 5, "Programação", 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "Id", "AlunoId", "DisciplinaId" },
                values: new object[,]
                {
                    { 30, 1, 1 },
                    { 34, 1, 5 },
                    { 53, 7, 4 },
                    { 46, 5, 4 },
                    { 43, 4, 4 },
                    { 38, 7, 4 },
                    { 35, 2, 4 },
                    { 33, 1, 4 },
                    { 52, 7, 3 },
                    { 47, 5, 3 },
                    { 44, 4, 3 },
                    { 45, 5, 5 },
                    { 39, 7, 3 },
                    { 32, 1, 3 },
                    { 51, 7, 2 },
                    { 48, 5, 2 },
                    { 40, 7, 2 },
                    { 37, 2, 2 },
                    { 31, 1, 2 },
                    { 50, 7, 1 },
                    { 49, 5, 1 },
                    { 42, 4, 1 },
                    { 41, 7, 1 },
                    { 36, 2, 3 },
                    { 54, 7, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "AlunoDisciplina",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Disciplina",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disciplina",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Disciplina",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Disciplina",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Disciplina",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Professor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Professor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Professor",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
