using System.Collections.Generic;
using System.Linq;
using rischy.assessment_generator.Constants;
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