using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rischy.assessment_generator.Configuration;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Services
{
    public class ChemicalHandlerService
    {
        private readonly HttpClient _chemicalHandlerClient;
        
        public ChemicalHandlerService(HttpClient chemicalHandlerClient)
        {
            _chemicalHandlerClient = chemicalHandlerClient;
        }

        private async Task<HttpResponseMessage> CallChemicalHandler(string uri, string encryptedChemicalIds, CancellationToken cancellationToken)
        {
            var endpoint = $"{ChemicalHandlerConfiguration.Uri}{uri}?ids={encryptedChemicalIds}";
            
            var response = await _chemicalHandlerClient.GetAsync(endpoint, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            
            throw new Exception($"Request returned a bad response: {response.StatusCode}");
        }
        
        public async Task<IEnumerable<ChemicalHandler>> GetHazardData(string encryptedChemicalIds, CancellationToken cancellationToken)
        {
            var response = await CallChemicalHandler(ChemicalHandlerConfiguration.HazardsEndpoint, encryptedChemicalIds, cancellationToken);
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