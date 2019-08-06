using eWolfPixelCommon.Data;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfPixelCommon.UnitTests.Data
{
    public class PixelTests
    {
        [Test]
        public void ShouldCreateBlackPixel()
        {
            Pixel black = Pixel.Black;

            black.A.Should().Be(0xFF);
            black.R.Should().Be(0);
            black.G.Should().Be(0);
            black.B.Should().Be(0);
        }
    }
}
