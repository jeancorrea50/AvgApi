using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("Receita")]
    public class Receita
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorMensal { get; set; }
        public string DescricaoExtra { get; set; }

        public decimal ValorExtra { get; set; }

        public decimal ValorMedia { get; set; }
        public string Status { get; set; }
        public DateTime? DataInclusao { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string FontePagamento { get; set; }
        public IEnumerable<ResumoReceitaDespesa> ResumoReceitaDespesas { get; set; }

        public int ReceitaId { get; set; }
        public TipoReceita TipoReceita { get; set; }

    }
}
