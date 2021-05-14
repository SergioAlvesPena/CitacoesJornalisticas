using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;
using CitacoesJornalisticas.Controllers;
using Newtonsoft.Json;

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

        /// <summary>
        ///     search by name on G1 and return the 10 most recent news
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("busca")]
        public string Get()
        {
            //requisition step insn't perfect
            var WebRequisition = WebRequest.CreateHttp("https://g1.globo.com/busca/?q=fernando+haddad&page=1");
            WebRequisition.Method = "GET";
            WebRequisition.UserAgent = "RequisicaoWebDemo";

            //encapsulate the response of request
            WebResponse requisitionAnswer = WebRequisition.GetResponse();
            Stream streamDados = requisitionAnswer.GetResponseStream();
            StreamReader reader = new StreamReader(streamDados);
            string objResponse = reader.ReadToEnd();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(objResponse);
            HtmlNode quotes = doc.GetElementbyId("content");

            //get the links
            List<string> links = new List<string>();
            GloboHelper gh = new GloboHelper();
            links.AddRange(gh.GetLinks(quotes.OuterHtml));
            string json = JsonConvert.SerializeObject(links, Formatting.Indented);
            System.IO.File.WriteAllText(@"C:\Users\Sergio Pena\Desktop\Unip\TCC\SergioPena\CitacoesJornalisticas\CitacoesJornalisticas\CitacoesJornalisticas\FileAccess\JsonLinks.json", json, Encoding.UTF8);
            return json;
        }
    }
}
