using eWolfPixelStandard.Data;
using eWolfPixelStandard.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfPixelStandard.UnitTests.Helpers
{
    public class Directions8WayHelperTests
    {
        [TestCase(0, 0, Directions8Way.UpLeft)]
        [TestCase(1, 0, Directions8Way.Up)]
        [TestCase(2, 0, Directions8Way.UpRight)]
        [TestCase(0, 1, Directions8Way.Left)]
        [TestCase(2, 1, Directions8Way.Right)]
        [TestCase(0, 2, Directions8Way.DownLeft)]
        [TestCase(1, 2, Directions8Way.Down)]
        [TestCase(2, 2, Directions8Way.DownRight)]
        public void ShouldGetDirection(int x, int y, Directions8Way expectedDir)
        {
            Directions8WayHelper.GetDirectionFromGrid(x, y).Should().Be(expectedDir);
        }

        [TestCase(Directions8Way.Up, 0)]
        [TestCase(Directions8Way.Down, 4)]
        [TestCase(Directions8Way.Right, 2)]
        [TestCase(Directions8Way.Left, 6)]
        public void ShouldGetDirection(Directions8Way dir, int index)
        {
            Directions8WayHelper.GetDirectionIndex(dir).Should().Be(index);
        }
    }
}
