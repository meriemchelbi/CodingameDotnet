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

        //[Fact]
        //public void FindCast_ReturnsCastWithSmallestEndStateCost()
        //{
        //    var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
        //    var targetInventoryDelta = RecipeHelpers.MakeDeltaRecipe(1, 1, -2, 5);

        //    var result = _sut.FindCastForTargetBrew(targetInventoryDelta, casts);

        //    result.Should().BeEquivalentTo(_cast2);
        //}

        // When can get closest with casting once, return spell to cast (return string?) based on smallest remaining cost
        [Fact]
        public void FindCast_ReturnsCorrectCastInstruction_SmallestEndStateCost_WhenCastOnce()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var targetInventoryDelta = RecipeHelpers.MakeDeltaRecipe(1, 1, -2, 5);

            var result = _sut.FindCastForTargetBrew(targetInventoryDelta, casts);

            result.Should().Be("CAST 2");
        }
        
        //[Fact]
        //public void FindCast_SingleCastableCast_ReturnsThis()
        //{
        //    var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
        //    var targetInventoryDelta = RecipeHelpers.MakeDeltaRecipe(1, 1, -2, 5);

        //    var result = _sut.FindCastForTargetBrew(targetInventoryDelta, casts);

        //    result.Should().BeEquivalentTo(_cast2);
        //}
        
        //[Fact]
        //public void FindCast_NoCastableCast_ReturnsNull()
        //{
        //    var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
        //    var targetInventoryDelta = RecipeHelpers.MakeDeltaRecipe(1, 1, -2, 5);

        //    var result = _sut.FindCastForTargetBrew(targetInventoryDelta, casts);

        //    result.Should().BeEquivalentTo(_cast2);
        //}

        [Fact]
        public void FindCast_AllCastableSameEndCosts_ReturnsCastWithHighestEndStateYield()
        {
            var cast5 = RecipeHelpers.MakeCastRecipe(5, 1, -1, 1, 2);
            var casts = new List<Recipe> { _cast2, _cast3, cast5, _cast1 };
            var targetInventoryDelta = RecipeHelpers.MakeDeltaRecipe(1, 1, -2, 5);

            var result = _sut.FindCastForTargetBrew(targetInventoryDelta, casts);

            result.Should().BeEquivalentTo("CAST 5");
        }


        // When can get closest with casting twice return spell to cast & number of times based on smallest remaining cost
        // if all same costs return cast with highest yield, times 1
    }
}
