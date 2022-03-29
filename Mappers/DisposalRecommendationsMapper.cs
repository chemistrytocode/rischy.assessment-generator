using System.Collections.Generic;
using System.Linq;
using rischy.assessment_generator.Constants;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Mappers
{
    public class DisposalRecommendationsMapper
    {
        public IEnumerable<DisposalRecommendation> Map(IEnumerable<ChemicalHandler> chemicalData)
        {
            var disposalMeasures = new List<DisposalRecommendation>()
            {
                MapChemicalsToDisposalMethod(DisposalCodeConstants.W1Key, DisposalCodeConstants.W1Disposal, chemicalData),
                MapChemicalsToDisposalMethod(DisposalCodeConstants.W2Key, DisposalCodeConstants.W2Disposal, chemicalData),
                MapChemicalsToDisposalMethod(DisposalCodeConstants.W3Key, DisposalCodeConstants.W3Disposal, chemicalData),
                MapChemicalsToDisposalMethod(DisposalCodeConstants.W4Key, DisposalCodeConstants.W4Disposal, chemicalData),
                MapChemicalsToDisposalMethod(DisposalCodeConstants.W5Key, DisposalCodeConstants.W5Disposal, chemicalData),
                MapChemicalsToDisposalMethod(DisposalCodeConstants.W6Key, DisposalCodeConstants.W6Disposal, chemicalData),
                MapChemicalsToDisposalMethod(DisposalCodeConstants.W7Key, DisposalCodeConstants.W7Disposal, chemicalData),
                MapChemicalsToDisposalMethod(DisposalCodeConstants.W8Key, DisposalCodeConstants.W8Disposal, chemicalData),
            };

            MapChemicalsToSpecialDisposalMethod(disposalMeasures, chemicalData);

            return disposalMeasures.Where(disposalMeasure => disposalMeasure != null);
        }

        private static DisposalRecommendation? MapChemicalsToDisposalMethod(
            string disposalKey,
            string disposalInstructions,
            IEnumerable<ChemicalHandler> chemicalData)
        {
            var chemicalsWithDisposalKey = FindChemicalsThatMatchKey(disposalKey, chemicalData);

            return chemicalsWithDisposalKey.Any()
                ? new DisposalRecommendation()
                {
                    Key = disposalKey,
                    Instructions = disposalInstructions,
                    Chemicals = chemicalsWithDisposalKey.Select(chemical => chemical.Name)
                }
                : null;
        }

        private static void MapChemicalsToSpecialDisposalMethod(
            ICollection<DisposalRecommendation> disposalRecommendations,
            IEnumerable<ChemicalHandler> chemicalData)
        {
            var chemicalsWithSpecialDisposal = FindChemicalsThatMatchKey(DisposalCodeConstants.WSpecKey, chemicalData);

            chemicalsWithSpecialDisposal.ToList().ForEach((chemical) =>
            {
                disposalRecommendations.Add(new DisposalRecommendation()
                {
                    Key = $"{DisposalCodeConstants.WSpecKey}: {DisposalCodeConstants.WSpec}",
                    Instructions = chemical.Disposal.Instructions,
                    Chemicals = new List<string>() { chemical.Name }
                });
            });
        }

        private static IEnumerable<ChemicalHandler> FindChemicalsThatMatchKey(string disposalKey, IEnumerable<ChemicalHandler> chemicalData) 
            => chemicalData.Where(chemical => chemical.Disposal.Codes.Contains(disposalKey));

    }
}