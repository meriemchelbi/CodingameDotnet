//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;
//using FluentAssertions;
//using Codingame;

//namespace CodingameTests
//{
//    public class CellTests
//    {
//        [Fact]
//        public void FindNeighbours_FourNeighbours_PopulatesCellNeighbours()
//        {
//            var northNeighbour = new Cell(3, 6);
//            var southNeighbour = new Cell(3, 8);
//            var eastNeighbour = new Cell(4, 7);
//            var westNeighbour = new Cell(2, 7);
//            var sut = new Cell(3, 7);

//            var result = sut.Neighbours;

//            result.Should().NotBeNull();
//            result.Count.Should().Be(4);
//            result.Should().ContainEquivalentOf(northNeighbour);
//            result.Should().ContainEquivalentOf(southNeighbour);
//            result.Should().ContainEquivalentOf(eastNeighbour);
//            result.Should().ContainEquivalentOf(westNeighbour);
//        }
        
//        [Fact]
//        public void FindNeighbours_TwoNeighbours_PopulatesCellNeighbours()
//        {
//            var southNeighbour = new Cell(3, 8);
//            var westNeighbour = new Cell(2, 7);
//            var sut = new Cell(3, 7);

//            var result = sut.Neighbours;

//            result.Should().NotBeNull();
//            result.Count.Should().Be(2);
//            result.Should().ContainEquivalentOf(southNeighbour);
//            result.Should().ContainEquivalentOf(westNeighbour);
//        }
        
//        [Fact]
//        public void FindNeighbours_NoNeighbours_ReturnsEmptyNeighbours()
//        {
//            var sut = new Cell(3, 7);

//            var result = sut.Neighbours;

//            result.Should().NotBeNull();
//            result.Should().BeEmpty();
//        }
//    }
//}
