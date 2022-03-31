using System.Collections.Generic;
using System.Linq;
using rischy.assessment_generator.Constants;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Mappers
{
    public class ControlMeasuresMapper
    {
        public IEnumerable<ControlMeasure> Map(IEnumerable<ChemicalHandler> chemicalData)
        {
            var controlMeasures = new List<ControlMeasure>()
            {
                MapChemicalsThatRequireGoggles(chemicalData),
                MapChemicalsThatRequireGloves(chemicalData),
                MapChemicalsThatRequireFumeCupboard(chemicalData),
            };

            return controlMeasures.Where(controlMeasure => controlMeasure != null);
        }

        private static ControlMeasure? MapChemicalsThatRequireGoggles(IEnumerable<ChemicalHandler> chemicalData)
        {
            var chemicalsThatRequireGoogles = chemicalData.Where(chemical => chemical.ControlMeasures.Goggles);

            return MapControlMeasure(ControlMeasuresConstants.Goggles, chemicalsThatRequireGoogles);
        }

        private static ControlMeasure? MapChemicalsThatRequireGloves(IEnumerable<ChemicalHandler> chemicalData)
        {
            var chemicalsThatRequireGoogles = chemicalData.Where(chemical => chemical.ControlMeasures.Gloves);

            return MapControlMeasure(ControlMeasuresConstants.Gloves, chemicalsThatRequireGoogles);
        }

        private static ControlMeasure? MapChemicalsThatRequireFumeCupboard(IEnumerable<ChemicalHandler> chemicalData)
        {
            var chemicalsThatRequireGoogles = chemicalData.Where(chemical => chemical.ControlMeasures.FumeCupboard);

            return MapControlMeasure(ControlMeasuresConstants.FumeCupboard, chemicalsThatRequireGoogles);
        }

        private static ControlMeasure? MapControlMeasure(string controlMeasure, IEnumerable<ChemicalHandler> matchingChemicals)
        {
            return matchingChemicals.Any()
                ? new ControlMeasure()
                {
                    Control = controlMeasure,
                    Chemicals = matchingChemicals.Select(chemical => chemical.Name)
                }
                : null;
        }
    }
}