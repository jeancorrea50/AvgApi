using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("TipoIvestimento")]
    public class TipoInvestimento
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<Investimento> Investimentos { get; set; }


    }
}
