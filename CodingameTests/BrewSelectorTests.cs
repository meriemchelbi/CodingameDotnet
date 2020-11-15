using Codingame;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace CodingameTests
{
    public class BrewSelectorTests
    {
        private readonly BrewSelector _sut;

        public BrewSelectorTests()
        {
            _sut = new BrewSelector();
        }

        [Fact]
        public void SelectBrewingSpell_SingleMostAchievable_SelectsMostAchievableBrew()
        {
            var inventory = new int[] { 1, 5, 1, 2 };
            var brew1 = RecipeHelpers.MakeBrewRecipe(1, 15, 0, 0, -4, 0);
            var brew2 = RecipeHelpers.MakeBrewRecipe(2, 10, -3, 0, -2, 0);
            var brew3 = RecipeHelpers.MakeBrewRecipe(3, 14, 0, 0, -2, -2);
            var brew4 = RecipeHelpers.MakeBrewRecipe(4, 18, -1, -1, -3, -1);
            var brewRecipes = new List<Recipe> { brew1, brew2, brew3, brew4 };

            var result = _sut.SelectTargetBrewSpell(brewRecipes, inventory);

            result.Should().BeEquivalentTo(brew3);
        }
        
        [Fact]
        public void SelectBrewingSpell_MultipleMostAchievable_SelectsMostLucrative()
        {
            var inventory = new int[] { 1, 5, 1, 2 };
            var brew1 = RecipeHelpers.MakeBrewRecipe(1, 15, 0, 0, -4, 0);
            var brew2 = RecipeHelpers.MakeBrewRecipe(2, 10, -3, 0, -2, 0);
            var brew3 = RecipeHelpers.MakeBrewRecipe(3, 14, 0, 0, -2, -2);
            var brew4 = RecipeHelpers.MakeBrewRecipe(4, 18, -1, -1, -3, -1);
            var brew5 = RecipeHelpers.MakeBrewRecipe(5, 20, -1, -1, -1, -3);
            var brewRecipes = new List<Recipe> { brew1, brew2, brew3, brew4, brew5 };

            var result = _sut.SelectTargetBrewSpell(brewRecipes, inventory);

            result.Should().BeEquivalentTo(brew5);
        }

        //[Fact]
        //public void SelectBrewingSpell_SingleHighestIncome_ReturnsThis()
        //{
        //    var brew1 = RecipeHelpers.MakeBrewRecipe(1, 5, 0, -1, -2, -1);
        //    var brew2 = RecipeHelpers.MakeBrewRecipe(2, 15, 0, -1, -2, -8);
        //    var brew3 = RecipeHelpers.MakeBrewRecipe(3, 10, 0, -1, -2, -1);
        //    var brewRecipes = new List<Recipe> { brew1, brew2, brew3 };

        //    var result = _sut.SelectTargetBrewSpell(brewRecipes);

        //    result.Should().BeEquivalentTo(brew2);
        //}

        //[Fact]
        //public void SelectBrewingSpell_MultipleHighestIncome_ReturnsCheapest()
        //{
        //    var brew1 = RecipeHelpers.MakeBrewRecipe(1, 5, 0, -1, -2, -1);
        //    var brew2 = RecipeHelpers.MakeBrewRecipe(2, 15, 0, -1, -2, -8);
        //    var brew3 = RecipeHelpers.MakeBrewRecipe(3, 10, 0, -1, -2, -1);
        //    var brew4 = RecipeHelpers.MakeBrewRecipe(4, 15, 0, -1, -2, -1);
        //    var brewRecipes = new List<Recipe> { brew1, brew2, brew3, brew4 };

        //    var result = _sut.SelectTargetBrewSpell(brewRecipes);

        //    result.Should().BeEquivalentTo(brew4);
        //}


    }
}
