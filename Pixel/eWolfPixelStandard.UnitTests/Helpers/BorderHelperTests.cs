using eWolfPixelStandard.Data;
using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Items;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
