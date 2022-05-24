using AvgApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AvgApi.Models;
using System.Data;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Net;
using AvgApi.ViewModel;
using Newtonsoft.Json.Linq;
using System.Linq;
using AvgApi.Data;
using System.Collections.Generic;

namespace AvgApi.Controllers
{
    public class PessoaJuridicaController : Controller
    {
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;

        public PessoaJuridicaController(IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository;

        }
        public ActionResult Index()
        {
            // DIRETO PELO REPOSITORY

            //var listaPessoaJuridica = _pessoaJuridicaRepository.ListaPessoaJuridica();

            // DIRETO POR LISTA EM VIEW MODEL

            //var listaViewModel = new PessoaJuridicaViewModel();

            //listaViewModel.pessoaJuridica = _pessoaJuridicaRepository.PessoaJuridica;

            int idPessoaJuridica = 0;

            var listaViewModel = new PessoaJuridicaViewModel();

            listaViewModel.ListaResumo = _pessoaJuridicaRepository.ListaPessoaJuridica(idPessoaJuridica).Select(s => new Resumo { Id = s.Id, NomeFantasia = s.NomeFantasia, Cnpj = s.Cnpj, Pais = s.Pais, Uf = s.Uf, Municipio = s.Municipio }).ToList();

            foreach (var item in listaViewModel.ListaResumo)
            {
                var modelPessoaJuridica = _pessoaJuridicaRepository.PessoaJuridicaPorId(item.Id);

            }


            return View(listaViewModel);
        }

        //public ActionResult List()
        //{
        //    // DIRETO PELO REPOSITORY

        //    //var listaPessoaJuridica = _pessoaJuridicaRepository.ListaPessoaJuridica();

        //    ViewBag.Equipamento = _pessoaJuridicaRepository.PessoaJuridica;

        //    var listaViewModel = new PessoaJuridicaViewModel();
        //    listaViewModel.pessoaJuridica = _pessoaJuridicaRepository.PessoaJuridica;

        //    return View(listaViewModel);
        //}

        public ActionResult Novo(int? idPessoaJuridica = null)
        {
            PessoaJuridicaViewModel pessoaJuridicaViewModel = new PessoaJuridicaViewModel();

            try
            {

                if (idPessoaJuridica > 0)
                {
                    var listaPessoaJuridica = _pessoaJuridicaRepository.PessoaJuridicaPorId(idPessoaJuridica.Value);

                    pessoaJuridicaViewModel.Id = listaPessoaJuridica.Id;
                    pessoaJuridicaViewModel.Cnpj = listaPessoaJuridica.Cnpj;
                    pessoaJuridicaViewModel.Bairro = listaPessoaJuridica.Bairro;
                    pessoaJuridicaViewModel.Cep = listaPessoaJuridica.Cep;
                    pessoaJuridicaViewModel.Complemento = listaPessoaJuridica.Complemento;
                    pessoaJuridicaViewModel.Logradouro = listaPessoaJuridica.Logradouro;
                    pessoaJuridicaViewModel.Email = listaPessoaJuridica.Email;
                    pessoaJuridicaViewModel.Telefone = listaPessoaJuridica.Telefone;
                    pessoaJuridicaViewModel.RazaoSocial = listaPessoaJuridica.RazaoSocial;
                    pessoaJuridicaViewModel.Uf = listaPessoaJuridica.Uf;
                    pessoaJuridicaViewModel.Pais = listaPessoaJuridica.Pais;
                    pessoaJuridicaViewModel.NomeFantasia = listaPessoaJuridica.NomeFantasia;
                    pessoaJuridicaViewModel.Municipio = listaPessoaJuridica.Municipio;
                    pessoaJuridicaViewModel.Numero = listaPessoaJuridica.Numero;

                }
                else
                {
                    pessoaJuridicaViewModel.pessoaJuridica = _pessoaJuridicaRepository.PessoaJuridica;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index", pessoaJuridicaViewModel);

        }

        [HttpPost]
        public ActionResult Salvar(PessoaJuridicaViewModel pessoaJuridica)
        {
            var addPessoaJuridica = new PessoaJuridica();

            try
            {

                if (pessoaJuridica.Id == 0)
                {

                    addPessoaJuridica.Id = pessoaJuridica.Id;
                    addPessoaJuridica.Cnpj = pessoaJuridica.Cnpj;
                    addPessoaJuridica.Bairro = pessoaJuridica.Bairro;
                    addPessoaJuridica.Cep = pessoaJuridica.Cep;
                    addPessoaJuridica.Complemento = pessoaJuridica.Complemento;
                    addPessoaJuridica.Email = pessoaJuridica.Email;
                    addPessoaJuridica.Telefone = pessoaJuridica.Telefone;
                    addPessoaJuridica.RazaoSocial = pessoaJuridica.RazaoSocial;
                    addPessoaJuridica.Uf = pessoaJuridica.Uf;
                    addPessoaJuridica.Pais = pessoaJuridica.Pais;
                    addPessoaJuridica.NomeFantasia = pessoaJuridica.NomeFantasia;
                    addPessoaJuridica.Municipio = pessoaJuridica.Municipio;
                    addPessoaJuridica.Numero = pessoaJuridica.Numero;

                    _pessoaJuridicaRepository.SalvarPesssoaJuridica(addPessoaJuridica);
                }
                else
                {
                    addPessoaJuridica.Id = pessoaJuridica.Id;
                    addPessoaJuridica.Cnpj = pessoaJuridica.Cnpj;
                    addPessoaJuridica.Bairro = pessoaJuridica.Bairro;
                    addPessoaJuridica.Cep = pessoaJuridica.Cep;
                    addPessoaJuridica.Complemento = pessoaJuridica.Complemento;
                    addPessoaJuridica.Email = pessoaJuridica.Email;
                    addPessoaJuridica.Telefone = pessoaJuridica.Telefone;
                    addPessoaJuridica.RazaoSocial = pessoaJuridica.RazaoSocial;
                    addPessoaJuridica.Uf = pessoaJuridica.Uf;
                    addPessoaJuridica.Pais = pessoaJuridica.Pais;
                    addPessoaJuridica.NomeFantasia = pessoaJuridica.NomeFantasia;
                    addPessoaJuridica.Municipio = pessoaJuridica.Municipio;
                    addPessoaJuridica.Numero = pessoaJuridica.Numero;

                    _pessoaJuridicaRepository.UpdatePessoaJuridica(addPessoaJuridica);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index", addPessoaJuridica);


        }

        [HttpPost]
        public ActionResult Excluir(int idPessoaJuridica)
        {
            _pessoaJuridicaRepository.DeletePessoaJuridica(idPessoaJuridica);

            return Json(true);

        }
        // Filtrar por String
        public ViewResult FiltrarPessoaJuridicaString(string filtrar)
        {
            string _filtroString = filtrar;
            var model = new PessoaJuridicaViewModel();

            // DIRETO EM LISTA DE REPOSITORY

            //pessoaJuridica = _pessoaJuridicaRepository.PessoaJuridica.Where(p => p.NomeFantasia.ToLower().Contains(_filtroString.ToLower()));



            model.ListaResumo = _pessoaJuridicaRepository.ListaPessoaJuridicaNomeId(_filtroString).Select(s => new Resumo {
                Id = s.Id, NomeFantasia = s.NomeFantasia,
                RazaoSocial = s.RazaoSocial,
                Cnpj = s.Cnpj,
                Uf =s.Uf,
                Pais = s.Pais,
                Municipio = s.Municipio,
                Bairro = s.Bairro}).OrderBy(s => s.Id).ToList();


            foreach (var item in model.ListaResumo)
            {
                var juridica = _pessoaJuridicaRepository.PessoaJuridicaPorId(item.Id);
            }

            return View("FiltrarResultados", model.ListaResumo); 
        }
    

    }
}


// FILTRAR POR ID 

//public ViewResult FiltrarPessoaJuridicaPorId(int idPessoaJuridica)
//{
//    int _filtroId = idPessoaJuridica;
//    IEnumerable<PessoaJuridica> pessoaJuridica;
//    string currentCategory = string.Empty;

//    if (_filtroId == 0)
//    {
//        pessoaJuridica = _pessoaJuridicaRepository.PessoaJuridica.OrderBy(p => p.Id);
//    }
//    else
//    {
//        pessoaJuridica = _pessoaJuridicaRepository.PessoaJuridica.Where(p => p.Id == _filtroId).ToList();
//    }

//    return View("FiltrarResultados", new PessoaJuridicaViewModel
//    {
//        pessoaJuridica = pessoaJuridica,
//    });
//    }


//public ActionResult VerificaSolicitacaoExistente(int idEvento)
//{

//    bool isValid = false;
//    string msg = string.Empty;
//    string urlRedirect = string.Empty;
//    //var sessionState = new SessionState();

//    try
//    {
//        PessoaJuridica pessoaJuridica = new PessoaJuridica();
//        //Solicitacao soliciacao = new Solicitacao();
//        if (idEvento > 0)
//            //soliciacao = appSolicitacao.DetalheSolicitacao(new Solicitacao { Id = idEvento });

//        if (pessoaJuridica == null || pessoaJuridica.Id == 0)
//        {
//            msg = "Evento não cadastrado.";
//            isValid = false;
//        }

//        else
//        {
//            PessoaJuridicaViewModel pessoaJuridicaViewModel = new PessoaJuridicaViewModel();
//            var listaPessoaJuridica = _pessoaJuridicaRepository.ListaPessoaJuridica(pessoaJuridica.Id);

//            if (listaPessoaJuridica == null)
//            {
//                isValid = false;
//                msg = "Não foi possível encontrar a ultima versão do evento. Entre em contato com o suporte.";
//            }
//            else
//            {
//                isValid = true;
//            }
//        }

//    }
//    catch (Exception e)
//    {
//        msg = e.Message;
//    }

//    return Json(new { existeSolicitacao = isValid, mensagem = msg, url = urlRedirect });
//}


// AUTO PREENCHER CNPJ 
//[HttpPost]
//public JsonResult BuscaCNPJ(String cnpj)
//{
//    try
//    {
//        if (!String.IsNullOrEmpty(cnpj))
//        {
//            var pj = _pessoaJuridicaRepository.DetalhePessoaJuridicaCnpj(new PessoaJuridica { Cnpj = cnpj });
//            if (pj != null)
//            {
//                return Json(pj);
//            }

//        }
//        return Json("SemRegistro");

//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}
// PROCURA CNPJ QUE NAO SEJA IGUAL NO BANCO DE DADOS
//[HttpPost]
//public JsonResult CnpjUnico(String cnpj, int? Id = null)
//{
//    try
//    {
//        var pj = _pessoaJuridicaRepository.DetalhePessoaJuridicaCnpj(new PessoaJuridica { Cnpj = cnpj });
//        if (pj == null || pj.Id == Id)
//        {
//            return Json("valido");
//        }
//        else
//        {
//            return Json("Este CNPJ já existe no nosso banco de dados.");
//        }
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }

//}