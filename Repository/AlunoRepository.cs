using AvgApi.Data;
using AvgApi.Models;
using AvgApi.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AvgApi.Repository.Interface 
{
    public class AlunoRepository : IAlunoRepository
    {

        private readonly AvgContext _context;

        public AlunoRepository(AvgContext context)
        {
            _context=context;
        }

        public IEnumerable<Aluno> Alunos => _context.Alunos;

        public Aluno GetAluno(int id) => _context.Alunos.FirstOrDefault(a => a.Id == id);
    }
}
