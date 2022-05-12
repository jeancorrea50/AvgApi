using AvgApi.Data;
using AvgApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AvgApi.Repository.Interface
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AvgContext _context;

        public ProdutoRepository(AvgContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<ProdutoModel> Produtos => _context.Produtos.Include(c => c.CategoriaModelId);

        //public IEnumerable<ProdutoModel> ProdutosPreferidos => _context.Produtos.Where(p => p.IsProdutoPreferido).Include(c => c.Categoria);

        public ProdutoModel GetProdutoById(int produtoId) => _context.Produtos.FirstOrDefault(l => l.Id == produtoId);
    }
}
