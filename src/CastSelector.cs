using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class CastSelector
    {
        public Recipe SelectCast(IEnumerable<Recipe> casts, List<int> inventory)
        {
            var indexCastsDictionary = new Dictionary<int, Recipe>();

            foreach (var cast in casts)
            {
                if (cast.Ingredients[0] == 2)
                    indexCastsDictionary.Add(0, cast);
                if (cast.Ingredients[0] == -1)
                    indexCastsDictionary.Add(1, cast);
                if (cast.Ingredients[1] == -1)
                    indexCastsDictionary.Add(2, cast);
                if (cast.Ingredients[2] == -1)
                    indexCastsDictionary.Add(3, cast);
                if (cast.Ingredients[3] == -1)
                    indexCastsDictionary.Add(4, cast);
            }

            var lowestItem = inventory.Min();
            if (inventory.Count(i => i == lowestItem) == 1)
            {
                var lowestIndex = inventory.IndexOf(lowestItem);
                var lowSuccess = indexCastsDictionary.TryGetValue(lowestIndex, out var castForLowest);
                
                if (lowSuccess)
                    return castForLowest;
            }

            var highestItem = inventory.Max();
            if (inventory.Count(i => i == highestItem) == 1)
            {
                var highestIndex = inventory.IndexOf(highestItem);
                var highSuccess = indexCastsDictionary.TryGetValue(highestIndex + 1, out var castForHighest);

                if (highSuccess)
                    return castForHighest;
            }

            return casts.FirstOrDefault();
        }
    }
}
