namespace rischy.assessment_generator.Constants
{
    public static class EmergencyActionConstants
    {
        // Applies to every practical
        public const string InTheEyeEmergency = "In the eye";
        public const string InTheEyeAction = "IRRIGATE";
        public const string InTheEyeActionSubText = "(with water for at least 20 minutes)";
        public const string InTheEyeNotes = "Always irrigate regardless, eye damage may still occur in the absence of obvious symptoms";

        public const string InTheMouthEmergency = "In the mouth";
        public const string InTheMouthAction = "RINSE and SPIT";
        public const string InTheMouthNotes = "Do not swallow or induce vomiting";

        public const string InhaledEmergency = "Inhaled";
        public const string InhaledAction = "MOVE TO FRESH AIR";
        public const string InhaledActionSubText = "(Sit down/support)";
        public const string InhaledNotes = "Evacuate and/or ventilate the area if neccessary";

        public const string OnTheSkinEmergency = "On the skin";
        public const string OnTheSkinAction = "IRRIGATE";
        public const string OnTheSkinActionSubtext = "(with water for at least 20 minutes)";
        public const string OnTheSkinNotes = "In addition wipe/brush off excess and remove contaminated clothing or jewellery";

        public const string EscalationStatement = "If any symptoms from the result of using chemicals appear call severe call 111/999";
    }
}