using Codingame;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingameTests
{
    public class CastSelectorTests
    {
        private readonly CastSelector _sut;
        private readonly Recipe _brew57;
        private readonly Recipe _brew42;
        private readonly Recipe _brew56;
        private readonly Recipe _brew64;
        private readonly Recipe _brew58;
        private readonly Recipe _brew54;
        private readonly Recipe _brew55;
        private readonly Recipe _brew68;
        private readonly Recipe _brew49;
        private readonly Recipe _cast82;
        private readonly Recipe _cast83;
        private readonly Recipe _cast84;
        private readonly Recipe _cast85;

        public CastSelectorTests()
        {
            _sut = new CastSelector();
            _brew57 = RecipeHelpers.MakeBrewRecipe(57, 17, 0, 0, -2, -2);
            _brew42 = RecipeHelpers.MakeBrewRecipe(42, 7, -2, -2, 0, 0);
            _brew56 = RecipeHelpers.MakeBrewRecipe(56, 13, 0, -2, -3, 0);
            _brew64 = RecipeHelpers.MakeBrewRecipe(64, 18, 0, 0, -2, -3);
            _brew58 = RecipeHelpers.MakeBrewRecipe(58, 14, -3, 0, -2, 0);
            _brew54 = RecipeHelpers.MakeBrewRecipe(54, 0, 0, -2, 0, -2);
            _brew55 = RecipeHelpers.MakeBrewRecipe(55, 13, 0, -3, -2, 0);
            _brew68 = RecipeHelpers.MakeBrewRecipe(68, 12, -1, 0, -2, -1);
            _brew49 = RecipeHelpers.MakeBrewRecipe(49, 10, 0, -5, 0, 0);
            _cast82 = RecipeHelpers.MakeCastRecipe(82, 2, 0, 0, 0);
            _cast83 = RecipeHelpers.MakeCastRecipe(83, -1, 1, 0, 0);
            _cast84 = RecipeHelpers.MakeCastRecipe(84, 0, -1, 1, 0);
            _cast85 = RecipeHelpers.MakeCastRecipe(85, 0, 0, -1, 1);
        }

        [Fact]
        public void ComputeTargetBrew_ReturnsMostAffordableLucrative_sc1()
        {
            var inventory = new List<int> { 3, 0, 0, 6 };
            var brews = new List<Recipe> { _brew57, _brew42, _brew56, _brew64, _brew58 };

            var result = _sut.ComputeTargetBrew(brews, inventory);

            result.Should().BeEquivalentTo(_brew64);
        }
        
        [Fact]
        public void ComputeTargetBrew_ReturnsMostAffordableLucrative_sc2()
        {
            var inventory = new List<int> { 4, 0, 0, 1 };
            var brews = new List<Recipe> { _brew54, _brew55, _brew68, _brew58, _brew49 };

            var result = _sut.ComputeTargetBrew(brews, inventory);

            result.Should().BeEquivalentTo(_brew58);
        }

        [Fact]
        public void ComputeBestCastForBrew_ReturnsMostAchievableCastSpell()
        {
            _cast82.IsCastable = true;
            _cast83.IsCastable = true;
            _cast84.IsCastable = true;
            _cast85.IsCastable = true;

            var inventory = new List<int> { 3, 0, 0, 6 };
            var casts = new List<Recipe> { _cast82, _cast83 };

            var result = _sut.ComputeBestCastForBrew(casts, inventory, _brew64);

            result.Should().BeEquivalentTo(_cast83);
        }
    }
}
