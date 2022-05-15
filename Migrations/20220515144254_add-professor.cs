using Microsoft.EntityFrameworkCore.Migrations;

namespace AvgApi.Migrations
{
    public partial class addprofessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Especialidade", "Nome", "Telefone" },
                values: new object[] { 1, "Java", "Pietra Rafaela Peixoto", "(31) 2881-5021" });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Especialidade", "Nome", "Telefone" },
                values: new object[] { 2, "Sistemas Operacionais", "Alessandra Elisa Luzia da Silva", "(96) 2778-0600" });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Especialidade", "Nome", "Telefone" },
                values: new object[] { 3, "C#", "Levi Nathan Moura", "(73) 3722-7286" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
