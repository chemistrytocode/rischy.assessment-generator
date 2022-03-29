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
                ChemicalEmergencyActions = AddChemicalEmergencyActions(chemicalData),
                EscalationStatement = EmergencyActionConstants.EscalationStatement
            };
        }

        private static IEnumerable<EmergencyAction> AddDefaultEmergencyActions()
        {
            return new List<EmergencyAction>
            {
                new EmergencyAction()
                {
                    Emergency = EmergencyActionConstants.InTheEyeEmergency,
                    Action = EmergencyActionConstants.InTheEyeAction,
                    ActionSubText = EmergencyActionConstants.InTheEyeActionSubText,
                    ActionNotes = EmergencyActionConstants.InTheEyeNotes
                },
                new EmergencyAction()
                {
                    Emergency = EmergencyActionConstants.InTheMouthEmergency,
                    Action = EmergencyActionConstants.InTheMouthAction,
                    ActionNotes = EmergencyActionConstants.InTheMouthNotes
                },
                new EmergencyAction()
                {
                    Emergency = EmergencyActionConstants.InhaledEmergency,
                    Action = EmergencyActionConstants.InhaledAction,
                    ActionSubText = EmergencyActionConstants.InhaledActionSubText,
                    ActionNotes = EmergencyActionConstants.InhaledNotes
                },
                new EmergencyAction()
                {
                    Emergency = EmergencyActionConstants.OnTheSkinEmergency,
                    Action = EmergencyActionConstants.OnTheSkinAction,
                    ActionSubText = EmergencyActionConstants.OnTheSkinActionSubtext,
                    ActionNotes = EmergencyActionConstants.OnTheSkinNotes
                }
            };
        }

        private static IEnumerable<ChemicalEmergencyAction>? AddChemicalEmergencyActions(
            IEnumerable<ChemicalHandler> chemicalData)
        {
            var specialEmergencyActions = new List<ChemicalEmergencyAction>();
                
            chemicalData.ToList().ForEach(chemical =>
            {
                if (chemical.EmergencyActions != null && chemical.EmergencyActions.Any())
                {
                    specialEmergencyActions.Add(new ChemicalEmergencyAction()
                    {
                        Chemical = chemical.Name,
                        ChemicalEmergencyActions = MapEmergencyActionsForChemical(chemical)
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
                    Action = emergencyAction.Action,
                    ActionSubText = emergencyAction.ActionSubText,
                    ActionNotes = emergencyAction.ActionNotes
                });
            });

            return chemicalEmergencyActions;
        }
    }
}