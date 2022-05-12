using AvgApi.Models;
using System.Collections.Generic;

namespace AvgApi.Repository.Interface
{
    public interface ICategoriaRepository
    {
        IEnumerable<CategoriaModel> Categorias { get; }
    }
}
