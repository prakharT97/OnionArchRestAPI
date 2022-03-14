using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace APITestWebApp.Helper
{
    public class UserAPI
    {
        public HttpClient Initial() {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64107");
            return client;
        }
    }
}
