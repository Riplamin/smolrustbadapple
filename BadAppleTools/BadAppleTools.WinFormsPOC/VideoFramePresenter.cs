using BadAppleTools.Library.Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadAppleTools.WinFormsPOC
{
    public class VideoFramePresenter : IVideoFramePresenter
    {
        private readonly FrameRenderer? _frameRenderer;
        private readonly IRenderedFrameUpdate? _renderedFrameUpdate;
        
        public VideoFramePresenter(
            FrameRenderer frameRenderer,
            IRenderedFrameUpdate renderedFrameUpdate)
        {
            _frameRenderer = frameRenderer;
            _renderedFrameUpdate = renderedFrameUpdate;
        }

        public void PresentFrameData(FrameData frameData)
        {
            if (_frameRenderer == null || _renderedFrameUpdate == null)
                return;

            _frameRenderer.SetFrameData(frameData);
            _frameRenderer.RenderToBuffer();
            _renderedFrameUpdate.NewFrameRendered();
        }
    }
}
