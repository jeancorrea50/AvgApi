using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvgApi.Models
{
    [Table("PessoaJuridica")]
    public class PessoaJuridica
    {
        [Key]
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

        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DataInclusao { get; set; } = DateTime.Now;
        public string DataAlteracao { get; set; }
        public string InscricaoMunicipal { get; set; }
        public Boolean InscMunicipalIsenta { get; set; }
        public string InscricaoEstadual { get; set; }
        public Boolean InscEstadualIsenta { get; set; }
    }
}
