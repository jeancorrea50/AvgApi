using AvgApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvgApi.Repository.Interface
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> Alunos { get; }

        Aluno GetAlunoId(int id);

        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAlunosAsyncByDisciplinaId(int disciplinaId, bool includeDisciplina);
        Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeProfessor);
        Task<bool> SaveChangesAsync();
        public void UpdateAluno(Aluno model);
        public void DeleteAluno(int idPessoaJuridica);
        public IEnumerable<Aluno> ObterPorPalavraChave(string palavraChave);

        public IEnumerable<Aluno> ConsultaPalavraChave3String(string nome, string cpf, string sobrenome);

        public IEnumerable<Aluno> ObterPorPalavraChaveIntStringData(string palavraChave);

    }
}
