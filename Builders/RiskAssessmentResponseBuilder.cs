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


        public RiskAssessmentResponseBuilder(
            HazardTableMapper hazardTableMapper,
            ControlMeasuresMapper controlMeasuresMapper,
            EmergencyActionsMapper emergencyActionsMapper)
        {
            _riskAssessment = new RiskAssessment();
            _hazardTableMapper = hazardTableMapper;
            _controlMeasuresMapper = controlMeasuresMapper;
            _emergencyActionsMapper = emergencyActionsMapper;
        }
        
        // Builder pattern FTW!.
        // TODO: Pass chemicals to dynamically generate payloads, prototype is currently returning hard coded responses.
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

        public RiskAssessmentResponseBuilder WithEmergencyProcedures(IEnumerable<ChemicalHandler> chemicalData)
        {
            var mappedEmergencyResponses = _emergencyActionsMapper.Map(chemicalData);
            _riskAssessment.EmergencyActions = mappedEmergencyResponses;
            return this;
        }
        
        public RiskAssessment Build()
        {
            return _riskAssessment;
        }
    }
}