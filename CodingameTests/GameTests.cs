using Codingame;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingameTests
{
    public class GameTests
    {
        [Fact]
        public void CastingMess()
        {
            var game = new Game();
            
            var brew49 = new Recipe
            {
                Id = 49,
                IsCastable = false,
                Ingredients = new int[] { 0, 0, -5, 0 },
                Type = ActionType.BREW
            };
            
            var brew54 = new Recipe
            {
                Id = 54,
                IsCastable = false,
                Ingredients = new int[] { 0, 0, -2, -2 },
                Type = ActionType.BREW
            };
            
            var brew65 = new Recipe
            {
                Id = 65,
                IsCastable = false,
                Ingredients = new int[] { 0, 0, 0, -5 },
                Type = ActionType.BREW
            };
            
            var brew47 = new Recipe
            {
                Id = 47,
                IsCastable = false,
                Ingredients = new int[] { -3, -2, 0, 0 },
                Type = ActionType.BREW
            };
            
            var brew50 = new Recipe
            {
                Id = 50,
                IsCastable = false,
                Ingredients = new int[] { -2, 0, 0, -2 },
                Type = ActionType.BREW
            };

            var castable78 = new Recipe
            {
                Id = 78,
                IsCastable = true,
                Ingredients = new int[] { 2, 0, 0, 0 },
                Type = ActionType.CAST
            };
            
            var castable79 = new Recipe
            {
                Id = 79,
                IsCastable = false,
                Ingredients = new int[] { -1, 1, 0, 0 },
                Type = ActionType.CAST
            };
            
            var castable80 = new Recipe
            {
                Id = 80,
                IsCastable = false,
                Ingredients = new int[] { 0, -1, 1, 0 },
                Type = ActionType.CAST
            };

            game.Witches[0].Inventory = new List<int> { 6, 0, 0, 3 };
            game.Recipes = new List<Recipe> { castable78 };

            var result = game.DecideAction();

            result.Should().Be("CAST 8");
        }
    }
}
