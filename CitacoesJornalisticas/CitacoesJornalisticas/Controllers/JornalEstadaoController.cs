using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CitacoesJornalisticas.Helpers;
using Newtonsoft.Json;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitacoesJornalisticas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JornalEstadaoController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public JornalEstadaoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("GetNews")]
        public async Task<string> GetNews(string name) 
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "_gcl_au=1.1.1232287710.1620509418; OESP_GA_GID=4dd275b8-7716-44b7-80bd-a084da9cd6e4; _hjid=73c920af-71b6-4724-b52c-f2fc2b6ad471; _fbp=fb.2.1620509435606.266621905; _gaexp=GAX1.3.m99yXQRNSGuC5WLLRr5trA.18875.x520; __pw_vs=1; _ga=GA1.3.969922713.1628255010; _gid=GA1.3.530413549.1628255010; pwtab29=B; _gat_UA-166963-24=1; _hjAbsoluteSessionInProgress=0; nvg23902=b7dbd947f6a73a6488a28e42d09|0_219; ___iat_vis=3357ABCEEA8931EC.3509236843.1628255011881.361984753.ZOJBRIJUAA; BIGipServerpool_render_estadao-2014_SSL=2393291208.47873.0000; __pw_rt=pv'1593001651~qts'5~pn'6~st'526~ja'202; _gada_id.730d=0a7e084b-97df-4dd6-8e14-2ab1fb08f14f.1628255273.1.1628255273.1628255273.f71e8b51-127b-4e19-8cb4-058781ba144f; _gada_ses.730d=*; _cb_ls=1; privAu=0; _cb=CgOd4fxM7cezij1i; _chartbeat2=.1620509453892.1628255273516.0000000000000001.DlZh8rBLGcQ_CoUZ9Wn3aj2f7IKi.1; _cb_svref=https%3A%2F%2Fwww.estadao.com.br%2F; CUID=N,1628255273792:ALHGLuQAAAAPTiwxNjI4MjU1MjczNzkyCe8rbIQBBxSZHkJsVzfXHd26MB9eOb+rx9PGtjkYRNzpgn6Qdy2UPlAi3RpxuLRqE8sbfvp+BjpM0UTKn5bCu6cFyBvcxXiinZum8QIzBxzh+RZBxpX75bDfxBwyZk2D4J6cKlKqWdKmMYsjyPwJLcyFvkZ6qtnQYpDquOMsUhK4vFdrOElAj6ltEHxdXggSlVRqEJuTavwfB8NtPgyzX4nxiTgq+qzwFX9q2KYdltpBf72FT1G7PMrdAZn1LmoyQFDJM6f/XzLRyaD7TYFhYVlspBv7P5UQ2F9AVGs+biHaAqovfh5xXETaY3nojIjg1o3VE4sKhs73qo17fGEyiQ==; ___iat_ses=3357ABCEEA8931EC.2; ___iat_vis=3357ABCEEA8931EC.3509236843.1628255274521.361984753.ZOJBRIJUAA; _hjCachedUserAttributes=eyJhdHRyaWJ1dGVzIjp7InR5cGVfdXNlciI6InVuZGVmaW5lZCJ9LCJ1c2VySWQiOm51bGx9; FCNEC=[[\"AKsRol - iD0lUJrNZu - U8kASYEGcRyitBua5SdLESEumD_Nw5CbIbYw_ - PyQ1Q1GMKtqpNcuvaeMxljiauGI0qFFB5sJTMD5p6ZTKV_p8Rf5iUeq_FsqhcFT_bJ6iZnPBnq1cECJMthbU2MNnOaFjLr - liYPI5iK9Uw == \"],null]; FCCDCF=[[\"AKsRol - iD0lUJrNZu - U8kASYEGcRyitBua5SdLESEumD_Nw5CbIbYw_ - PyQ1Q1GMKtqpNcuvaeMxljiauGI0qFFB5sJTMD5p6ZTKV_p8Rf5iUeq_FsqhcFT_bJ6iZnPBnq1cECJMthbU2MNnOaFjLr - liYPI5iK9Uw == \"],null,[\"[[],[],[],[], null, null, true]\",1628255275669]]; OESP_LGPD_ACEITE=VERDADEIRO; __gads=ID=cb316cd71dad51e1:T=1628255276:S=ALNI_MbHBx3CR3CFoBJhsOPTV0m9mUzG3g; XSRF-TOKEN=eyJpdiI6InVqZGZ1emZ1SDFPTnpQaGJKK0hoMlE9PSIsInZhbHVlIjoiNFd5TGhtVGlDOWo3RFllMXg0aWRPVUJoQU5SQ1VOME90dVhpMVRpZENIQ0M1NzJCb2Izem9KMkF1MGJkanBtUjc0cldkbVFTVTFKMGtYRWR5QlFlVXc9PSIsIm1hYyI6IjNmMjA2Mjc5NDRlY2YyN2VjMTU5Y2YyMTM1ZTM1OWQ0MmM1ZTQ5MTA2MGFmZGRmYWJmZmQ0ZTU3NjQyYzk1MmUifQ%3D%3D; laravel_session=eyJpdiI6IjFqaHNjdkVHSWJJWThWdGRwejJNMWc9PSIsInZhbHVlIjoiZlk3NGkyVjdUdVRjXC9GZVg3NUxHV2tOdEV5aUJ3TmhGMXN4ekVBVlRnZEI4TjFmYkFoWkZDdWtaS3VQSUgxdDRrT2JCZmpuazQzR2k4d1B6WEE1MndnPT0iLCJtYWMiOiI1MTZlMWU0MTVjOTEwNmIyZTc1ZmEwYjdiZGZhMTFjY2YwNzNlOGIzYjliNjFhNDQyZWI4OTE2YzIxMzg1N2FhIn0%3D");
            RequestHelpers _requestHelpers = new RequestHelpers();
            var response = await _httpClient.GetAsync(_requestHelpers.EstadaoFormatRequest(name));
            return JsonConvert.SerializeObject(response.Content.ReadAsStringAsync()); 
        }
    }
}
