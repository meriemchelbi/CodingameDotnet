using Codingame;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingameTests
{
    public class WitchTests
    {
        private readonly Witch _sut;

        public WitchTests()
        {
            _sut = new Witch();
        }

        [Theory]
        [InlineData(true, -1, 0, 0, 0)]
        [InlineData(true, 0, -2, 0, 0)]
        [InlineData(false, 0, 0, -1, 0)]
        [InlineData(false, 0, 0, 0, -1)]
        [InlineData(false, -1, -2, -1, -1)]
        public void CanCookRecipe_BREW(bool expected, params int[] ingredients)
        {
            _sut.Inventory = new List<int> { 1, 3, 0, 0};
            var recipe = new Recipe 
            { 
                Ingredients = ingredients,
                Type = ActionType.BREW
            };

            var result = _sut.CanCookRecipe(recipe);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, 0, 0, 0, 9, -1, 1, 0, 0)]
        [InlineData(false, 6, 0, 0, 3, 2, 0, 0, 0)]
        public void CanCookRecipe_CAST(bool expected, int inv0, int inv1, int inv2, int inv3, params int[] ingredients)
        {
            _sut.Inventory = new List<int> { inv0, inv1, inv2, inv3 };
            var recipe = new Recipe
            {
                Ingredients = ingredients,
                Type = ActionType.CAST
            };

            var result = _sut.CanCookRecipe(recipe);

            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData(true, 0, 0)]
        [InlineData(true, 3, 6)]
        [InlineData(true, 3, 3)]
        [InlineData(false, 1, 0)]
        [InlineData(false, 5, 3)]
        public void CanLearnRecipe(bool expected, int spellIndex, int invTier0)
        {
            _sut.Inventory = new List<int> { invTier0 };
            var recipe = new Recipe
            {
                Type = ActionType.LEARN
            };

            var result = _sut.CanLearnRecipe(spellIndex);

            result.Should().Be(expected);
        }
    }
}
