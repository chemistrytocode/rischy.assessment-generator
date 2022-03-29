using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record RiskAssessment
    {
        public IEnumerable<BaseChemical>? HazardTableChemicals { get; set; }
        public IEnumerable<ControlMeasure>? ControlMeasures { get; set; }
        public EmergencyActions? EmergencyActions { get; set; }
    }
}