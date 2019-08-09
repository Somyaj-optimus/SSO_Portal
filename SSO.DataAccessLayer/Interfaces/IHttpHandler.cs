﻿using System.Net.Http;
using System.Threading.Tasks;

namespace SSO.DataAccessLayer.Interfaces
{
    public interface IHttpHandler
    {
        HttpResponseMessage GetAsync(string url);
        HttpResponseMessage PostAsync(string url, HttpContent content);
        void AddHeader(string key, string value);
    }
}
