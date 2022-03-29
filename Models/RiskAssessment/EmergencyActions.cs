using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record EmergencyActions
    {
        public IEnumerable<EmergencyAction> DefaultEmergencyActions { get; set; }
        
        public IEnumerable<EmergencyAction>? SpecialEmergencyActions { get; set; }
        
        public string EscalationStatement { get; set; }
 
    }
}