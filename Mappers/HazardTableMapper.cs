using System.Collections.Generic;
using System.Linq;
using rischy.assessment_generator.Constants;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Mappers
{
    public class HazardTableMapper
    {
        public HazardTableMapper() {}
        
        public IEnumerable<BaseChemical> Map(IEnumerable<ChemicalHandler> chemicalData)
        {
            var listOfChemicals = new List<BaseChemical>();

            AddChemicalsToHazardTable(listOfChemicals, chemicalData);

            return listOfChemicals;
        }
        
        private static void AddChemicalsToHazardTable(
            ICollection<BaseChemical> listOfChemicals, 
            IEnumerable<ChemicalHandler> chemicalData)
        {
            chemicalData.ToList().ForEach(chemical =>
            {
                listOfChemicals.Add(new BaseChemical
                {        
                    Name = chemical.Name,
                    State = chemical.State,
                    Concentration = chemical.Concentration,
                    Hazard = chemical.Hazard?.ToList() ?? new List<string>() { HazardConstants.LowHazard },
                    Comment = chemical.Comment ?? HazardConstants.NoNotableHazard,
                });
            });
        }
    }
}