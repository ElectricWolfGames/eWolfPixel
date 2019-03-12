using eWolfPixelStandard.Items;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfPixelStandard.UnitTests.Items
{
    public class AnimationDetailsTests
    {
        [TestCase("A", "B", @"B\A")]
        [TestCase("walkTest", "FirstChar", @"FirstChar\walkTest")]
        public void ShouldFullPath(string name, string path, string expectedFullPath)
        {
            AnimationDetails ad = new AnimationDetails(name, path);
            ad.FullPath.Should().Be(expectedFullPath);
        }
    }
}
