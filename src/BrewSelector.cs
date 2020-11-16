using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class BrewSelector
    {
        public Recipe SelectTargetBrewSpell(IEnumerable<Recipe> brewRecipes, int[] inventory)
        {
            var lowestAchievabilityCost = int.MinValue;
            var achievabilityBrewMapping = new Dictionary<Recipe, int>();
            foreach (var brew in brewRecipes)
            {
                var delta = brew.GetInventoryDelta(inventory);

                if (delta.Cost > lowestAchievabilityCost)
                {
                    lowestAchievabilityCost = delta.Cost;
                }

                achievabilityBrewMapping.Add(brew, delta.Cost);
            }

            var mostAchievableBrews = achievabilityBrewMapping.Where(m => m.Value == lowestAchievabilityCost)
                                                              .Select(m => m.Key)
                                                              .ToList();

            return mostAchievableBrews.Count == 1
                   ? mostAchievableBrews.FirstOrDefault()
                   : mostAchievableBrews.FirstOrDefault(r => r.Income == mostAchievableBrews.Max(r => r.Income))
                   ?? brewRecipes.FirstOrDefault();
        }
    }
}
