using BadAppleTools.Library.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadAppleTools.WinFormsPOC
{
    public partial class FrameRendererControl : UserControl
    {
        private FrameRenderer? frameRenderer;
        private float[,]? renderBuffer;

        private bool isTransparent = false;

        public FrameRendererControl()
        {
            InitializeComponent();
        }

        public void SetFrameRenderer(FrameRenderer frameRenderer) =>
            this.frameRenderer = frameRenderer;

        public void DrawFrame()
        {
            frameRenderer?.RenderToBuffer();
            renderBuffer = frameRenderer?.GetRenderBuffer();

            Refresh();
        }

        private void FrameRendererControl_Paint(object sender, PaintEventArgs e)
        {
            if (frameRenderer == null || renderBuffer == null)
            {
                if (isTransparent)
                {
                    BackColor = Color.Magenta;
                    isTransparent = false;
                }
                return;
            }
            
            if (!isTransparent)
            {
                BackColor = Color.Transparent;
                isTransparent = true;
            }

            if (Width != frameRenderer.Width || Height != frameRenderer.Height)
            {
                Size = new Size(frameRenderer.Width, frameRenderer.Height);
            }

            int pixelIntensity;
            Color pixelColor;
            using (Bitmap image = new(frameRenderer.Width, frameRenderer.Height))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    for (var y = 0; y < Height; y++)
                        for (var x = 0; x < Width; x++)
                        {
                            pixelIntensity = (int)(255 * renderBuffer[x, y]);
                            pixelColor = Color.FromArgb(pixelIntensity, pixelIntensity, pixelIntensity);
                            graphics.FillRectangle(new SolidBrush(pixelColor), x, y, 1, 1);
                        }
                }

                e.Graphics.DrawImageUnscaled(image, Point.Empty);
            }
        }
    }
}
