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
        /// search by name on G1 and return the 10 most recent news
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("busca")]
        public HtmlNode Get()
        {
            var WebRequisition = WebRequest.CreateHttp("https://g1.globo.com/busca/?q=jair+messias+bolsonaro&page=1");
            WebRequisition.Method = "GET";
            WebRequisition.UserAgent = "RequisicaoWebDemo";
            List<string> bora = new List<string>();

            WebResponse requisitionAnswer = WebRequisition.GetResponse();
            Stream streamDados = requisitionAnswer.GetResponseStream();
            StreamReader reader = new StreamReader(streamDados);
            string objResponse = reader.ReadToEnd();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(objResponse);
            HtmlNode quotes = doc.GetElementbyId("content");
            string ListOfPosts = quotes.OuterHtml.Replace(@"\n", "breakalinehere");
            ListOfPosts = ListOfPosts.Replace(@"\", "");
            System.IO.File.WriteAllText(@"C:\Users\Sergio Pena\Desktop\Unip\TCC\SergioPena\CitacoesJornalisticas\CitacoesJornalisticas\CitacoesJornalisticas\FileAccess\result.cshtml", ListOfPosts, Encoding.UTF8);
            int i = 0;

            Regex ListItemPattern = new Regex("(<li (class=\"widget widget--card widget--navigational\") (data-position=\"([0-9])\")>)+");
            List<string> itens = new List<string>();
            itens.AddRange(ListOfPosts.Split(@"href="));

            
            foreach (string link in itens)
            {
                int inicio = 0;
                int final = 0;
                if (link.Contains("g1.globo.com/busca"))
                {
                    inicio = link.IndexOf("g1");
                    final = link.IndexOf("\">");
                    bora.Add(link.Substring(inicio, final));
                }
            }

            while (ListOfPosts.Contains("data-position=\"" + i + "\""))
            {
                bool contains = ListItemPattern.IsMatch(ListOfPosts);
                i++;
                //ListOfPosts.Substring();
            }

            return quotes;
        }
    }
}
