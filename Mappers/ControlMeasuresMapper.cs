using System.Collections.Generic;
using System.Linq;
using rischy.assessment_generator.Constants;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Mappers
{
    public class ControlMeasuresMapper
    {
        public ControlMeasuresMapper() {}
        
        public IEnumerable<string> Map(IEnumerable<ChemicalHandler> chemicalData)
        {
            var listOfControlMeasures = new List<string>();

            AddControlMeasure(listOfControlMeasures, chemicalData);
            
            return listOfControlMeasures.Distinct();
        }
        
        // 1st Iteration
        // TODO Add chemical names to Control Measures string in next iteration
        private static void AddControlMeasure(ICollection<string> listOfControlMeasures, IEnumerable<ChemicalHandler> chemicalData)
        {
            chemicalData.ToList().ForEach(chemical =>
            {
                if (chemical.ControlMeasures.LowQuantity) listOfControlMeasures.Add(ControlMeasuresConstants.LowQuanity);
                if (chemical.ControlMeasures.LowConcentration) listOfControlMeasures.Add(ControlMeasuresConstants.LowConcentration);
                if (chemical.ControlMeasures.Goggles) listOfControlMeasures.Add(ControlMeasuresConstants.Googles);
                if (chemical.ControlMeasures.Gloves) listOfControlMeasures.Add(ControlMeasuresConstants.Googles);
                if (chemical.ControlMeasures.WashHands) listOfControlMeasures.Add(ControlMeasuresConstants.WashHands);
            });
        }
    }
}