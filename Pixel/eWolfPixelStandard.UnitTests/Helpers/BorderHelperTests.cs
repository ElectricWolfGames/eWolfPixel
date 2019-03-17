using eWolfPixelStandard.Data;
using eWolfPixelStandard.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfPixelStandard.UnitTests.Helpers
{
    public class BorderHelperTests
    {
        [Test]
        public void ShouldAddBlackBorder()
        {
            PixelSet ps = new PixelSet(5, 5);
            ps.Pixels[2, 2] = Pixel.Red;
            BorderHelper.ApplyBlack(ps);

            ps.Pixels[2, 2].Should().Be(Pixel.Red);
            ps.Pixels[1, 2].Should().Be(Pixel.Black);
            ps.Pixels[3, 2].Should().Be(Pixel.Black);
            ps.Pixels[2, 1].Should().Be(Pixel.Black);
            ps.Pixels[2, 3].Should().Be(Pixel.Black);
        }

        [Test]
        public void ShouldAddBlackBorderFarSide()
        {
            PixelSet ps = new PixelSet(5, 5);
            ps.Pixels[2, 4] = Pixel.Red;
            BorderHelper.ApplyBlack(ps);

            ps.Pixels[2, 4].Should().Be(Pixel.Red);
            ps.Pixels[1, 4].Should().Be(Pixel.Black);
            ps.Pixels[3, 4].Should().Be(Pixel.Black);
            ps.Pixels[2, 3].Should().Be(Pixel.Black);
        }

        [Test]
        public void ShouldAddBlackBorderNearSide()
        {
            PixelSet ps = new PixelSet(5, 5);
            ps.Pixels[2, 0] = Pixel.Red;
            BorderHelper.ApplyBlack(ps);

            ps.Pixels[2, 0].Should().Be(Pixel.Red);
            ps.Pixels[1, 0].Should().Be(Pixel.Black);
            ps.Pixels[3, 0].Should().Be(Pixel.Black);
            ps.Pixels[2, 1].Should().Be(Pixel.Black);
        }
    }
}
