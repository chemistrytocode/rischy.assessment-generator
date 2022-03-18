namespace rischy.assessment_generator.Models
{
    public record ControlMeasures
    {
        public bool Goggles { get; set; } = true;
        public bool LowQuantity { get; set; } = true;
        public bool LowConcentration { get; set; } = true;
        public bool WashHands { get; set; } = true;
    }
}