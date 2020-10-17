using Codingame;
using Xunit;

namespace CodingameTests
{
    public class ChuckNorrisTests
    {
        [Fact]
        public void SingleC()
        {
            var result = ChuckNorrisEncoder.Encode("C");

            Assert.Equal("0 0 00 0000 0 00", result);
        }
        
        [Fact]
        public void DoubleC()
        {
            var result = ChuckNorrisEncoder.Encode("CC");

            Assert.Equal("0 0 00 0000 0 000 00 0000 0 00", result);
        }
        
        [Fact]
        public void Percent()
        {
            var result = ChuckNorrisEncoder.Encode("%");

            Assert.Equal("00 0 0 0 00 00 0 0 00 0 0 0", result);
        }
    }
}
