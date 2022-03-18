using System.Collections.Generic;
using rischy.assessment_generator.Models;

namespace rischy.assessment_generator.Mappers
{
    public class HazardTableMapper
    {
        public HazardTableMapper() {}
        
        public IEnumerable<HazardTableChemical> Map()
        {
            var listOfChemicals = new List<HazardTableChemical>();

            AddChemicalsToHazardTable(listOfChemicals);

            return listOfChemicals;
        }

        private static void AddChemicalsToHazardTable(ICollection<HazardTableChemical> listOfChemicals)
        {
            // Prototype is hardcoded
            var chemical = new HazardTableChemical
            {
                Name = "Barium Chloride",
                State = "Solid",
                Hazard = new List<string>() {"Toxic "},
                Comment = "Harmful if swallowed"
            };
            
            listOfChemicals.Add(chemical);
        }
    }
}
