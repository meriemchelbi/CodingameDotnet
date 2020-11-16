using Codingame;
using FluentAssertions;
using Xunit;

namespace CodingameTests
{
    public class RecipeExtensionsTests
    {
        [Theory]
        [InlineData(true, -1, 0, 0, 0)]
        [InlineData(true, 0, -2, 0, 0)]
        [InlineData(false, 0, 0, -1, 0)]
        [InlineData(false, 0, 0, 0, -1)]
        [InlineData(false, -1, -2, -1, -1)]
        public void CanCookRecipe_BREW(bool expected, params int[] ingredients)
        {
            var inventory = new int[] { 1, 3, 0, 0 };
            var recipe = new Recipe
            {
                Ingredients = ingredients,
                Type = ActionType.BREW
            };

            var result = RecipeExtensions.CanCookRecipe(inventory, recipe);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, 0, 0, 0, 9, -1, 1, 0, 0)]
        [InlineData(false, 6, 0, 0, 3, 2, 0, 0, 0)]
        public void CanCookRecipe_CAST(bool expected, int inv0, int inv1, int inv2, int inv3, params int[] ingredients)
        {
            var inventory = new int[] { inv0, inv1, inv2, inv3 };
            var recipe = new Recipe
            {
                Ingredients = ingredients,
                Type = ActionType.CAST
            };

            var result = RecipeExtensions.CanCookRecipe(inventory, recipe);

            result.Should().Be(expected);
        }
    }
}
