using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class CastSelector
    {
        public Recipe FindCastForTargetBrew(Recipe targetInventoryDelta, IEnumerable<Recipe> availableCasts)
        {
            var leastNegativeEndInventory = int.MinValue;
            var fullestEndInventory = int.MinValue;
            var castDeltaMappings = new Dictionary<Recipe, Recipe>();

            foreach (var cast in availableCasts)
            {
                var delta = cast.GetDelta(targetInventoryDelta);

                if (delta.Cost > leastNegativeEndInventory)
                    leastNegativeEndInventory = delta.Cost;

                if (delta.Yield > fullestEndInventory)
                    fullestEndInventory = delta.Yield;

                castDeltaMappings.Add(cast, delta);
            }

            var cheapestCasts = castDeltaMappings.Where(m => m.Value.Cost == leastNegativeEndInventory)
                                                 .Select(m => m.Key).ToList();
            var highestRemainderCasts = castDeltaMappings.Where(m => m.Value.Yield == fullestEndInventory)
                                                      .Select(m => m.Key);

            // TODO work out whether to repeat a cast
            return cheapestCasts.Count == 1 
                    ? cheapestCasts.FirstOrDefault()
                    : highestRemainderCasts.FirstOrDefault()
                    ?? availableCasts.FirstOrDefault();
        }
    }
}
