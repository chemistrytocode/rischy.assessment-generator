using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record ChemicalHandler : BaseChemical
    {
        public ControlMeasures ControlMeasures { get; set; }
        public IEnumerable<EmergencyAction>? EmergencyActions { get; set; }
        public Disposal Disposal { get; set; }

    }
}