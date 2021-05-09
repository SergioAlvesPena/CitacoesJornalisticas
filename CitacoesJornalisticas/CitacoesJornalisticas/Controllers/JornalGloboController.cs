using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitacoesJornalisticas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JornalGloboController : ControllerBase
    {
        string DNS = "https://g1.globo.com/";
        string busca = "busca/";
        string queryKey = "?q={nome}";

        // GET api/<JornalGloboController>/5
        [HttpGet]
        [Route("busca")]
        public HtmlNode Get()
        {
            var requisicaoWeb = WebRequest.CreateHttp("https://g1.globo.com/busca/?q=jair+messias+bolsonaro&page=1");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            var a =  requisicaoWeb.GetResponse();
            var streamDados = a.GetResponseStream();
            StreamReader reader = new StreamReader(streamDados);
            string objResponse = reader.ReadToEnd();
            var doc = new HtmlDocument();
            doc.LoadHtml(objResponse);
            HtmlNode citacoes = doc.GetElementbyId("content");
            return citacoes;
        }
    }
}
