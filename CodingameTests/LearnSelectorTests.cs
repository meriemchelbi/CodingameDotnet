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
        public void SelectLearnSpell_ContainsLearnChargingTier3Ingredient_ReturnsThis()
        {
            var tier2Learn = RecipeHelpers.MakeLearnRecipe(1, 1, 0, -1, 3);
            var tier3Learn = RecipeHelpers.MakeLearnRecipe(2, 2, 0, -1, -1);
            var cookableLearns = new List<Recipe> { tier2Learn, tier3Learn };

            var result = _sut.SelectLearnSpell(cookableLearns);

            result.Should().BeEquivalentTo(tier3Learn);
        }
        
        [Fact] // TODO extend to return most lucrative? Return cheapest
        public void SelectLearnSpell_ContainsMultipleLearnsChargingTier3Ingredient_ReturnsFirst()
        {
            var tier2Learn = RecipeHelpers.MakeLearnRecipe(1, 1, 0, -1, 3);
            var tier3Learn1 = RecipeHelpers.MakeLearnRecipe(2, 2, 0, -1, -1);
            var tier3Learn2 = RecipeHelpers.MakeLearnRecipe(3, 2, 0, 3, -1);
            var cookableLearns = new List<Recipe> { tier2Learn, tier3Learn1, tier3Learn2 };

            var result = _sut.SelectLearnSpell(cookableLearns);

            result.Should().BeEquivalentTo(tier3Learn1);
        }
        
        //[Fact] 
        //public void SelectLearnSpell_ContainsNoLearnsChargingTier3Ingredient_ReturnsFirstLearn()
        //{
        //    var tier2Learn = RecipeHelpers.MakeLearnRecipe(1, 1, 0, -1, 3);
        //    var tier0Learn = RecipeHelpers.MakeLearnRecipe(2, -1, 0, 0, 3);
        //    var cookableLearns = new List<Recipe> { tier2Learn, tier0Learn};

        //    var result = _sut.SelectLearnSpell(cookableLearns);

        //    result.Should().BeEquivalentTo(tier2Learn);
        //}
        
        [Fact] // TODO extend to prioritise deducting of specific tiers?
        public void SelectLearnSpell_ContainsNoLearnsChargingTier3Ingredient_ReturnsCheapestToCast()
        {
            var learn1 = RecipeHelpers.MakeLearnRecipe(1, 1, 0, -5, 3);
            var learn2 = RecipeHelpers.MakeLearnRecipe(2, -1, 0, 0, 3);
            var learn3 = RecipeHelpers.MakeLearnRecipe(3, 0, -1, -1, 3);
            var cookableLearns = new List<Recipe> { learn1, learn2, learn3 };

            var result = _sut.SelectLearnSpell(cookableLearns);

            result.Should().BeEquivalentTo(learn2);
        }
    }
}
