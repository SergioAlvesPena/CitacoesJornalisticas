using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitacoesJornalisticas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JornalEstadaoController : ControllerBase
    {
        // GET: api/<JornalEstadaoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
