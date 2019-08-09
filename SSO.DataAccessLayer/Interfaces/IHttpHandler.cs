using System.Net.Http;
using System.Threading.Tasks;

namespace SSO.DataAccessLayer.Interfaces
{
    public interface IHttpHandler
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
        void AddHeader(string key, string value);
    }
}
