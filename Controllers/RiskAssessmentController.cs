using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.assessment_generator.Models;
using rischy.assessment_generator.Services;

namespace rischy.assessment_generator.Controllers
{
    [ApiController]
    [Route("/hazard")]
    public class StockController : Controller
    {
        private readonly ChemicalHandlerService _chemicalHandlerService;
        
        public StockController(ChemicalHandlerService chemicalHandlerService) => _chemicalHandlerService = chemicalHandlerService;
        
        // Prototype
        // Need to send a targeted list.
        // Need to return Risk Assessment Payload
        [HttpGet(Name = "GetAllHazards")]
        public async Task<IEnumerable<Chemical>> GetAllHazards(CancellationToken cancellationToken)
        {
            return await _chemicalHandlerService.GetHazardData(cancellationToken);
        }
    }
}