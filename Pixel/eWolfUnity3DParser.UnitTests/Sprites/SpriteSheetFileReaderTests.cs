using eWolfUnity3DParser.Sprites;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfUnity3DParser.UnitTests.Sprites
{
    public class SpriteSheetFileReaderTests
    {
        [Test]
        public void ShouldReadLines()
        {
            string rawFile = "a\nb\nc";
            SpriteSheetFileReader spriteSheetFileReader = new SpriteSheetFileReader(rawFile);
            spriteSheetFileReader.ReadLine().Should().Be("a");
            spriteSheetFileReader.ReadLine().Should().Be("b");
            spriteSheetFileReader.ReadLine().Should().Be("c");
        }
    }
}