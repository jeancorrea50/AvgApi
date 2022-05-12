using AvgApi.Models;
using System.Collections.Generic;

namespace AvgApi.Repository.Interface
{
    public interface IProdutoRepository
    {
        IEnumerable<ProdutoModel> Produtos { get; }
        ProdutoModel GetProdutoById(int produtoId);
    }
}
