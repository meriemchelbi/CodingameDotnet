using Codingame;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingameTests
{
    public class GameTests
    {
        private readonly Game _sut;
        private readonly Recipe _brew47;
        private readonly Recipe _brew49;
        private readonly Recipe _brew50;
        private readonly Recipe _brew54;
        private readonly Recipe _brew65;
        private readonly Recipe _cast78;
        private readonly Recipe _cast79;
        private readonly Recipe _cast80;
        private readonly Recipe _cast82;

        public GameTests()
        {
            _sut = new Game();
            _brew47 = RecipeHelpers.MakeBrewRecipe(47, 0, -3, -2, 0, 0);
            _brew49 = RecipeHelpers.MakeBrewRecipe(49, 0, 0, 0, -5, 0);
            _brew50 = RecipeHelpers.MakeBrewRecipe(50, 0, -2, 0, 0, -2);
            _brew54 = RecipeHelpers.MakeBrewRecipe(54, 0, 0, 0, -2, -2);
            _brew65 = RecipeHelpers.MakeBrewRecipe(65, 0, 0, 0, 0, -5);
            _cast78 = RecipeHelpers.MakeCastRecipe(78, 2, 0, 0, 0);
            _cast79 = RecipeHelpers.MakeCastRecipe(79, -1, 1, 0, 0);
            _cast80 = RecipeHelpers.MakeCastRecipe(80, 0, -1, 1, 0);
            _cast82 = RecipeHelpers.MakeCastRecipe(82, 2, 0, 0, 0);
        }


        [Fact]
        public void DecideAction_BREW_Cookable_IssuesBrewInstruction()
        {
            _cast78.IsCastable = true;
            _sut.Me.Inventory = new int[] { 2, 0, 5, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew49, _brew54, _cast78 };

            var result = _sut.DecideAction();

            result.Should().Be("BREW 49");
        }
        
        [Fact]
        public void DecideAction_BREW_NotCookable_DoesNotIssueBrewInstruction()
        {
            _cast78.IsCastable = true;
            _sut.Me.Inventory = new int[] { 2, 0, 5, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast78 };

            var result = _sut.DecideAction();

            result.Should().NotContain("BREW");
        }
        
        [Fact]
        public void DecideAction_CAST_Cookable_Castable_IssuesCastInstruction()
        {
            _cast78.IsCastable = true;
            _sut.Me.Inventory = new int[] { 2, 0, 5, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast78, _cast80 };

            var result = _sut.DecideAction();

            result.Should().Be("CAST 78");
        }
        
        [Fact]
        public void DecideAction_NoCookable_AllCastable_IssuesWaitInstruction()
        {
            _cast79.IsCastable = true;
            _cast80.IsCastable = true;

            _sut.Me.Inventory = new int[] { 0, 0, 0, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast79, _cast80 };

            var result = _sut.DecideAction();

            result.Should().Be("WAIT");
        }
        
        [Fact]
        public void DecideAction_NoCastable_IssuesRestInstruction()
        {
            _sut.Me.Inventory = new int[] { 0, 0, 0, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast78, _cast79, _cast80 };

            var result = _sut.DecideAction();

            result.Should().Be("REST");
        }
        
        [Fact]
        public void DecideAction_SomeCastableButNotCookable_IssuesRestInstruction()
        {
            _cast79.IsCastable = true;

            _sut.Me.Inventory = new int[] { 0, 0, 0, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast78, _cast79, _cast80 };

            var result = _sut.DecideAction();

            result.Should().Be("REST");
        }
        
        [Fact]
        public void DecideAction_SomeFreeLearnable_IssuesLearnInstruction()
        {
            _cast79.IsCastable = true;
            var costlyLearn = RecipeHelpers.MakeLearnRecipe(1, 0, -3, 2, 1);
            var freeLearn = RecipeHelpers.MakeLearnRecipe(2, 0, 1, 2, 1);

            _sut.Me.Inventory = new int[] { 5, 0, 0, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, costlyLearn, freeLearn, _cast78, _cast79, _cast80 };

            var result = _sut.DecideAction();

            result.Should().Contain("LEARN");
        }
        
        [Fact]
        public void DecideAction_NoCheapFreeLearnable_DoesntIssueLearnInstruction()
        {
            _cast79.IsCastable = true;
            var costlyLearn1 = RecipeHelpers.MakeLearnRecipe(1, 0, -3, 2, 1);
            var costlyLearn2 = RecipeHelpers.MakeLearnRecipe(2, -2, 1, 2, -1);

            _sut.Me.Inventory = new int[] { 5, 0, 0, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, costlyLearn1, costlyLearn2, _cast78, _cast79, _cast80 };

            var result = _sut.DecideAction();

            result.Should().NotContain("LEARN");
        }
    }
}
