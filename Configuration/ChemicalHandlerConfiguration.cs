namespace rischy.assessment_generator.Configuration
{
    public record ChemicalHandlerConfiguration
    {
        public static string Uri { get; set; } = "https://localhost:3002"; 
        public static string HazardsEndpoint { get; set; } = "/hazards";
        public string ServiceName { get; } = "rischy.chemical-handler";
    }
}