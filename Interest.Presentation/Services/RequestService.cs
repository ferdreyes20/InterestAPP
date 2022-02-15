using Interest.Presentation.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Presentation.Services
{
    public class RequestService : IRequestService
    {
        private readonly IConfiguration _configuration;
        private string interestUri;

        public RequestService(IConfiguration configuration)
        {
            _configuration = configuration;
            interestUri =  _configuration.GetValue<string>("InterestUri");
        }

        public async Task<int> AddRequest(decimal value)
        {
            try
            {
                var json = JsonConvert.SerializeObject(new { Value = value });
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse;
                using (var httpClient = new HttpClient())
                {
                    httpResponse = await httpClient.PostAsync(interestUri + "request/CreateRequest", data);
                }
                var requestId = Convert.ToInt32(await httpResponse.Content.ReadAsStringAsync());
                return requestId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteRequest(int id)
        {
            try
            {
                HttpResponseMessage httpResponse;
                using (var httpClient = new HttpClient())
                {
                    httpResponse = await httpClient.DeleteAsync(interestUri + "request/RemoveRequest?id=" + id);
                }
                var response = await httpResponse.Content.ReadAsStringAsync();
                var requestId = JsonConvert.DeserializeObject<int>(response);
                return requestId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestViewModel> GetRequest(int id)
        {
            try
            {
                HttpResponseMessage httpResponse;
                using (var httpClient = new HttpClient())
                {
                    httpResponse = await httpClient.GetAsync(interestUri + "request/GetRequest?id=" + id);
                }
                var response = await httpResponse.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<RequestViewModel>(response);
                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ComputationViewModel>> GetRequestComputaions(decimal value)
        {
            try
            {
                HttpResponseMessage httpResponse;
                using (var httpClient = new HttpClient())
                {
                    httpResponse = await httpClient.GetAsync(interestUri + "request/GetRequestComputations?value=" + value);
                }
                var response = await httpResponse.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<IEnumerable<ComputationViewModel>>(response);
                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RequestViewModel>> GetRequestList()
        {
            try
            {
                HttpResponseMessage httpResponse;
                using (var httpClient = new HttpClient())
                {
                    httpResponse = await httpClient.GetAsync(interestUri + "request/GetRequestList");
                }

                var response = await httpResponse.Content.ReadAsStringAsync();
                var requests = JsonConvert.DeserializeObject<List<RequestViewModel>>(response);

                return requests;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateRequest(RequestViewModel request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse;
                using (var httpClient = new HttpClient())
                {
                    httpResponse = await httpClient.PutAsync(interestUri + "request/UpdateRequest", data);
                }

                var response = await httpResponse.Content.ReadAsStringAsync();
                var requestId = Convert.ToInt32(response);

                return requestId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
