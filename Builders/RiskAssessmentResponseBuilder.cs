using System.Collections.Generic;
using rischy.assessment_generator.Mappers;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Builders
{
    public class RiskAssessmentResponseBuilder
    {
        private readonly RiskAssessment _riskAssessment;
        private readonly HazardTableMapper _hazardTableMapper;
        private readonly ControlMeasuresMapper _controlMeasuresMapper;
        private readonly EmergencyActionsMapper _emergencyActionsMapper;
        private readonly DisposalRecommendationsMapper _disposalRecommendationsMapper;

        public RiskAssessmentResponseBuilder(
            HazardTableMapper hazardTableMapper,
            ControlMeasuresMapper controlMeasuresMapper,
            EmergencyActionsMapper emergencyActionsMapper,
            DisposalRecommendationsMapper disposalRecommendationsMapper)
        {
            _riskAssessment = new RiskAssessment();
            _hazardTableMapper = hazardTableMapper;
            _controlMeasuresMapper = controlMeasuresMapper;
            _emergencyActionsMapper = emergencyActionsMapper;
            _disposalRecommendationsMapper = disposalRecommendationsMapper;
        }
        
        public RiskAssessmentResponseBuilder WithChemicalHazardTable(IEnumerable<ChemicalHandler> chemicalData)
        {
            var mappedChemicalHazardTable = _hazardTableMapper.Map(chemicalData);
            _riskAssessment.HazardTableChemicals = mappedChemicalHazardTable;
            return this;
        }
        
        public RiskAssessmentResponseBuilder WithControlMeasures(IEnumerable<ChemicalHandler> chemicalData)
        {
            var mappedControlMeasures = _controlMeasuresMapper.Map(chemicalData);
            _riskAssessment.ControlMeasures = mappedControlMeasures;
            return this;
        }

        public RiskAssessmentResponseBuilder WithEmergencyActions(IEnumerable<ChemicalHandler> chemicalData)
        {
            var mappedEmergencyResponses = _emergencyActionsMapper.Map(chemicalData);
            _riskAssessment.EmergencyActions = mappedEmergencyResponses;
            return this;
        }
        
        public RiskAssessmentResponseBuilder WithDisposalRecommendations(IEnumerable<ChemicalHandler> chemicalData)
        {
            var mappedDisposalRecommendations = _disposalRecommendationsMapper.Map(chemicalData);
            _riskAssessment.DisposalRecommendations = mappedDisposalRecommendations;
            return this;
        }

        public RiskAssessment Build()
        {
            return _riskAssessment;
        }
    }
}