using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class CastSelector
    {
        public Recipe FindCast(Recipe targetInventoryDelta, IEnumerable<Recipe> availableCasts)
        {
            var smallestCost = int.MinValue;
            var highestYield = int.MinValue;
            Recipe cheapestCast = null;
            Recipe mostLucrativeCast = null;

            foreach (var cast in availableCasts)
            {
                var delta = cast.GetDelta(targetInventoryDelta);

                if (delta.Cost > smallestCost)
                {
                    smallestCost = delta.Cost;
                    cheapestCast = cast;
                }

                var yield = delta.Ingredients.Sum();
                if (yield > highestYield)
                {
                    highestYield = yield;
                    mostLucrativeCast = cast;
                }
            }
            
            return cheapestCast ?? mostLucrativeCast?? availableCasts.FirstOrDefault();
        }
    }
}
