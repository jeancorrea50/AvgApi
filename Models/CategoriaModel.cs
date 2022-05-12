using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvgApi.Models
{
    [Table("Categoria")]
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        public string DescCategoria { get; set; }
        public DateTime? DataCadastroCategoria { get; } = DateTime.Now;

        public IEnumerable<ProdutoModel> ProdutoModels { get; set; }

    }
}
