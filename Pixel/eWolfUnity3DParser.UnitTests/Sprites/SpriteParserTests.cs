using eWolfUnity3DParser.Sprites;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfUnity3DParser.UnitTests.Sprites
{
    public class SpriteParserTests
    {
        [Test]
        public void ReadSpriteFile()
        {
            string rawFile = Helpers.Helpers.LoadFile(@"Player04.png.meta");
            SpriteSheetData spriteSheetData = SpriteParser.Parse(rawFile);
            spriteSheetData.FileFormatVersion.Should().Be("2");
            spriteSheetData.FileGuid.Should().Be("9a3cf21915996f441b213e88de546e32");
        }
    }
}