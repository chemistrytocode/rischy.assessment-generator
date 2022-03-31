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
            
            MapChemicalsToDisposalMethod(DisposalConstants.W1Key, DisposalConstants.W1Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalConstants.W2Key, DisposalConstants.W2Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalConstants.W3Key, DisposalConstants.W3Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalConstants.W4Key, DisposalConstants.W4Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalConstants.W5Key, DisposalConstants.W5Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalConstants.W6Key, DisposalConstants.W6Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalConstants.W7Key, DisposalConstants.W7Disposal, disposalMeasures, chemicalData);
            MapChemicalsToDisposalMethod(DisposalConstants.W8Key, DisposalConstants.W8Disposal, disposalMeasures, chemicalData);
            MapChemicalsToSpecialisedDisposalMethods(disposalMeasures, chemicalData);

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
        
        private static void MapChemicalsToSpecialisedDisposalMethods(
            ICollection<DisposalRecommendation> disposalRecommendations,
            IEnumerable<ChemicalHandler> chemicalData)
        {
            var chemicalsWithSpecialDisposal = FindChemicalsThatMatchKey(DisposalConstants.WSpecKey, chemicalData);

            chemicalsWithSpecialDisposal.ToList().ForEach((chemical) =>
            {
                disposalRecommendations.Add(new DisposalRecommendation()
                {
                    Key = $"{DisposalConstants.WSpecKey}: {DisposalConstants.WSpec}",
                    Instructions = chemical.Disposal.Instructions,
                    Chemicals = new List<string>() { chemical.Name }
                });
            });
        }

        private static IEnumerable<ChemicalHandler> FindChemicalsThatMatchKey(string disposalKey, IEnumerable<ChemicalHandler> chemicalData) 
            => chemicalData.Where(chemical => chemical.Disposal.Codes.Contains(disposalKey));
    }
}