using AvgApi.Models;
using System.Collections.Generic;

namespace AvgApi.Repositories.Interfaces
{
    public interface IPessoaJuridicaRepository
    {
        IEnumerable<PessoaJuridica> ListaPessoaJuridica(int idPessoaJuridica);
        IEnumerable<PessoaJuridica> PessoaJuridica { get; }

        public List<PessoaJuridica> ObterTodasPessoaJuridica(int idPessoaJuridica);
        public IList<PessoaJuridica> ListaPessoaJuridicaNomeId(string filtro);

        public PessoaJuridica PessoaJuridicaPorId(int idPessoaJuridica);
        void DeletePessoaJuridica(int idPessoaJuridica);
        void SalvarPesssoaJuridica(PessoaJuridica pessoaJuridica);
        void UpdatePessoaJuridica(PessoaJuridica pessoaJuridica);
        public void Save();
        public PessoaJuridica DetalhePessoaJuridicaCnpj(PessoaJuridica pessoaJuridica);
    }
}
