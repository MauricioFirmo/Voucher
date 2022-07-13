using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class ADAppService : IADAppService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ADAppService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ADAuthentication> GetADAuthentication(string username, string password)
        {
            string URL = _configuration.GetSection("Urls:AdUrl").Value;
            string domain = _configuration.GetSection("AdDomain:Default").Value;

            ADAppServiceRequest request = new ADAppServiceRequest();

            request.domainName = domain;
            request.userName = username;
            request.password = password;

            _httpClient.Timeout = TimeSpan.FromMinutes(5);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string JsonCustomer = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(JsonCustomer, Encoding.UTF8, "application/json");


            HttpResponseMessage response = await _httpClient.PostAsync(URL, content);
            string result = await response.Content.ReadAsStringAsync();
            ADAuthentication contends = JsonConvert.DeserializeObject<ADAuthentication>(result);

            return contends;
        }

    }
}
