using System.Collections.Generic;
using System.Linq;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Mappers
{
    public class EmergencyActionsMapper
    {
        public EmergencyActionsMapper() { }

        public IEnumerable<EmergencyAction> Map(IEnumerable<ChemicalHandler> chemicalData)
        {
            var emergencyActions = new List<EmergencyAction>();

            AddEmergencyAction(emergencyActions, chemicalData);

            return emergencyActions.Distinct();
        }
        
        // TODO Refactor this in 2nd iteration.
        // Double loops is bad with a capital Big-O
        private static void AddEmergencyAction(ICollection<EmergencyAction> emergencyActions,
            IEnumerable<ChemicalHandler> chemicalData)
        {
            chemicalData.ToList().ForEach(chemical =>
            {
                chemical.EmergencyActions?.ToList().ForEach(action =>
                {
                    emergencyActions.Add(new EmergencyAction
                    {
                        Emergency = action.Emergency,
                        Action = action.Action
                    });
                });
            });
        }
    }
}