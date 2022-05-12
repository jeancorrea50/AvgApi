using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("ResumoReceitaDespesa")]

    public class ResumoReceitaDespesa
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorMensal { get; set; }
        public decimal ValorMedia { get; set; }
        public DateTime? DataInclusao { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }

        public decimal Porcentagem { get; set; }
        public decimal PorcentagemReceita { get; set; }

        public decimal PorcentagemInvestimento { get; set; }
        public decimal PorcentagemDespesa { get; set; }
        public decimal PorcentagemTotal { get; set; }

        public int DespesaId { get; set; }
        public Despesa Despesa { get; set; }

        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }

        public int InvestimentoId { get; set; }
        public Investimento Investimento { get; set; }



    }
}
