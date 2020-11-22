using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class CastSelector
    {
        public string FindCastForTargetBrew(Recipe targetBrew, int[] inventory, IEnumerable<Recipe> castableCasts)
        {
            if (castableCasts is null 
                || !castableCasts.Any() 
                || castableCasts.All(c => !c.CanCookRecipe(inventory)))
            {
                return null;
            }

            var castsMappings = new Dictionary<Recipe, CastStats>();
            var leastNegativeEndInventory = int.MinValue;
            var fullestEndInventory = int.MinValue;

            foreach (var cast in castableCasts)
            {
                var targetInventoryDelta = targetBrew.GetInventoryDelta(inventory);
                var stats = new CastStats();
                castsMappings.Add(cast, stats);

                if (cast.CanCookRecipe(inventory))
                {
                    var delta = cast.GetDelta(targetInventoryDelta);

                    if (delta.Cost > leastNegativeEndInventory)
                        leastNegativeEndInventory = delta.Cost;

                    if (delta.Yield > fullestEndInventory)
                        fullestEndInventory = delta.Yield;

                    stats.CookableOnce = true;
                    stats.EndStateOnce = delta;
                }

                var inventoryCastOnce = cast.GetInventoryDelta(inventory);
                var targetInvDeltaSecond = targetBrew.GetDelta(inventoryCastOnce);

                if (cast.IsRepeatable && cast.CanCookRecipe(inventoryCastOnce.Ingredients))
                {
                    var delta = cast.GetDelta(targetInvDeltaSecond);

                    if (delta.Cost > leastNegativeEndInventory)
                        leastNegativeEndInventory = delta.Cost;

                    if (delta.Yield > fullestEndInventory)
                        fullestEndInventory = delta.Yield;

                    stats.CookableTwice = true;
                    stats.EndStateTwice = delta;
                }
            }

            var lowestCost = castsMappings.Where(c => c.Value.CookableOnce && c.Value.EndStateOnce.Cost == leastNegativeEndInventory
                                                    || c.Value.CookableTwice && c.Value.EndStateTwice.Cost == leastNegativeEndInventory)
                                        .ToList();

            var highestYield = castsMappings.Where(c => c.Value.CookableOnce && c.Value.EndStateOnce.Yield == fullestEndInventory
                                                    || c.Value.CookableTwice && c.Value.EndStateTwice.Yield == fullestEndInventory)
                                          .FirstOrDefault();

            var selected = lowestCost.Count == 1
                           ? lowestCost.FirstOrDefault()
                           : highestYield;

            var result = selected.Value.CookableTwice
                        ? $"{selected.Key.Type} {selected.Key.Id} 2"
                        : $"{selected.Key.Type} {selected.Key.Id}";

            return result;

            //var cheapestCasts = castDeltaMappings.Where(m => m.Value.Cost == leastNegativeEndInventory)
            //                                     .Select(m => m.Key).ToList();
            //var highestRemainderCasts = castDeltaMappings.Where(m => m.Value.Yield == fullestEndInventory)
            //                                          .Select(m => m.Key);

            //var selected = cheapestCasts.Count == 1 
            //        ? cheapestCasts.FirstOrDefault()
            //        : highestRemainderCasts.FirstOrDefault()
            //        ?? castableCasts.FirstOrDefault();

            //return selected is null
            //    ? null
            //    : $"{selected.Type} {selected.Id}";
        }

        private class CastStats
        {
            public bool CookableOnce { get; set; }
            public Recipe EndStateOnce { get; set; }
            public bool CookableTwice { get; set; }
            public Recipe EndStateTwice { get; set; }
        }
    }
}
