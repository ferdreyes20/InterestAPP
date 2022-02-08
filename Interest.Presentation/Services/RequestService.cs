using Interest.Presentation.Models;
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
        public async Task<int> AddRequest(decimal value)
        {
            try
            {
                var json = JsonConvert.SerializeObject(new { Value = value });
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse;
                using (var httpClient = new HttpClient())
                {
                    httpResponse = await httpClient.PostAsync("http://localhost:5000/request", data);
                }
                var requestId = Convert.ToInt32(await httpResponse.Content.ReadAsStringAsync());
                return requestId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RequestViewModel>> GetRequests()
        {
            try
            {
                HttpResponseMessage httpResponse;
                using (var httpClient = new HttpClient())
                {
                    httpResponse = await httpClient.GetAsync("http://localhost:5000/request");
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
    }
}
