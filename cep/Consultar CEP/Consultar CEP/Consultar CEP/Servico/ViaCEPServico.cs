using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Consultar_CEP.Servico.Modelo;
namespace Consultar_CEP.Servico
{
   public class ViaCEPServico
{
        //define qual endereço pesquisar
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

       
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            //parametro onde vai ser injetado
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();

            // aqui ele baixa a url do site
            string  conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.cep == null) return null;

            return end;

        }
}
}
