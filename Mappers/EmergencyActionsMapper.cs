using System.Collections.Generic;
using System.Linq;
using rischy.assessment_generator.Constants;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Mappers
{
    public class EmergencyActionsMapper
    {
        public EmergencyActionsMapper() { }

        public EmergencyActions Map(IEnumerable<ChemicalHandler> chemicalData)
        {
            return new EmergencyActions()
            {
                DefaultEmergencyActions = AddDefaultEmergencyActions(),
                SpecialEmergencyActions = AddSpecialEmergencyActions(chemicalData),
                EscalationStatement = EmergencyActionConstants.EscalationStatement
            };
        }

        private static IEnumerable<EmergencyAction> AddDefaultEmergencyActions()
        {
            return new List<EmergencyAction>
            {
                new EmergencyAction()
                {
                    Emergency = EmergencyActionConstants.InTheEyeText,
                    EmergencySubtext = EmergencyActionConstants.InTheEyeSubtext,
                    Action = EmergencyActionConstants.InhaledNotes
                },
                new EmergencyAction()
                {
                    Emergency = EmergencyActionConstants.InTheMouthText,
                    EmergencySubtext = null,
                    Action = EmergencyActionConstants.InTheMouthNotes
                },
                new EmergencyAction()
                {
                    Emergency = EmergencyActionConstants.InhaledText,
                    EmergencySubtext = null,
                    Action = EmergencyActionConstants.InhaledNotes
                },
                new EmergencyAction()
                {
                    Emergency = EmergencyActionConstants.OnTheSkinText,
                    EmergencySubtext = EmergencyActionConstants.OnTheSkinSubtext,
                    Action = EmergencyActionConstants.OnTheSkinText
                }
            };
        }

        private static IEnumerable<EmergencyAction> AddSpecialEmergencyActions(
            IEnumerable<ChemicalHandler> chemicalData)
        {
            var specialEmergencyActions = new List<EmergencyAction>();
                
            chemicalData.ToList().ForEach(chemical =>
            {
                chemical.EmergencyActions?.ToList().ForEach(action =>
                {
                    specialEmergencyActions.Add(new EmergencyAction()
                    {
                        Chemical = chemical.Name,
                        Emergency = action.Emergency,
                        EmergencySubtext = action.EmergencySubtext,
                        Action = action.Action
                    });
                });
            });
            
            return specialEmergencyActions;
        }
    }
}