using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("Despesa")]
    public class Despesa
    { 
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorUnitario { get; set; }
        public string DescricaoExtra { get; set; }

        public decimal ValorExtra { get; set; }
        public string Status { get; set; }
        public DateTime? DataInclusao { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }
        public DateTime DataDespesa { get; set; }
        public IEnumerable<ResumoReceitaDespesa> ResumoReceitaDespesas { get; set; }
        public int TipoDespesaId { get; set; }
        public TipoDespesa TipoDespesa { get; set; }



    }
}
