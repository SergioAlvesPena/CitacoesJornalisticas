using System;
using System.Collections.Generic;

namespace CitacoesJornalisticas.Controllers
{
    public static class StringHelper
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }

        public static string DeleteUntil(this string text, string stopAt = "\"")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Remove(charLocation);
                }
            }

            return String.Empty;
        }
    }

    public class GloboHelper
    {
        public List<string> GetLinks(string itens)
        {
            List<string> result = new List<string>();
            List<string> ListOfItens = new List<string>();

            itens = itens.Replace(@"\n", "breakalinehere");
            itens = itens.Replace(@"\", "");
            ListOfItens.AddRange(itens.Split(@"href="));

            foreach (string link in ListOfItens)
            {
                int inicio = 0;
                int final = 0;
                string url = "";
                if (link.Contains("g1.globo.com/busca"))
                {
                    inicio = link.IndexOf("g1");
                    final = link.IndexOf("\">");
                    url = link.Substring(inicio, final).DeleteUntil();

                    if (!result.Contains(url)) result.Add(url);
                }
            }
            return result;
        }
    }
}
