using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record HazardTableChemical
    {
        public string Name { get; set; }
        public string? State { get; set; }
        public string? Concentration { get; set; }
        public List<string> Hazard { get; set; }
        public string Comment { get; set; }
    }
}