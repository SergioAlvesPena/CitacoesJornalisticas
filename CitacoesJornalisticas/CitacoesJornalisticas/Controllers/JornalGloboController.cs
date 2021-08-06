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
using CitacoesJornalisticas.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitacoesJornalisticas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JornalGloboController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public JornalGloboController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("GetNews")]
        public async Task<string> GetNews(string name)
        {
            RequestHelpers _requestHelpers = new RequestHelpers();
            GloboHelper gh = new GloboHelper();

            var response = await _httpClient.GetAsync(_requestHelpers.GloboFormatRequest(name));
            List<string> links = new List<string>();
            links.AddRange(gh.GetLinks(response.Content.ReadAsStringAsync().Result));
            string json = JsonConvert.SerializeObject(links, Formatting.Indented);
            System.IO.File.WriteAllText(@"C:\Users\Sergio Pena\Desktop\Unip\TCC\SergioPena\CitacoesJornalisticas\CitacoesJornalisticas\CitacoesJornalisticas\FileAccess\GloboResults.json", json, Encoding.UTF8);
            return json;

        }
    }
}
