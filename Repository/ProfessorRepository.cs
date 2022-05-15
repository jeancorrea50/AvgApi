using AvgApi.Data;
using AvgApi.Models;
using AvgApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AvgApi.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AvgContext _context;

        public ProfessorRepository(AvgContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Professor> Professores => _context.Professores;
        public Professor GetProfessorById(int professorId)  => _context.Professores.FirstOrDefault(p => p.Id == professorId);
    }
}
