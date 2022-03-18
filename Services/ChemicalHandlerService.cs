using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using rischy.assessment_generator.Configuration;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Services
{
    public class ChemicalHandlerService
    {
        private readonly HttpClient _chemicalHandlerClient;
        private readonly ChemicalHandlerConfiguration _chemicalHandlerConfiguration;
        
        public ChemicalHandlerService(HttpClient chemicalHandlerClient)
        {
            _chemicalHandlerClient = chemicalHandlerClient;
            _chemicalHandlerConfiguration = new ChemicalHandlerConfiguration();
        }

        private async Task<HttpResponseMessage> CallChemicalHandler(string uri, CancellationToken cancellationToken)
        {
            var endpoint = $"{_chemicalHandlerConfiguration.Uri}{uri}";
            
            var response = await _chemicalHandlerClient
                .GetAsync(endpoint, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            
            throw new Exception($"Request returned a bad response: {response.StatusCode}");
        }
        

        public async Task<IEnumerable<ChemicalHandler>> GetHazardData(CancellationToken cancellationToken)
        {
            var response = await CallChemicalHandler(_chemicalHandlerConfiguration.HazardEndpoint, cancellationToken);
            var data = await response.Content.ReadAsStringAsync(cancellationToken);
            var hazardData = JsonConvert.DeserializeObject<IEnumerable<ChemicalHandler>>(data);

            if (hazardData == null || !hazardData.Any())
            {
                throw new Exception("No stock data was found!");
            }

            return hazardData;
        }
    }
}