using eWolfUnity3DParser.Sprites;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace eWolfUnity3DParser.UnitTests.Sprites
{
    public class SpriteSheetDataTests
    {
        [Test]
        public void ShouldGetAnimationFramesDownRight()
        {
            string rawFile = Helpers.Helpers.LoadFile(@"Player04.png.meta");
            SpriteSheetData spriteSheetData = SpriteParser.Parse(rawFile);
            List<string> frames = spriteSheetData.GetAnimationFrames("PL04_DownRight_Walk").ToList();

            frames.Should().HaveCount(3);
            frames[0].Should().Be("PL04_DownRight_Walk0");
            frames[1].Should().Be("PL04_DownRight_Walk1");
            frames[2].Should().Be("PL04_DownRight_Walk2");
        }

        [Test]
        public void ShouldGetAnimationFramesATTStab()
        {
            string rawFile = Helpers.Helpers.LoadFile(@"Player04.png.meta");
            SpriteSheetData spriteSheetData = SpriteParser.Parse(rawFile);
            List<string> frames = spriteSheetData.GetAnimationFrames("PL04_UpLeft_ATTStab").ToList();

            frames.Should().HaveCount(2);
            frames[0].Should().Be("PL04_UpLeft_ATTStab1");
            frames[1].Should().Be("PL04_UpLeft_ATTStab2");
        }
    }
}