using Newtonsoft.Json;
using OeisCli.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OeisCli.Services
{
    public class OeisService
    {
        private readonly HttpClient _httpClient;

        public OeisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OeisGetSequencesResponse> FetchOeisDb(List<int> sequence)
        {
            var uri = new Uri("https://oeis.org/search?fmt=json&q=" + string.Join("+", sequence));
            var response = await _httpClient.GetAsync(uri);

            return await ValidateAndReturnResponse(response);
        }

        private async Task<OeisGetSequencesResponse> ValidateAndReturnResponse(HttpResponseMessage httpResponse)
        {
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new NetworkErrorException("Oeis DB is unavailable, please try again");
            }

            try
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                var responseBody = JsonConvert.DeserializeObject<OeisGetSequencesResponse>(content);
                return responseBody;
            } 
            catch (Exception e)
            {
                throw new NetworkErrorException("Oeis DB is unavailable, please try again", e);
            }
        }
    }
}
