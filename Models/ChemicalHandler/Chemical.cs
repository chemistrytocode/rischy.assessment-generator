using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record Chemical
    {
        public string? Name { get; set; }
        
        public string? State { get; set; }
        
        public IEnumerable<string>? Hazard { get; set; }

        public string? Comment { get; set; }

        public ControlMeasures? ControlMeasures { get; set; }
    }
}