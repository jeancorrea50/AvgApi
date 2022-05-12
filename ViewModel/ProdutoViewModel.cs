using AvgApi.Models;
using System.Collections.Generic;

namespace AvgApi.ViewModel
{
    public class ProdutoViewModel
    {
        public IEnumerable<ProdutoModel> Produtos { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
