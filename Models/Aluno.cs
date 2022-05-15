using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvgApi.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? Data_Cadastro { get; } = DateTime.Now;
        public DateTime? Data_Ultima_Alteracao { get; } = DateTime.Now;
        public int ProfessorId { get; set; }

    }
}
