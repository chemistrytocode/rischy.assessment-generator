namespace rischy.assessment_generator.Models
{
    public record ControlMeasures
    {
        public bool LowQuantity { get; set; }
        public bool LowConcentration { get; set; }
        public bool Goggles { get; set; }
        public bool Gloves { get; set; }
        public bool WashHands { get; set; }
    }
}