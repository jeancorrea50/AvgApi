using AvgApi.Data;
using AvgApi.Models;
using AvgApi.Repository.Interface;
using System.Collections.Generic;

namespace AvgApi.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AvgContext _context;

        public CategoriaRepository(AvgContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<CategoriaModel> Categorias => _context.Categorias;
    }
}
