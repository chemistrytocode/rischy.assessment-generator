namespace rischy.assessment_generator.Configuration
{
    public record ChemicalHandlerConfiguration
    {
        public string Uri { get; set; } = "https://localhost:3002";

        public string HazardEndpoint { get; set; } = "/hazard";
        
        public string ServiceName { get; } = "rischy.chemical-handler";
    }
}