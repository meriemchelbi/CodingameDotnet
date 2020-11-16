using System.Linq;

namespace Codingame
{
    public static class RecipeExtensions
    {
        public static int GetCost(this Recipe recipe)
        {
            return recipe.Ingredients.Where(i => i < 0).Sum();
        }
        
        public static int GetYield(this Recipe recipe)
        {
            return recipe.Ingredients.Where(i => i > 0).Sum();
        }

        public static Recipe GetDelta(this Recipe recipe1, Recipe recipe2)
        {
            return new Recipe
            {
                Ingredients = new int[]
                {
                    recipe1.Ingredients[0] + recipe2.Ingredients[0],
                    recipe1.Ingredients[1] + recipe2.Ingredients[1],
                    recipe1.Ingredients[2] + recipe2.Ingredients[2],
                    recipe1.Ingredients[3] + recipe2.Ingredients[3]
                },
                Type = ActionType.DELTA
            };
        }
        
        public static Recipe GetInventoryDelta(this Recipe recipe, int[] inventory)
        {
            return new Recipe
            {
                Ingredients = new int[]
                {
                    recipe.Ingredients[0] + inventory[0],
                    recipe.Ingredients[1] + inventory[1],
                    recipe.Ingredients[2] + inventory[2],
                    recipe.Ingredients[3] + inventory[3]
                },
                Type = ActionType.DELTA
            };
        }

        public static bool CanCookRecipe(int[] inventory, Recipe recipe)
        {
            var ingredients = recipe.Ingredients;

            var sum0 = ingredients[0] + inventory[0];
            var sum1 = ingredients[1] + inventory[1];
            var sum2 = ingredients[2] + inventory[2];
            var sum3 = ingredients[3] + inventory[3];

            var sumOfSums = sum0 + sum1 + sum2 + sum3;

            return sum0 >= 0 && sum1 >= 0 && sum2 >= 0 && sum3 >= 0
                && sumOfSums <= 10;
        }

        public static bool CanLearn(int[]inventory, int spellIndex)
        {
            return spellIndex <= inventory[0];
        }
    }
}
