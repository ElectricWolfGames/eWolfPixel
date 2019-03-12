using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Project;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfPixelStandard.UnitTests.Helpers
{
    public class ItemHelperTests
    {
        [TestCase("anim", ItemTypes.Animation)]
        [TestCase("ANIM", ItemTypes.Animation)]
        [TestCase("BG", ItemTypes.BackGround)]
        [TestCase("other", ItemTypes.None)]
        [TestCase("Spr", ItemTypes.Sprite)]
        [TestCase("txt", ItemTypes.TextFile)]
        [TestCase("", ItemTypes.Folder)]
        public void ShouldFindItemType(string extension, ItemTypes expectedType)
        {
            ItemHelper.GetType(extension).Should().Be(expectedType);
        }

        [TestCase(ItemTypes.Animation, "anim")]
        [TestCase(ItemTypes.BackGround, "bg")]
        [TestCase(ItemTypes.Sprite, "spr")]
        [TestCase(ItemTypes.TextFile, "txt")]
        public void ShouldFindItemType(ItemTypes type, string expectedExtension)
        {
            ItemHelper.GetType(type).Should().Be(expectedExtension);
        }
    }
}
