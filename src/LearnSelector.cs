using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class LearnSelector
    {
        public Recipe FindLearn(IEnumerable<Recipe> learnables)
        {
            var selected = learnables.FirstOrDefault(l => l.Ingredients.All(i => i >= 0));

            if (selected != null)
                return selected;

            var tierZero = learnables.Where(l => l.Ingredients[3] < 0);

            return tierZero.FirstOrDefault(); ;
        }
    }
}
