using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record Disposal
    {
        public IEnumerable<string> Codes { get; set; }
        
        public string Instructions { get; set; }
    }
}