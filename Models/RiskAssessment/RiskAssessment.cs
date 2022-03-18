using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record RiskAssessment
    {
        public IEnumerable<HazardTableChemical> HazardTableChemicals { get; set; }
        
        public IEnumerable<string> ControlMeasures { get; set; }
        
        public IEnumerable<EmergencyAction> EmergencyActions { get; set; }
    }
}