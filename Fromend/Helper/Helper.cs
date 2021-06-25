using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fromend.Helper
{
    public class Helper
    {
        public class PersonaAPI
        {
            public HttpClient initial()
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44370/");
                return client;
            }
        }
    }
}
