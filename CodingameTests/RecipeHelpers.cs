using Codingame;

namespace CodingameTests
{
    public static class RecipeHelpers
    {
        public static Recipe MakeBrewRecipe(int id, params int[] ingredients)
        {
            return new Recipe
            {
                Id = id,
                IsCastable = false,
                Ingredients = ingredients,
                Type = ActionType.BREW
            };
        }

        public static Recipe MakeCastRecipe(int id, params int[] ingredients)
        {
            return new Recipe
            {
                Id = id,
                IsCastable = false,
                Ingredients = ingredients,
                Type = ActionType.CAST
            };
        }
    }
}
