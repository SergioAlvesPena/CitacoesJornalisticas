using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitacoesJornalisticas.Helpers
{
    public class RequestHelpers
    {
        public string GloboFormatRequest(string name, string RequestedPage = "1") 
        {
            string method = @"https://g1.globo.com/busca/";

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name is empty");
            }
            else 
            {
                name = @"?q=" + name.Trim().Replace(" ", "+");
            }

            if (!string.IsNullOrWhiteSpace(RequestedPage)) 
            {
                RequestedPage = @"&page=" + RequestedPage;
                return method + name + RequestedPage;
            }
            return method + name;
        }

        public string EstadaoFormatRequest(string name, string RequestedPage = "1")
        {
            string method = @"https://busca.estadao.com.br/";

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name is empty");
            }
            else
            {
                name = @"?q=" + name.Trim().Replace(" ", "+");
            }

            if (!string.IsNullOrWhiteSpace(RequestedPage))
            {
                RequestedPage = @"&page=" + RequestedPage;
                return method + name + RequestedPage;
            }
            return method + name;
        }
    }
}
