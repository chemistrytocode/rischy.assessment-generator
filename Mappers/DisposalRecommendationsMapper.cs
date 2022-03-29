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
            var disposalMeasures = new List<DisposalRecommendation>();
            
            MapChemicalsToDisposalMethod(DisposalCodeConstants.W1Key, DisposalCodeConstants.W1Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalCodeConstants.W2Key, DisposalCodeConstants.W2Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalCodeConstants.W3Key, DisposalCodeConstants.W3Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalCodeConstants.W4Key, DisposalCodeConstants.W4Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalCodeConstants.W5Key, DisposalCodeConstants.W5Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalCodeConstants.W6Key, DisposalCodeConstants.W6Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalCodeConstants.W7Key, DisposalCodeConstants.W7Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalCodeConstants.W8Key, DisposalCodeConstants.W8Disposal, disposalMeasures, chemicalData);
            MapChemicalsToSpecialDisposalMethods(disposalMeasures, chemicalData);

            return disposalMeasures;
        }

        private static void MapChemicalsToDisposalMethod(
            string disposalKey,
            string disposalInstruction,
            ICollection<DisposalRecommendation> disposalRecommendations,
            IEnumerable<ChemicalHandler> chemicalData)
        {
            var chemicalsWithDisposalKey = FindChemicalsThatMatchKey(disposalKey, chemicalData);

            if (chemicalsWithDisposalKey.Any())
            {
                disposalRecommendations.Add(new DisposalRecommendation()
                {
                    Key = disposalKey,
                    Instructions = disposalInstruction,
                    Chemicals = chemicalsWithDisposalKey.Select(chemical => chemical.Name)
                });
            }
        }
        
        private static void MapChemicalsToSpecialDisposalMethods(
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