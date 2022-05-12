using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvgApi.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {
            [Key]
            public int Id { get; set; }
            public string DscProduto { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }

            public string Cor { get; set; }
            public int Estoque { get; set; }
            public Decimal Preco { get; set; }

            public string InfoProduto { get; set; }
            public decimal ValorUniProduto { get; set; }
            public int QuantidadeProduto { get; set; }
            public string MemoriaProduto { get; set; }
            public string PolegadaProduto { get; set; }
            public string TamanhoProduto { get; set; }
            public string VoltagemProduto { get; set; }
            public DateTime? DataCadastroProduto { get; } = DateTime.Now;
            public int CategoriaModelId { get; set; }
            public CategoriaModel CategoriaModels { get; set; }
        public int ProdutoId { get; internal set; }
    }
}
