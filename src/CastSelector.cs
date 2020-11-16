using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class CastSelector
    {
        public Recipe FindCastForTargetBrew(Recipe targetInventoryDelta, IEnumerable<Recipe> availableCasts)
        {
            var smallestCost = int.MinValue;
            var highestYield = int.MinValue;
            var castDeltaMappings = new Dictionary<Recipe, (int, int)>();

            foreach (var cast in availableCasts)
            {
                var delta = cast.GetDelta(targetInventoryDelta);

                if (delta.Cost > smallestCost)
                    smallestCost = delta.Cost;

                // TODO add yield to Recipe model
                var yield = delta.Ingredients.Sum();

                if (yield > highestYield)
                    highestYield = yield;

                castDeltaMappings.Add(cast, (delta.Cost, yield));
            }

            var cheapestCasts = castDeltaMappings.Where(m => m.Value.Item1 == smallestCost)
                                                 .Select(m => m.Key).ToList();
            var highestYieldCasts = castDeltaMappings.Where(m => m.Value.Item2 == highestYield)
                                                      .Select(m => m.Key);

            // TODO work out whether to repeat a cast
            return cheapestCasts.Count == 1 
                    ? cheapestCasts.FirstOrDefault()
                    : highestYieldCasts.FirstOrDefault()
                    ?? availableCasts.FirstOrDefault();
        }
    }
}
