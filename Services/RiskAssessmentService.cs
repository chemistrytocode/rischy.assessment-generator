using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.assessment_generator.Builders;

namespace rischy.assessment_generator.Services
{
    public class RiskAssessmentService
    {
        private readonly ChemicalHandlerService _chemicalHandlerService;
        private readonly RiskAssessmentResponseBuilder _riskAssessmentResponseBuilder;

        public RiskAssessmentService(
            ChemicalHandlerService chemicalHandlerService,
            RiskAssessmentResponseBuilder riskAssessmentResponseBuilder)
        {
            _chemicalHandlerService = chemicalHandlerService;
            _riskAssessmentResponseBuilder = riskAssessmentResponseBuilder;
        }

        public async Task<IActionResult> FabricateRiskAssessment(CancellationToken cancellationToken)
        {
            // TODO: Currently getting ALL data, targeting chemicals goal of 2nd iteration
            var hazardData = await _chemicalHandlerService.GetHazardData(cancellationToken);

            var riskAssessmentResponse = _riskAssessmentResponseBuilder
                .WithChemicalHazardTable(hazardData)
                .WithControlMeasures(hazardData)
                .WithEmergencyProcedures(hazardData)
                .Build();

            return new JsonResult(riskAssessmentResponse) {StatusCode = (int) HttpStatusCode.OK};
        }
    }
}