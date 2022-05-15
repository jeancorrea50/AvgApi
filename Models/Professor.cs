using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("Professor")]
    public class Professor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Especialidade { get; set; }
        public DateTime? Data_Cadastro { get; } = DateTime.Now;
        public DateTime? Data_Ultima_Alteracao { get; } = DateTime.Now;

    }
    
}
