using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class LearnSelector
    {
        public Recipe SelectLearnSpell(IEnumerable<Recipe> cookableLearns)
        {
            var selected = cookableLearns.FirstOrDefault(c => c.Ingredients[3] < 0 );

            var lowestCost = int.MinValue;
            var learnToCostMapping = new Dictionary<Recipe, int>();

            if (selected is null)
            {
                foreach (var learn in cookableLearns)
                {
                    var cost = learn.Ingredients.Where(i => i < 0).Sum();
                    learnToCostMapping.Add(learn, cost);

                    lowestCost = cost > lowestCost
                                   ? cost
                                   : lowestCost;
                }

                return learnToCostMapping.FirstOrDefault(m => m.Value == lowestCost).Key;
            }

            return selected;
        }
    }
}









