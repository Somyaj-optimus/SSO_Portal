using SSO.DataAccessLayer.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace SSO.DataAccessLayer.Implementations
{
    public class HttpClientHandler : IHttpHandler
    {
        private readonly HttpClient _client = new HttpClient();

        public HttpResponseMessage GetAsync(string url)
        {
            return  _client.GetAsync(url).Result;
        }

        public HttpResponseMessage PostAsync(string url, HttpContent content)
        {
            return  _client.PostAsync(url, content).Result;
        }

        public void AddHeader(string key, string value)
        {
            _client.DefaultRequestHeaders.Add(key, value);
        }
    }
}
