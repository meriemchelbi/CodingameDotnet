using Codingame;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingameTests
{
    public class LearnSelectorTests
    {
        private readonly LearnSelector _sut;

        public LearnSelectorTests()
        {
            _sut = new LearnSelector();
        }

        [Fact]
        public void FindLearn_OneFreeLearn_Returns()
        {
            var learn1 = RecipeHelpers.MakeLearnRecipe(1, -1, 2, 5, 0);
            var learn2 = RecipeHelpers.MakeLearnRecipe(2, 1, 2, -5, 0);
            var freeLearn = RecipeHelpers.MakeLearnRecipe(3, 1, 2, 0, 0);

            var learnables = new List<Recipe> { learn1, learn2, freeLearn };

            var result = _sut.FindLearn(learnables);

            result.Should().BeEquivalentTo(freeLearn);
        }
        
        [Fact]
        public void FindLearn_MultipleFreeLearns_ReturnsFirst()
        {
            var learn1 = RecipeHelpers.MakeLearnRecipe(1, -1, 2, 5, 0);
            var learn2 = RecipeHelpers.MakeLearnRecipe(2, 1, 2, -5, 0);
            var freeLearn1 = RecipeHelpers.MakeLearnRecipe(3, 1, 2, 0, 0);
            var freeLearn2 = RecipeHelpers.MakeLearnRecipe(4, 0, 2, 4, 1);

            var learnables = new List<Recipe> { learn1, freeLearn1, learn2, freeLearn2 };

            var result = _sut.FindLearn(learnables);

            result.Should().BeEquivalentTo(freeLearn1);
        }
        
        [Fact]
        public void FindLearn_NoFreeLearns_OneChargingFinalIngredient_ReturnsThat()
        {
            var learn1 = RecipeHelpers.MakeLearnRecipe(1, -1, 2, 5, 0);
            var learn2 = RecipeHelpers.MakeLearnRecipe(2, 1, 2, -5, 0);
            var learn3 = RecipeHelpers.MakeLearnRecipe(3, 1, 2, 0, -1);

            var learnables = new List<Recipe> { learn1, learn2, learn3 };

            var result = _sut.FindLearn(learnables);

            result.Should().BeEquivalentTo(learn3);
        }
        
        [Fact]
        public void FindLearn_NoFreeLearns_NoneChargingFinalIngredient_ReturnsNull()
        {
            var learn1 = RecipeHelpers.MakeLearnRecipe(1, -1, 2, 5, 0);
            var learn2 = RecipeHelpers.MakeLearnRecipe(2, 1, 2, -5, 0);

            var learnables = new List<Recipe> { learn1, learn2 };

            var result = _sut.FindLearn(learnables);

            result.Should().BeNull();
        }
    }
}
