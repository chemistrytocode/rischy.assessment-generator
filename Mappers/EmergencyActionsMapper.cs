using System.Collections.Generic;
using System.Linq;
using rischy.assessment_generator.Constants;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Mappers
{
    public class EmergencyActionsMapper
    {
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
                    Action = EmergencyActionConstants.InTheMouthNotes
                },
                new EmergencyAction()
                {
                    Emergency = EmergencyActionConstants.InhaledText,
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

        private static IEnumerable<SpecialEmergencyActions>? AddSpecialEmergencyActions(
            IEnumerable<ChemicalHandler> chemicalData)
        {
            var specialEmergencyActions = new List<SpecialEmergencyActions>();
                
            chemicalData.ToList().ForEach(chemical =>
            {
                if (chemical.EmergencyActions != null && chemical.EmergencyActions.Any())
                {
                    specialEmergencyActions.Add(new SpecialEmergencyActions()
                    {
                        Chemical = chemical.Name,
                        SpecialEmergencyAction = MapEmergencyActionsForChemical(chemical)
                    });
                }
            });

            return specialEmergencyActions.Any() ? specialEmergencyActions : null;
        }

        private static IEnumerable<EmergencyAction> MapEmergencyActionsForChemical(ChemicalHandler chemical)
        {
            var chemicalEmergencyActions = new List<EmergencyAction>();
            
            chemical.EmergencyActions?.ToList().ForEach(emergencyAction =>
            {
                chemicalEmergencyActions.Add(new EmergencyAction()
                {
                    Emergency = emergencyAction.Emergency,
                    EmergencySubtext = emergencyAction.EmergencySubtext,
                    Action = emergencyAction.Action
                });
            });

            return chemicalEmergencyActions;
        }
    }
}