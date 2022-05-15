using AvgApi.Controllers;
using AvgApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvgApi.Data
{
    public class AvgContext : DbContext
    {
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<TipoDespesa> TipoDespesas { get; set; }
        public DbSet<TipoInvestimento> TipoInvestimentos { get; set; }
        public DbSet<TipoReceita> TipoReceitas { get; set; }
        public DbSet<ResumoReceitaDespesa> ResumoReceitaDespesas { get; set; }
        public DbSet<Professor>  Professores { get; set; }



        public AvgContext(DbContextOptions<AvgContext> options) : base(options)
        {
        }


        // string conexão direto com sql
        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
              // string C com o banco de dados sql server
              optionsBuilder.UseSqlServer("Password=Bf18102907;Persist Security Info=True;User ID=jeancpcorrea;Initial Catalog=JcpApi;Data Source=\\SQLEXPRESS");

              // optionsBuilder.UseSqlServer("Password=Bf18102907;Persist Security Info=True;User ID=jeancpcorrea;Initial Catalog=JcpApi;Data Source=DESKTOP-43O4B71\\SQLEXPRESS");

          }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoModel>().Property(p => p.ValorUniProduto).HasPrecision(10, 2);
            modelBuilder.Entity<ProdutoModel>().Property(p => p.Preco).HasPrecision(10, 2);

            modelBuilder.Entity<TipoDespesa>()
                .HasKey(x => new { x.Id});
            modelBuilder.Entity<TipoInvestimento>()
                .HasKey(x => new { x.Id});
            modelBuilder.Entity<TipoReceita>()
                .HasKey(x => new { x.Id});
            modelBuilder.Entity<CategoriaModel>()
                .HasKey(x => new { x.Id});

            modelBuilder.Entity<Despesa>()
            .HasKey(AD => new { AD.Id});
            modelBuilder.Entity<Investimento>()
           .HasKey(AD => new { AD.Id});
            modelBuilder.Entity<Receita>()
           .HasKey(AD => new { AD.Id}); 
            modelBuilder.Entity<CategoriaModel>()
           .HasKey(AD => new { AD.Id});
            modelBuilder.Entity<ProdutoModel>()
            .HasKey(AD => new { AD.Id });
            modelBuilder.Entity<ResumoReceitaDespesa>()
           .HasKey(AD => new { AD.Id });
            modelBuilder.Entity<Professor>()
           .HasKey(AD => new { AD.Id});

            modelBuilder.Entity<CategoriaModel>().HasData(
            new CategoriaModel { Id = 1, DescCategoria = "Celular"},
            new CategoriaModel { Id = 2, DescCategoria = "Televisão" },
            new CategoriaModel { Id = 3, DescCategoria = "Notebook" },
            new CategoriaModel { Id = 14, DescCategoria = "Pc Gamer" });

            modelBuilder.Entity<ProdutoModel>().HasData(
            new ProdutoModel { Id = 1, Marca = "Apple", Modelo = "Iphone 8", Cor = "Vermelho", Estoque = 7, Preco = 2600.00M, CategoriaModelId = 1},
            new ProdutoModel { Id = 2, Marca = "Apple", Modelo = "Iphone X", Cor = "Branco", Estoque = 4, Preco = 3100.00M, CategoriaModelId = 1 },
            new ProdutoModel { Id = 3, Marca = "Apple", Modelo = "Iphone 11", Cor = "Preto", Estoque = 1, Preco = 4800.00M, CategoriaModelId = 1 });

            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = 1, Especialidade = "Java", Nome = "Pietra Rafaela Peixoto", Telefone = "(31) 2881-5021"},
                new Professor { Id = 2, Especialidade = "Sistemas Operacionais", Nome = "Alessandra Elisa Luzia da Silva", Telefone = "(96) 2778-0600"},
                new Professor { Id = 3, Especialidade = "C#", Nome = "Levi Nathan Moura",Telefone = "(73) 3722-7286" }
             );

            //modelBuilder.Entity<ResumoReceitaDespesa>().HasData(
            //new ResumoReceitaDespesa { Id = 1, Descricao = "Ações Brasil", ResumoReceitaDespesaId = 1 },
            //new ResumoReceitaDespesa { Id = 2, Descricao = "Fundos Imobiliarios" },
            //new ResumoReceitaDespesa { Id = 3, Descricao = "Tesouro Direto" },
            //new ResumoReceitaDespesa { Id = 4, Descricao = "Poupança" },
            //new ResumoReceitaDespesa { Id = 5, Descricao = "Ações Estrangeira" });

            //modelBuilder.Entity<Investimento>().HasData(
            //new Investimento { Id = 1, Descricao = "Ações Brasil", ResumoReceitaDespesaId = 1 },
            //new Investimento { Id = 2, Descricao = "Fundos Imobiliarios" },
            //new Investimento { Id = 3, Descricao = "Tesouro Direto" },
            //new Investimento { Id = 4, Descricao = "Poupança" },
            //new Investimento { Id = 5, Descricao = "Ações Estrangeira" });

            //modelBuilder.Entity<TipoInvestimento>().HasData(
            //new TipoInvestimento { Id = 1, Descricao = "Ações Brasil" },
            //new TipoInvestimento { Id = 2, Descricao = "Fundos Imobiliarios" },
            //new TipoInvestimento { Id = 3, Descricao = "Tesouro Direto" },
            //new TipoInvestimento { Id = 4, Descricao = "Poupança" },
            //new TipoInvestimento { Id = 5, Descricao = "Ações Estrangeira" });


            // to passando que o novo das tabelas no banco de dados será "Categoria " e "Produto", caso nao passe este parametro, será criado no pural, ex "Produtos" 
            // modelBuilder.Entity<Produto>().ToTable("Produto");
            // modelBuilder.Entity<Fornecedor>().ToTable("Fornecedor");
            //   modelBuilder.Entity<Categoria>().ToTable("Categoria");


      

            // Adicionar manunalmente os registros no banco de dados 
            //modelBuilder.Entity<TipoDespesa>().HasData(
            //new TipoDespesa { Id = 1, Descricao = "Animal"},
            //new TipoDespesa { Id = 2, Descricao = "Casa" },
            //new TipoDespesa { Id = 3, Descricao = "Pessoal" },
            //new TipoDespesa { Id = 4, Descricao = "Lorenzo" },
            //new TipoDespesa { Id = 5, Descricao = "Finaciamento" },
            //new TipoDespesa { Id = 6, Descricao = "Cartão" },
            //new TipoDespesa { Id = 7, Descricao = "Alimentação" },
            //new TipoDespesa { Id = 8, Descricao = "Investimentos" },
            //new TipoDespesa { Id = 9, Descricao = "Luz" },
            //new TipoDespesa { Id = 10, Descricao = "Agua" },
            //new TipoDespesa { Id = 11, Descricao = "Internet" },
            //new TipoDespesa { Id = 12, Descricao = "Iptu" },
            //new TipoDespesa { Id = 13, Descricao = "Documento Carro" },
            //new TipoDespesa { Id = 14, Descricao = "Combustivel" },
            //new TipoDespesa { Id = 15, Descricao = "Faculdade" },
            //new TipoDespesa { Id = 16, Descricao = "Unimed" },
            //new TipoDespesa { Id = 17, Descricao = "Lazer" },
            //new TipoDespesa { Id = 18, Descricao = "Manutenção Carro" });



            //modelBuilder.Entity<TipoReceita>().HasData(
            //new TipoReceita { Id = 1, Descricao = "Salario Jean" },
            //new TipoReceita { Id = 2, Descricao = "Salario Carol" },
            //new TipoReceita { Id = 3, Descricao = "Inss Lorenzo" },
            //new TipoReceita { Id = 4, Descricao = "Extra" },
            //new TipoReceita { Id = 5, Descricao = "Aluguel" },
            //new TipoReceita { Id = 6, Descricao = "Dividendos" });


         

        }
    }
}
