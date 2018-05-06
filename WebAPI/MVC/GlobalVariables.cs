using System;
using System.Net.Http;

namespace MVC
{
    public static class GlobalVariables
    {
        public static HttpClient webApiCliente = new HttpClient();

        static GlobalVariables()
        {
            webApiCliente.BaseAddress = new Uri("http://localhost:52514/api/");
            webApiCliente.DefaultRequestHeaders.Clear();
            webApiCliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

    }
}