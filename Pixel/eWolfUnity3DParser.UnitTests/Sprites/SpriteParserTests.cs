using eWolfUnity3DParser.Sprites;
using eWolfUnity3DParser.Sprites.Data;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfUnity3DParser.UnitTests.Sprites
{
    public class SpriteParserTests
    {
        [Test]
        public void ShouldCreateSprite()
        {
            string rawFile = Helpers.Helpers.LoadFile(@"Player04.png.meta");
            SpriteSheetData spriteSheetData = SpriteParser.Parse(rawFile);
            spriteSheetData.SpritesMap.Should().HaveCount(64);

            SpriteData sd = spriteSheetData.SpritesMap["PL04_Left_Walk0"];
            sd.Name.Should().Be("PL04_Left_Walk0");
            sd.SpriteID.Should().Be("2f9a5b012f5af2747902bba879ef1838");
            sd.Alignment.Should().Be(7);

            sd = spriteSheetData.SpritesMap["PL04_DownLeft_ATTSwipe1"];
            sd.Name.Should().Be("PL04_DownLeft_ATTSwipe1");
            sd.SpriteID.Should().Be("a358f9531f7322f4881de90b59bd397d");
            sd.Alignment.Should().Be(9);
        }

        [Test]
        public void ShouldMapSpriteNames()
        {
            string rawFile = Helpers.Helpers.LoadFile(@"Player04.png.meta");
            SpriteSheetData spriteSheetData = SpriteParser.Parse(rawFile);
            spriteSheetData.NamesMap.Should().HaveCount(66);
            spriteSheetData.NamesMap["21300000"].Should().Be("PL04_Left_Walk0");
            spriteSheetData.NamesMap["21300022"].Should().Be("PL04_DownRight_Walk0");
        }

        [Test]
        public void ShouldPopulatePivot()
        {
            string rawFile = Helpers.Helpers.LoadFile(@"Player04.png.meta");
            SpriteSheetData spriteSheetData = SpriteParser.Parse(rawFile);
            SpriteData sd = spriteSheetData.SpritesMap["PL04_Left_Walk0"];

            sd.Pivot.X.Should().Be(0.5f);
            sd.Pivot.Y.Should().Be(0);
        }

        [Test]
        public void ShouldPopulateRect()
        {
            string rawFile = Helpers.Helpers.LoadFile(@"Player04.png.meta");
            SpriteSheetData spriteSheetData = SpriteParser.Parse(rawFile);
            SpriteData sd = spriteSheetData.SpritesMap["PL04_Left_Walk0"];

            sd.Rect.X.Should().Be(5);
            sd.Rect.Y.Should().Be(473);
            sd.Rect.Width.Should().Be(10);
            sd.Rect.Height.Should().Be(35);
        }

        [Test]
        public void ShouldReadSpriteSheetFile()
        {
            string rawFile = Helpers.Helpers.LoadFile(@"Player04.png.meta");
            SpriteSheetData spriteSheetData = SpriteParser.Parse(rawFile);
            spriteSheetData.FileFormatVersion.Should().Be("2");
            spriteSheetData.FileGuid.Should().Be("9a3cf21915996f441b213e88de546e32");
        }
    }
}