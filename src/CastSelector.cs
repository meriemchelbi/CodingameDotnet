using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class CastSelector
    {
        public string FindCastForTargetBrew(Recipe targetBrew, int[] inventory, IEnumerable<Recipe> castableCasts)
        {
            var castsMappings = new Dictionary<Recipe, CastStats>();
            var leastNegativeEndInventory = int.MinValue;
            var fullestEndInventory = int.MinValue;

            // if cookable twice
            // calculate delta
            // perform highest & lowest inventory checks
            // Add to cast stats

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

            }

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
