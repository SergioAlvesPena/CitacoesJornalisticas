using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitacoesJornalisticas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JornalEstadaoController : ControllerBase
    {
        string DNS = "https://g1.globo.com/";
        string busca = "busca";
        string queryKey = "";

        // GET: api/<JornalEstadaoController>
        [HttpGet]
        public ContentResult Get()
        {
            string result = "";
            HttpClient client = new HttpClient();


            return base.Content(result);
        }

        // GET api/<JornalEstadaoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JornalEstadaoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        

        
    }
}
