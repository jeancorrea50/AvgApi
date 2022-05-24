using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvgApi.Migrations
{
    public partial class inicial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Aluno",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 12, 18, 43, 458, DateTimeKind.Local).AddTicks(2700), new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(5045) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6616), new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6623) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6626), new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6627) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6628), new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6631), new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6633) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6634), new DateTime(2022, 5, 24, 12, 18, 43, 459, DateTimeKind.Local).AddTicks(6635) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Aluno");

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 11, 12, 47, 499, DateTimeKind.Local).AddTicks(8323), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(278) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1791), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1796) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1799), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1801), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1804), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DataAgora", "DataNascimento" },
                values: new object[] { new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1807), new DateTime(2022, 5, 24, 11, 12, 47, 501, DateTimeKind.Local).AddTicks(1808) });
        }
    }
}
