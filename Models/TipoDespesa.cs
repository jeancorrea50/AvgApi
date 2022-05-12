using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("TipoDespesa")]
    public class TipoDespesa
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }

       public IEnumerable<Despesa> Despesas { get; set; }
    }
}
