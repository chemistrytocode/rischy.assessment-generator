using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.assessment_generator.Services;

namespace rischy.assessment_generator.Controllers
{
    [ApiController]
    [Route("/risk-assessment")]
    public class RiskAssessmentController : Controller
    {
        private readonly RiskAssessmentService _riskAssessmentService;
        
        public RiskAssessmentController(RiskAssessmentService riskAssessmentService) => _riskAssessmentService = riskAssessmentService;
        
        [HttpGet(Name = "FabricateRiskAssessment")]
        public async Task<IActionResult> FabricateRiskAssessment(string chemicalIds, CancellationToken cancellationToken)
        {
            return await _riskAssessmentService.FabricateRiskAssessment(chemicalIds, cancellationToken);
        }
    }
}