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

        [TestCase(0xFF, 0, 0, 0)]
        [TestCase(0, 0xFF, 0, 0)]
        [TestCase(0, 0, 0xFF, 0)]
        [TestCase(0, 0, 0, 0xFF)]
        public void ShouldCreatePixel(byte a, byte r, byte g, byte b)
        {
            Pixel pixel = new Pixel(a, r, g, b);

            pixel.A.Should().Be(a);
            pixel.R.Should().Be(r);
            pixel.G.Should().Be(g);
            pixel.B.Should().Be(b);
        }

        [Test]
        public void ShouldEqualsReturnFalse()
        {
            Pixel blackA = new Pixel(255, 255, 255, 255);
            Pixel blackB = Pixel.Red;

            blackA.Equals(blackB).Should().BeFalse();

            blackB = new Pixel(255, 255, 120, 255);
            blackA.Equals(blackB).Should().BeFalse();
        }

        [Test]
        public void ShouldEqualsReturnTrue()
        {
            Pixel blackA = Pixel.Black;
            Pixel blackB = Pixel.Black;

            blackA.Equals(blackB).Should().BeTrue();
        }

        [Test]
        public void ShouldIsBlackOutReturnFalse()
        {
            new Pixel(0xFF, 1, 0, 0).IsBlackout.Should().BeFalse();
            new Pixel(0xFF, 0, 1, 0).IsBlackout.Should().BeFalse();
            new Pixel(0xFF, 0, 0, 1).IsBlackout.Should().BeFalse();
            new Pixel(0, 0, 0, 0).IsBlackout.Should().BeFalse();
        }

        [Test]
        public void ShouldIsBlackOutReturnTrue()
        {
            new Pixel(0xFF, 0, 0, 0).IsBlackout.Should().BeTrue();
        }
    }
}
