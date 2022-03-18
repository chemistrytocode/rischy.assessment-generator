using System.Collections.Generic;
using rischy.assessment_generator.Constants;

namespace rischy.assessment_generator.Mappers
{
    public class ControlMeasuresMapper
    {
        public ControlMeasuresMapper() {}
        
        public IEnumerable<string> Map()
        {
            var listOfControlMeasures = new List<string>();

            AddEmergencyAction(listOfControlMeasures);

            return listOfControlMeasures;
        }

        private static void AddEmergencyAction(ICollection<string> listOfControlMeasures)
        {
            // Prototype is hardcoded
            var goggles = ControlMeasuresConstants.Googles;
            var gloves = ControlMeasuresConstants.Gloves;
            
            listOfControlMeasures.Add(goggles);
            listOfControlMeasures.Add(gloves);
        }
    }
}