using Codingame;
using Xunit;

namespace CodingameTests
{
    public class WitchTests
    {
        [Theory]
        [InlineData(true, 2, 1, 5, 0)]
        [InlineData(false, 2, 1, 1, 6)]
        [InlineData(false, 0, 0, 0, 0)]
        public void CanCookRecipe(bool expected, params int[] inventory)
        {
            var witch = new Witch(inventory);

            var recipe = new Recipe
            {
                Ingredients = new int[] {-1, 0, -2, 0 }
            };

            var result = witch.CanCookRecipe(recipe);

            Assert.Equal(expected, result);
        }
    }
}
