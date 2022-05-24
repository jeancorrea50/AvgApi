using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("Professor")]
    public class Professor
    {
        public Professor() { }
        public Professor(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }

    }
    
}
