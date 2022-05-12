using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("PessoaFisica")]
    public class PessoaFisica
    {
        [Key]
        public int Id { get; set; }
        public String Cpf { get; set; }
        public String Nome { get; set; }
        public String Sobrenome { get; set; }

        public string Email { get; set; }
        public string telefone { get; set; }    



    }
}
