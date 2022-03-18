using System.Collections.Generic;
using Newtonsoft.Json;

namespace rischy.assessment_generator.Models
{
    public record BaseChemical
    {
        public string? Name { get; set; }
        public string? State { get; set; }
        public string? Concentration { get; set; }
        public IEnumerable<string>? Hazard { get; set; }
        public string? Comment { get; set; }
    }
}