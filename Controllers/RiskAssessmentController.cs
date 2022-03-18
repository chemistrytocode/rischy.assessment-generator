using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.assessment_generator.Services;

namespace rischy.assessment_generator.Controllers
{
    [ApiController]
    [Route("/risk-assessment")]
    public class StockController : Controller
    {
        private readonly RiskAssessmentService _riskAssessmentService;
        
        public StockController(RiskAssessmentService riskAssessmentService) => _riskAssessmentService = riskAssessmentService;
        
        // Prototype
        // Todo: Return a targeted list.
        [HttpGet(Name = "FabricateRiskAssessment")]
        public async Task<IActionResult> GetAllHazards(CancellationToken cancellationToken)
        {
            return await _riskAssessmentService.FabricateRiskAssessment(cancellationToken);
        }
    }
}