using System.Linq;

namespace Codingame
{
    public static class RecipeExtensions
    {
        public static int GetCost(this Recipe recipe)
        {
            return recipe.Ingredients.Where(i => i < 0).Sum();
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
                    recipe.Ingredients[1] + inventory[2],
                    recipe.Ingredients[2] + inventory[2],
                    recipe.Ingredients[3] + inventory[3]
                },
                Type = ActionType.DELTA
            };
        }
    }
}
