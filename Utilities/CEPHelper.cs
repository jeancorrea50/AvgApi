//using BackOffice.Infrastructure.CrossCutting.Utilities.Entities;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;

//namespace BackOffice.Infrastructure.CrossCutting.Utilities
//{
//    public static class CEPHelper
//    {
//        public static CEPExterno ObterPorCep(string cep)
//        {
//            CEPExterno retorno = new CEPExterno();

//            try
//            {
//                HttpClient _client = new HttpClient();
//                _client.BaseAddress = new Uri("https://viacep.com.br/");
//                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

//                string queryString = string.Empty;

//                queryString = "ws/" + cep + "/json/";

//                var response = _client.GetAsync(queryString).Result;

//                if (response.IsSuccessStatusCode)
//                {
//                    retorno = JsonConvert.DeserializeObject<CEPExterno>(response.Content.ReadAsStringAsync().Result);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//            return retorno;
//        }
//    }
//}
