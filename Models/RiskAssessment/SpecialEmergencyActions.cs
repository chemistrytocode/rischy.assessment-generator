using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record SpecialEmergencyActions
    {
        public string Chemical { get; set; }        
        public IEnumerable<EmergencyAction> SpecialEmergencyAction { get; set; }
    }
}