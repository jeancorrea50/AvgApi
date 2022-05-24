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
        public DbSet<Aluno> Alunos { get; internal set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }

        public AvgContext(DbContextOptions<AvgContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Password = 123456; Persist Security Info = True; User ID=jeancorrea; Initial Catalog = BaseApi; Data Source = JEANCORREA\\SQLEXPRESS"
        //    , builder =>
        //     {
        //         builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        //     });
        //    base.OnConfiguring(optionsBuilder);
        //}

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
            //    modelBuilder.Entity<ProdutoModel>().Property(p => p.ValorUniProduto).HasPrecision(10, 2);
            //    modelBuilder.Entity<ProdutoModel>().Property(p => p.Preco).HasPrecision(10, 2);

            //modelBuilder.Entity<TipoDespesa>()
            //    .HasKey(x => new { x.Id });
            //modelBuilder.Entity<TipoInvestimento>()
            //    .HasKey(x => new { x.Id });
            //modelBuilder.Entity<TipoReceita>()
            //    .HasKey(x => new { x.Id });
            //modelBuilder.Entity<CategoriaModel>()
            //    .HasKey(x => new { x.Id });

            //modelBuilder.Entity<Despesa>()
            //    .HasKey(AD => new { AD.Id });
            //modelBuilder.Entity<Investimento>()
            //    .HasKey(AD => new { AD.Id });
            //modelBuilder.Entity<Receita>()
            //    .HasKey(AD => new { AD.Id });
            //modelBuilder.Entity<CategoriaModel>()
            //    .HasKey(AD => new { AD.Id });
            //modelBuilder.Entity<ProdutoModel>()
            //    .HasKey(AD => new { AD.Id });
            //modelBuilder.Entity<ResumoReceitaDespesa>()
            //    .HasKey(AD => new { AD.Id });
            //modelBuilder.Entity<Aluno>()
            //    .HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });
            //modelBuilder.Entity<Professor>()
            //    .HasKey(AD => new { AD.ProfessorId, AD.AlunoId, AD.DisciplinaId });
            //modelBuilder.Entity<Disciplina>()
            //    .HasKey(AD => new { AD.DisciplinaId });

            //modelBuilder.Entity<AlunoDisciplina>()
            //   .HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });

            //modelBuilder.Entity<Professor>().HasData(
            //        new Professor { Id = 1, Nome = "Jean" });

            //modelBuilder.Entity<Disciplina>().HasData(
            //        new Disciplina { Id = 1, Nome = "Matematica", ProfessorId = 1 });

            //modelBuilder.Entity<Aluno>().HasData(
            //        new Aluno { Id = 1, Nome = "Marta", Sobrenome = "Kent", Telefone = "33225555" });

            //modelBuilder.Entity<AlunoDisciplina>()
            //   .HasKey(AD => new { AD.Id });

            modelBuilder.Entity<Aluno>().HasData(
               new Aluno { Id = 1, Nome = "Pedro Henrique", Sobrenome = "José", Cpf = "06348303179" },
               new Aluno { Id = 2, Nome = "João Pereira", Sobrenome = "Antonia", Cpf = "454321321" },
               new Aluno { Id = 4, Nome = "Raimunda", Sobrenome = "Rafael", Cpf = "4542123113" },
               new Aluno { Id = 5, Nome = "Ronaldo", Sobrenome = "Pinto", Cpf = "789456231" },
               new Aluno { Id = 7, Nome = "Cleuso", Sobrenome = "Reinaldo", Cpf = "4562313" },
               new Aluno { Id = 8, Nome = "Paulo", Sobrenome = "José", Cpf = "06348303179" }

           );

            modelBuilder.Entity<Professor>()
              .HasData(new List<Professor>(){
                    new Professor(1, "Lauro"),
                    new Professor(2, "Roberto"),
                    new Professor(3, "Ronaldo"),
                    new Professor(4, "Rodrigo"),
                    new Professor(5, "Alexandre"),
              });

            modelBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1),
                    new Disciplina(2, "Física", 2),
                    new Disciplina(3, "Português", 3),
                    new Disciplina(4, "Inglês", 4),
                    new Disciplina(5, "Programação", 5)
                });

           

            modelBuilder.Entity<AlunoDisciplina>().HasData(
                new AlunoDisciplina { Id = 30, AlunoId = 1, DisciplinaId = 1 },
                new AlunoDisciplina { Id = 31, AlunoId = 1, DisciplinaId = 2 },
                new AlunoDisciplina { Id = 32, AlunoId = 1, DisciplinaId = 3 },
                new AlunoDisciplina { Id = 33, AlunoId = 1, DisciplinaId = 4 },
                new AlunoDisciplina { Id = 34, AlunoId = 1, DisciplinaId = 5 },
                new AlunoDisciplina { Id = 35, AlunoId = 2, DisciplinaId = 4 },
                new AlunoDisciplina { Id = 36, AlunoId = 2, DisciplinaId = 3 },
                new AlunoDisciplina { Id = 37, AlunoId = 2, DisciplinaId = 2 },
                new AlunoDisciplina { Id = 38, AlunoId = 7, DisciplinaId = 4 },
                new AlunoDisciplina { Id = 39, AlunoId = 7, DisciplinaId = 3 },
                new AlunoDisciplina { Id = 40, AlunoId = 7, DisciplinaId = 2 },
                new AlunoDisciplina { Id = 41, AlunoId = 7, DisciplinaId = 1 },
                new AlunoDisciplina { Id = 42, AlunoId = 4, DisciplinaId = 1 },
                new AlunoDisciplina { Id = 43, AlunoId = 4, DisciplinaId = 4 },
                new AlunoDisciplina { Id = 44, AlunoId = 4, DisciplinaId = 3 },
                new AlunoDisciplina { Id = 45, AlunoId = 5, DisciplinaId = 5 },
                new AlunoDisciplina { Id = 46, AlunoId = 5, DisciplinaId = 4 },
                new AlunoDisciplina { Id = 47, AlunoId = 5, DisciplinaId = 3 },
                new AlunoDisciplina { Id = 48, AlunoId = 5, DisciplinaId = 2 },
                new AlunoDisciplina { Id = 49, AlunoId = 5, DisciplinaId = 1 },
                new AlunoDisciplina { Id = 50, AlunoId = 7, DisciplinaId = 1 },
                new AlunoDisciplina { Id = 51, AlunoId = 7, DisciplinaId = 2 },
                new AlunoDisciplina { Id = 52, AlunoId = 7, DisciplinaId = 3 },
                new AlunoDisciplina { Id = 53, AlunoId = 7, DisciplinaId = 4 },
                new AlunoDisciplina { Id = 54, AlunoId = 7, DisciplinaId = 5 }
                );







            //modelBuilder.Entity<Professor>().HasData(
            //    new Professor { Id = 1, Especialidade = "Java", Nome = "Pietra Rafaela Peixoto", Telefone = "(31) 2881-5021"},
            //    new Professor { Id = 2, Especialidade = "Sistemas Operacionais", Nome = "Alessandra Elisa Luzia da Silva", Telefone = "(96) 2778-0600"},
            //    new Professor { Id = 3, Especialidade = "C#", Nome = "Levi Nathan Moura",Telefone = "(73) 3722-7286" }
            // );

            //modelBuilder.Entity<Aluno>().HasData(
            //    new Aluno { Id = 1, Nome = "Pedro Henrique" , ProfessorId = 2},
            //    new Aluno { Id = 2, Nome = "João Pereira", ProfessorId = 1},
            //    new Aluno { Id = 3, Nome = "Luana Ferreira",  ProfessorId = 2}
            //);

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
