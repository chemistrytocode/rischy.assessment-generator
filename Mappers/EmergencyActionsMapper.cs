using System.Collections.Generic;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Mappers
{
    public class EmergencyActionsMapper
    {
        public EmergencyActionsMapper() {}

        public IEnumerable<EmergencyAction> Map()
        {
            var listofEmergencyProcedures = new List<EmergencyAction>();

            AddEmergencyAction(listofEmergencyProcedures);

            return listofEmergencyProcedures;
        }

        private static void AddEmergencyAction(ICollection<EmergencyAction> listofEmergencyProcedures)
        {
            // Prototype is hardcoded
            var action = new EmergencyAction
            {
                Emergency = "In the eye",
                Action = "Flood the eye for 10 minutes with water"
            };
            
            listofEmergencyProcedures.Add(action);
        }
    }
}