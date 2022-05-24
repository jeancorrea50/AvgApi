using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("AlunoDisciplina")]


    public class AlunoDisciplina
    {
        [Key]
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
