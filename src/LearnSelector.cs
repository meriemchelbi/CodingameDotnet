using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codingame
{
    public class LearnSelector
    {
        public Recipe SelectLearnSpell(IEnumerable<Recipe> cookableLearns)
        {
            return cookableLearns.FirstOrDefault(c => c.Ingredients[3] == -1)
                ?? cookableLearns.FirstOrDefault();
        }
    }
}









