using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record ChemicalEmergencyAction
    {
        public string Chemical { get; set; }        
        public IEnumerable<EmergencyAction> ChemicalEmergencyActions { get; set; }
    }
}