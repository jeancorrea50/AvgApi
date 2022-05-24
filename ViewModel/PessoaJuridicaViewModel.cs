using AvgApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvgApi.ViewModel
{
    public class PessoaJuridicaViewModel
    {
        public PessoaJuridicaViewModel()
        {
            this.ListaResumo = new List<Resumo>();
        }
        public List<Resumo> ListaResumo { get; set; }
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }
        public DateTime? DataInclusao { get; set; } 
        public string DataAlteracao { get; set; }
        public string InscricaoMunicipal { get; set; }
        public Boolean InscMunicipalIsenta { get; set; }
        public string InscricaoEstadual { get; set; }
        public Boolean InscEstadualIsenta { get; set; }
        public IEnumerable<PessoaJuridica> pessoaJuridica { get; set; }

    }

    public class Resumo
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }


    }
}