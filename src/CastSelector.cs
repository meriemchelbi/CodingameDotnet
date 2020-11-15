using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class CastSelector
    {
        public Recipe FindCast(Recipe targetInventoryDelta, IEnumerable<Recipe> availableCasts)
        {
            var smallestCost = int.MinValue;
            Recipe selected = availableCasts.FirstOrDefault();

            foreach (var cast in availableCasts)
            {
                var delta = cast.GetDelta(targetInventoryDelta);
                if (delta.Cost > smallestCost)
                {
                    smallestCost = delta.Cost;
                    selected = cast;
                }
            }

            return selected;
        }
    }
}
