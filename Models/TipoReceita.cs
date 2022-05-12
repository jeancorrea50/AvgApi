using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("TipoReceita")]
    public class TipoReceita
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<Receita> Receitas { get; set; }

    }
}
