using AvgApi.Models;
using System.Collections.Generic;

namespace AvgApi.Repository.Interface
{
    public interface IProfessorRepository
    {
        IEnumerable<Professor> Professores { get; }
        Professor GetProfessorById(int professorId);
    }
}
