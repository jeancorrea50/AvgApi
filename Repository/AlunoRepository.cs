using AvgApi.Data;
using AvgApi.Models;
using AvgApi.Repository;
using AvgApi.Utilities;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvgApi.Repository.Interface 
{
    public class AlunoRepository : IAlunoRepository
    {

        private readonly AvgContext _context;
        private readonly IOptions<KeysConfig> chaveConfiguracao;

        public AlunoRepository(AvgContext context)
        {
            _context = context;
        }

        public IEnumerable<Aluno> Alunos => _context.Alunos;

        public Aluno GetAlunoId(int id) => _context.Alunos.FirstOrDefault(a => a.Id == id);

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(pe => pe.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeDisciplina)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.Id == alunoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAlunosAsyncByDisciplinaId(int disciplinaId, bool includeDisciplina)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(p => p.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return await query.ToArrayAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public void UpdateAluno(Aluno model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }
        public void DeleteAluno(int alunoId)
        {

            Aluno aluno = _context.Alunos.Find(alunoId);
            _context.Alunos.Remove(aluno);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public IEnumerable<Aluno> ObterPorPalavraChave(string palavraChave)
        {
            var nomePesquisa = palavraChave.ToLower().Split(' ');

            string nomePesquisaBlocos = string.Empty;

            if (nomePesquisa.Length > 0)
            {
                foreach (var item in nomePesquisa)
                {
                    nomePesquisaBlocos = nomePesquisaBlocos + " " + item;
                }
            }

            nomePesquisaBlocos = nomePesquisaBlocos.Trim();

            var pessoas = ConsultaPalavraChave3String(nomePesquisaBlocos, palavraChave, palavraChave);

            return pessoas;
        }

        public IEnumerable<Aluno> ConsultaPalavraChave3String(string nome, string cpf, string sobrenome)
        {
                          // tras todos os resultados de strings 
            var query = from aluno in _context.Alunos
                        where 
                        aluno.Nome == nome ||
                        aluno.Sobrenome == sobrenome ||
                        aluno.Cpf == cpf
                        select aluno;
                                       
                                       // Com Contais == busca tudo que tem pela palavra chave digitada
                        //where
                        //aluno.Nome.Contains(nome) ||
                        //aluno.Sobrenome.Contains(sobrenome) ||
                        //aluno.Cpf.Contains(cpf)

            return query.ToList();
        }



        //public IEnumerable<Aluno> ObterPorPalavraChave(string nome, string cpf, string email)
        //{
        //    const string query = @"Select Id,Descricao,CodigoInvestimento,DataInclusao
        //                            From Investimento p 
        //                            Where (p.Nome Like :Nome Or p.Cpf = :Cpf Or p.Email = :Email) 
        //                           Order By p.Nome";

        //    var parametros = new
        //    {
        //        Nome = (string.IsNullOrEmpty(nome) == false ? "%" + nome + "%" : ""),
        //        Cpf = (string.IsNullOrEmpty(cpf) == true ? "99999999999" : cpf),
        //        Email = email,
        //    };

        //    return IDbConn.CommandQuery<Pessoa>(query, dataBaseType, parametros).ToList();
        //}

        //public async IEnumerable<Aluno> GetAlunosFiltro(string searchStr)
        //{

        //    var StrList = searchStr.Split(' ').ToList();

        //    foreach (var item in StrList)
        //        result = _context.Alunos.Where(p => p.Nome.Contains(searchStr) || p.Sobrenome.Contains(item) || p.Sobrenome.Contains(searchStr));

        //    return await query2.ToArrayAsync();

        //}


    }


}
