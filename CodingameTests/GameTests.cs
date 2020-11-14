using Codingame;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingameTests
{
    public class GameTests
    {
        private readonly Game _sut;
        private readonly Recipe _brew42;
        private readonly Recipe _brew47;
        private readonly Recipe _brew58;
        private readonly Recipe _brew56;
        private readonly Recipe _brew64;
        private readonly Recipe _brew49;
        private readonly Recipe _brew50;
        private readonly Recipe _brew54;
        private readonly Recipe _brew57;
        private readonly Recipe _brew65;
        private readonly Recipe _cast78;
        private readonly Recipe _cast79;
        private readonly Recipe _cast80;
        private readonly Recipe _cast82;
        private readonly Recipe _cast83;
        private readonly Recipe _cast84;
        private readonly Recipe _cast85;
        private readonly Recipe _brew55;
        private readonly Recipe _brew68;

        public GameTests()
        {
            _sut = new Game();
            _brew42 = RecipeHelpers.MakeBrewRecipe(42, 7, -2, -2, 0, 0);
            _brew47 = RecipeHelpers.MakeBrewRecipe(47, 0, -3, -2, 0, 0);
            _brew49 = RecipeHelpers.MakeBrewRecipe(49, 10, 0, -5, 0, 0);
            _brew50 = RecipeHelpers.MakeBrewRecipe(50, 0, -2, 0, 0, -2);
            _brew54 = RecipeHelpers.MakeBrewRecipe(54, 0, 0, -2, 0, -2);
            _brew55 = RecipeHelpers.MakeBrewRecipe(55, 13, 0, -3, -2, 0);
            _brew56 = RecipeHelpers.MakeBrewRecipe(56, 13, 0, -2, -3, 0);
            _brew57 = RecipeHelpers.MakeBrewRecipe(57, 17, 0, 0, -2, -2);
            _brew58 = RecipeHelpers.MakeBrewRecipe(58, 14, -3, 0, -2, 0);
            _brew64 = RecipeHelpers.MakeBrewRecipe(64, 18, 0, 0, -2, -3);
            _brew65 = RecipeHelpers.MakeBrewRecipe(65, 0, 0, 0, 0, -5);
            _brew68 = RecipeHelpers.MakeBrewRecipe(68, 12, -1, 0, -2, -1);
            _cast78 = RecipeHelpers.MakeCastRecipe(78, 2, 0, 0, 0);
            _cast79 = RecipeHelpers.MakeCastRecipe(79, -1, 1, 0, 0);
            _cast80 = RecipeHelpers.MakeCastRecipe(80, 0, -1, 1, 0);
            _cast82 = RecipeHelpers.MakeCastRecipe(82, 2, 0, 0, 0);
            _cast83 = RecipeHelpers.MakeCastRecipe(83, -1, 1, 0, 0);
            _cast84 = RecipeHelpers.MakeCastRecipe(84, 0, -1, 1, 0);
            _cast85 = RecipeHelpers.MakeCastRecipe(85, 0, 0, -1, 1);
        }


        [Fact]
        public void DecideAction_BREW_Cookable_IssuesBrewInstruction()
        {
            _cast78.IsCastable = true;
            _sut.Me.Inventory = new List<int> { 2, 5, 0, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew49, _brew54, _cast78 };

            var result = _sut.DecideAction();

            result.Should().Be("BREW 49");
        }
        
        [Fact]
        public void DecideAction_BREW_NotCookable_DoesNotIssueBrewInstruction()
        {
            _cast78.IsCastable = true;
            _sut.Me.Inventory = new List<int> { 2, 0, 5, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast78 };

            var result = _sut.DecideAction();

            result.Should().NotContain("BREW");
        }
        
        [Fact]
        public void DecideAction_CAST_Cookable_Castable_IssuesCastInstruction()
        {
            _cast78.IsCastable = true;
            _sut.Me.Inventory = new List<int> { 2, 0, 5, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast78, _cast80 };

            var result = _sut.DecideAction();

            result.Should().Be("CAST 78");
        }
        
        [Fact]
        public void DecideAction_NoCookable_AllCastable_IssuesWaitInstruction()
        {
            _cast79.IsCastable = true;
            _cast80.IsCastable = true;

            _sut.Me.Inventory = new List<int> { 0, 0, 0, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast79, _cast80 };

            var result = _sut.DecideAction();

            result.Should().Be("WAIT");
        }
        
        [Fact]
        public void DecideAction_NoCastable_IssuesRestInstruction()
        {
            _sut.Me.Inventory = new List<int> { 0, 0, 0, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast78, _cast79, _cast80 };

            var result = _sut.DecideAction();

            result.Should().Be("REST");
        }
        
        [Fact]
        public void DecideAction_SomeCastableButNotCookable_IssuesRestInstruction()
        {
            _cast79.IsCastable = true;

            _sut.Me.Inventory = new List<int> { 0, 0, 0, 0 };
            _sut.Recipes = new List<Recipe> { _brew47, _brew54, _cast78, _cast79, _cast80 };

            var result = _sut.DecideAction();

            result.Should().Be("REST");
        }

        [Fact]
        public void DecideAction_CastTargetsMostAchievableBrewWithHighestPrice()
        {
            _cast82.IsCastable = true;
            _cast83.IsCastable = true;
            _cast84.IsCastable = true;
            _cast85.IsCastable = true;

            _sut.Me.Inventory = new List<int> { 4, 0, 0, 1 };
            _sut.Recipes = new List<Recipe> { _brew54, _brew55, _brew68, _brew58, _brew49, _cast82, _cast83, _cast84, _cast85 };

            var result = _sut.DecideAction();

            result.Should().Be("CAST 83");
        }
    }
}
