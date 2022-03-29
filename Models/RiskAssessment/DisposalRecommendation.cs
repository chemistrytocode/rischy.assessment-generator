using System.Collections.Generic;

namespace rischy.assessment_generator.Models
{
    public record DisposalRecommendation
    {
        public string Key { get; set; }
        public string? Instructions { get; set; }
        public IEnumerable<string> Chemicals { get; set; }
    }
}