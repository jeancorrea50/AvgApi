using Microsoft.EntityFrameworkCore.Migrations;

namespace AvgApi.Migrations
{
    public partial class addaluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Nome", "ProfessorId" },
                values: new object[] { 1, "Pedro Henrique", 2 });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Nome", "ProfessorId" },
                values: new object[] { 2, "João Pereira", 1 });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Nome", "ProfessorId" },
                values: new object[] { 3, "Luana Ferreira", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
