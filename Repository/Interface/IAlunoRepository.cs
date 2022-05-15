using AvgApi.Models;
using System.Collections.Generic;

namespace AvgApi.Repository.Interface
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> Alunos { get; }

        Aluno GetAluno(int id);
    }
}
