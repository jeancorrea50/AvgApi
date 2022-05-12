using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvgApi.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDespesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDespesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoIvestimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIvestimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoReceita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoReceita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DscProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    InfoProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorUniProduto = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "int", nullable: false),
                    MemoriaProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolegadaProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TamanhoProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoltagemProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_CategoriaModelId",
                        column: x => x.CategoriaModelId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoExtra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorExtra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDespesa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDespesaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesa_TipoDespesa_TipoDespesaId",
                        column: x => x.TipoDespesaId,
                        principalTable: "TipoDespesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoExtra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorExtra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodigoInvestimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DividenteYield = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DividendosAcoes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cotas = table.Column<int>(type: "int", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInvestimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoInvestimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investimento_TipoIvestimento_TipoInvestimentoId",
                        column: x => x.TipoInvestimentoId,
                        principalTable: "TipoIvestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoExtra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorExtra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMedia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRecebimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FontePagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceitaId = table.Column<int>(type: "int", nullable: false),
                    TipoReceitaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_TipoReceita_TipoReceitaId",
                        column: x => x.TipoReceitaId,
                        principalTable: "TipoReceita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResumoReceitaDespesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMedia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Porcentagem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentagemReceita = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentagemInvestimento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentagemDespesa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentagemTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DespesaId = table.Column<int>(type: "int", nullable: false),
                    ReceitaId = table.Column<int>(type: "int", nullable: false),
                    InvestimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumoReceitaDespesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumoReceitaDespesa_Despesa_DespesaId",
                        column: x => x.DespesaId,
                        principalTable: "Despesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumoReceitaDespesa_Investimento_InvestimentoId",
                        column: x => x.InvestimentoId,
                        principalTable: "Investimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumoReceitaDespesa_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "DescCategoria" },
                values: new object[,]
                {
                    { 1, "Celular" },
                    { 2, "Televisão" },
                    { 3, "Notebook" },
                    { 14, "Pc Gamer" }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaModelId", "Cor", "DscProduto", "Estoque", "InfoProduto", "Marca", "MemoriaProduto", "Modelo", "PolegadaProduto", "Preco", "QuantidadeProduto", "TamanhoProduto", "ValorUniProduto", "VoltagemProduto" },
                values: new object[] { 1, 1, "Vermelho", null, 7, null, "Apple", null, "Iphone 8", null, 2600.00m, 0, null, 0m, null });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaModelId", "Cor", "DscProduto", "Estoque", "InfoProduto", "Marca", "MemoriaProduto", "Modelo", "PolegadaProduto", "Preco", "QuantidadeProduto", "TamanhoProduto", "ValorUniProduto", "VoltagemProduto" },
                values: new object[] { 2, 1, "Branco", null, 4, null, "Apple", null, "Iphone X", null, 3100.00m, 0, null, 0m, null });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaModelId", "Cor", "DscProduto", "Estoque", "InfoProduto", "Marca", "MemoriaProduto", "Modelo", "PolegadaProduto", "Preco", "QuantidadeProduto", "TamanhoProduto", "ValorUniProduto", "VoltagemProduto" },
                values: new object[] { 3, 1, "Preto", null, 1, null, "Apple", null, "Iphone 11", null, 4800.00m, 0, null, 0m, null });

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_TipoDespesaId",
                table: "Despesa",
                column: "TipoDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Investimento_TipoInvestimentoId",
                table: "Investimento",
                column: "TipoInvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaModelId",
                table: "Produto",
                column: "CategoriaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_TipoReceitaId",
                table: "Receita",
                column: "TipoReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumoReceitaDespesa_DespesaId",
                table: "ResumoReceitaDespesa",
                column: "DespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumoReceitaDespesa_InvestimentoId",
                table: "ResumoReceitaDespesa",
                column: "InvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumoReceitaDespesa_ReceitaId",
                table: "ResumoReceitaDespesa",
                column: "ReceitaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "ResumoReceitaDespesa");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.DropTable(
                name: "Investimento");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "TipoDespesa");

            migrationBuilder.DropTable(
                name: "TipoIvestimento");

            migrationBuilder.DropTable(
                name: "TipoReceita");
        }
    }
}
