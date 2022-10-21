using BadAppleTools.Library.Frame;
using BadAppleTools.Library.Video;
using System;

namespace BadAppleTools.WinFormsPOC
{
    public class VideoGenerator
    {
        private const int FRAMES_PER_SECOND = 144;
        private const int WIDTH = 100;
        private const int HEIGHT = 75;

        private int fillLength = (WIDTH * HEIGHT) + 1;

        public Video Generate() =>
            new Video()
            {
                Manifest = new()
                {
                    FramesPerSecond = FRAMES_PER_SECOND,
                    Width = WIDTH,
                    Height = HEIGHT
                },
                Frames = GenerateFrames()
            };

        private FrameData[] GenerateFrames()
        {
            var frames = new List<FrameData>();

            frames.AddRange(GenerateFramesForShade(Shades.Gray, Shades.Black));
            frames.AddRange(GenerateFramesForShade(Shades.White, Shades.Gray));

            return frames.ToArray();
        }

        private List<FrameData> GenerateFramesForShade(Shades preceedingShade, Shades followingShade)
        {
            var frames = new List<FrameData>();

            for (var i = 0; i < fillLength; i++)
            {
                frames.Add(
                    new FrameData(
                        Orientations.Horizontal,
                        new List<FrameSection>
                        {
                            new FrameSection() { Shade = preceedingShade, Length = i },
                            new FrameSection() { Shade = followingShade, Length = fillLength - i }
                        }));
            }

            return frames;
        }
    }
}
