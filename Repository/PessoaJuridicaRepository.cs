using Microsoft.EntityFrameworkCore;
using AvgApi.Data;
using AvgApi.Models;
using AvgApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AvgApi.Repositories
{
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        private readonly AvgContext _context;

        public PessoaJuridicaRepository(AvgContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<PessoaJuridica> ListaPessoaJuridica(int idPessoaJuridica)
        {
            return _context.PessoaJuridica.ToList();
        }

        public IList<PessoaJuridica> ListaPessoaJuridicaNomeId(string filtro)
        {
            return _context.PessoaJuridica.Where(x => (x.NomeFantasia.Contains(filtro) == true || string.IsNullOrEmpty(filtro))).ToList();
        }
          
        public IEnumerable<PessoaJuridica> PessoaJuridica => _context.PessoaJuridica.ToList();

        public List<PessoaJuridica> ObterTodasPessoaJuridica(int idPessoaJuridica)
        {
            return _context.PessoaJuridica.ToList();
        }
        public PessoaJuridica PessoaJuridicaPorId(int idPessoaJuridica)
        {
            return _context.PessoaJuridica.Where(
                x => x.Id == idPessoaJuridica).FirstOrDefault();
        }
        public void DeletePessoaJuridica(int idPessoaJuridica)
        {
            
            PessoaJuridica pessoaJuridica = _context.PessoaJuridica.Find(idPessoaJuridica);
            _context.PessoaJuridica.Remove(pessoaJuridica);
            Save();
        }
        public void UpdatePessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            _context.Entry(pessoaJuridica).State = EntityState.Modified;
            Save();
        }
        public void SalvarPesssoaJuridica(PessoaJuridica pessoaJuridica)
        {
          
            _context.PessoaJuridica.Add(pessoaJuridica);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public PessoaJuridica DetalhePessoaJuridicaCnpj(PessoaJuridica pessoaJuridica)
        {
            return _context.PessoaJuridica.FirstOrDefault(
                   x => x.Cnpj != null && x.Cnpj == pessoaJuridica.Cnpj); 
        }

    }
}
