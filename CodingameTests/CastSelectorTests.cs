using Codingame;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingameTests
{
    public class CastSelectorTests
    {
        private readonly CastSelector _sut;
        private readonly Recipe _cast0;
        private readonly Recipe _cast1;
        private readonly Recipe _cast2;
        private readonly Recipe _cast3;

        public CastSelectorTests()
        {
            _sut = new CastSelector();
            _cast0 = RecipeHelpers.MakeCastRecipe(0, 2, 0, 0, 0);
            _cast1 = RecipeHelpers.MakeCastRecipe(1, -1, 1, 0, 0);
            _cast2 = RecipeHelpers.MakeCastRecipe(2, 0, -1, 1, 0);
            _cast3 = RecipeHelpers.MakeCastRecipe(3, 0, 0, -1, 1);
        }

        [Fact]
        public void FindCast_NoneRepeatable_AllCookable_SmallestEndStateCost_WhenCastOnce()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new int[] { 2, 2, 2, 0 };
            var targetBrew = RecipeHelpers.MakeBrewRecipe(1, 100, 0, -2, 0, -2);

            var result = _sut.FindCastForTargetBrew(targetBrew, inventory, casts);

            result.Should().Be("CAST 3");
        }
        
        [Fact]
        public void FindCast_NoneRepeatable_AllCookable_SmallestEndStateCost_WhenCastTwice()
        {
            _cast0.IsRepeatable = true;
            _cast1.IsRepeatable = true;
            _cast2.IsRepeatable = true;
            _cast3.IsRepeatable = true;

            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new int[] { 2, 2, 2, 0 };
            var targetBrew = RecipeHelpers.MakeBrewRecipe(1, 100, 0, -2, 0, -2);

            var result = _sut.FindCastForTargetBrew(targetBrew, inventory, casts);

            result.Should().Be("CAST 2 2");
        }

        [Fact]
        public void FindCast_SingleCastableCookableCast_ReturnsThis()
        {
            var casts = new List<Recipe> { _cast3 };
            var inventory = new int[] { 2, 2, 2, 0 };
            var targetBrew = RecipeHelpers.MakeBrewRecipe(1, 100, 0, -2, 0, -2);

            var result = _sut.FindCastForTargetBrew(targetBrew, inventory, casts);

            result.Should().BeEquivalentTo("CAST 3");
        }
        
        [Fact]
        public void FindCast_SingleCastableNotCookable_ReturnsNull()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new int[] { 2, 2, 0, 0 };
            var targetBrew = RecipeHelpers.MakeBrewRecipe(1, 100, 0, -2, 0, -2);

            var result = _sut.FindCastForTargetBrew(targetBrew, inventory, casts);

            result.Should().BeNull();
        }

        [Fact]
        public void FindCast_NoCastableCast_ReturnsNull()
        {
            var inventory = new int[] { 2, 2, 0, 0 };
            var targetBrew = RecipeHelpers.MakeBrewRecipe(1, 100, 0, -2, 0, -2);

            var result = _sut.FindCastForTargetBrew(targetBrew, inventory, null);

            result.Should().BeNull();
        }

        [Fact]
        public void FindCast_AllCastableCookable_NoneRepeatable_SameEndCosts_ReturnsCastWithHighestEndStateYield()
        {
            _cast3.IsCastable = true;           
            var cast5 = RecipeHelpers.MakeCastRecipe(5, 1, -1, 1, 2);

            var casts = new List<Recipe> { _cast2, _cast3, cast5 };
            var inventory = new int[] { 2, 2, 0, 5 };
            var targetBrew = RecipeHelpers.MakeBrewRecipe(1, 100, -1, -1, -2, 0);

            var result = _sut.FindCastForTargetBrew(targetBrew, inventory, casts);

            result.Should().BeEquivalentTo("CAST 5");
        }
    }
}
