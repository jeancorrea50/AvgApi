using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AvgApi.Models
{
   [Table("Investimento")]
    public class Investimento
    {
        [Key]
        public int Id { get; set; } 
        public string Descricao { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorTotal { get; set; }
        public string DescricaoExtra { get; set; }
        public decimal ValorExtra { get; set; }
        public string CodigoInvestimento { get; set; }
        public decimal DividenteYield { get; set; }
        public decimal DividendosAcoes { get; set; }
        public int Cotas { get; set; }   

        public DateTime? DataInclusao { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataInvestimento { get; set; }

        public IEnumerable<ResumoReceitaDespesa> ResumoReceitaDespesas { get; set; }
        public int TipoInvestimentoId { get; set; }
        public TipoInvestimento TipoInvestimento { get; set; }



    }
}
