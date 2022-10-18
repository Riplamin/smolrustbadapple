using System;

namespace BadAppleTools.Library.Frame
{
    public class FrameRenderer
    {
        public readonly int Width;
        public readonly int Height;

        private FrameData? currentFrame;
        private readonly float[,] renderBuffer;

        public FrameRenderer(int width, int height)
        {
            Width = width;
            Height = height;

            renderBuffer = new float[Width, Height];
            BlankRenderBuffer();
        }

        private void BlankRenderBuffer()
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    renderBuffer[x, y] = 0.0f;
        }

        public void SetFrameData(FrameData frameData) =>
            currentFrame = frameData;

        public void RenderToBuffer()
        {
            if (currentFrame == null)
                return;

            int x = 0, y = 0;
            IBufferPosIncrementer incrementer = GetBufferPosIncrementer(currentFrame);
            int posInSection;
            float sectionIntensity;

            while (currentFrame.TryGetNextSection(out var frameSection))
            {
                if (frameSection != null && frameSection.Length > 0)
                {
                    posInSection = 0;
                    sectionIntensity = frameSection.Shade.GetIntensity();

                    do
                    {
                        try
                        {
                            renderBuffer[x, y] = sectionIntensity;
                        }
                        catch (IndexOutOfRangeException) { /* Eh, whatever... */ }

                        incrementer.Increment(ref x, ref y);
                    }
                    while (++posInSection < frameSection.Length);
                }
            }
        }

        public float[,] GetRenderBuffer() =>
            renderBuffer;

        private IBufferPosIncrementer GetBufferPosIncrementer(FrameData frameData)
        {
            if (frameData.Orientation == Orientations.Horizontal)
                return new HorizontalBufferPosIncrementer(Width);
            else
                return new VerticalBufferPosIncrementer(Height);
        }

        private interface IBufferPosIncrementer
        {
            void Increment(ref int x, ref int y);
        }

        private class HorizontalBufferPosIncrementer : IBufferPosIncrementer
        {
            private readonly int _width;

            public HorizontalBufferPosIncrementer(int width)
            {
                _width = width;
            }

            public void Increment(ref int x, ref int y)
            {
                if (++x >= _width)
                {
                    x = 0;
                    y++;
                }
            }
        }

        private class VerticalBufferPosIncrementer : IBufferPosIncrementer
        {
            private readonly int _height;

            public VerticalBufferPosIncrementer(int height)
            {
                _height = height;
            }

            public void Increment(ref int x, ref int y)
            {
                if (++y >= _height)
                {
                    y = 0;
                    x++;
                }
            }
        }
    }
}
