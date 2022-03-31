using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record ControlMeasure
    {
        public string Control { get; set; }
        public IEnumerable<string> Chemicals { get; set; }
    }
}