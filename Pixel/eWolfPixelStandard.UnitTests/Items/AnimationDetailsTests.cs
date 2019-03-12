using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using eWolfPixelStandard.Items;

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
