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
        public void SelectCast_LastItemHighest_SelectsCast0()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 1, 1, 1, 7 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast0);
        }
        
        [Fact]
        public void SelectCast_FirstItemHighest_SelectsCast1()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 8, 0, 4, 3 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast1);
        }
        
        [Fact]
        public void SelectCast_SecondItemHighest_SelectsCast2()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 2, 7, 0, 3 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast2);
        }
        
        [Fact]
        public void SelectCast_ThirdItemHighest_SelectsCast3()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 1, 1, 5, 1 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast3);
        }
        
        [Fact]
        public void SelectCast_NoItems_SelectsCast0()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 0, 0, 0, 0 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast0);
        }
        
        [Fact]
        public void SelectCast_NoItems_Cast0NotAvailable_SelectsFirstAvailable()
        {
            var casts = new List<Recipe> { _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 0, 0, 0, 0 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast1);
        }
        
        [Fact]
        public void SelectCast_NoItemHighest_FirstItemLowest_SelectsCast0()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 0, 1, 1, 1 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast0);
        }
        
        [Fact]
        public void SelectCast_NoItemHighest_SecondItemLowest_SelectsCast1()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 1, 0, 1, 1 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast1);
        }
        
        [Fact]
        public void SelectCast_NoItemHighest_ThirdItemLowest_SelectsCast2()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 1, 1, 0, 1 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast2);
        }
        
        [Fact]
        public void SelectCast_NoItemHighest_LastItemLowest_SelectsCast3()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 1, 1, 1, 0 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast3);
        }
        
        [Fact]
        public void SelectCast_Cast0Available_LastItemEqual7_FirstItemEqual0_SelectsCast0()
        {
            var casts = new List<Recipe> { _cast0, _cast1, _cast2, _cast3 };
            var inventory = new List<int> { 0, 1, 0, 7 };

            var result = _sut.SelectCast(casts, inventory);

            result.Should().BeEquivalentTo(_cast0);
        }
    }
}
