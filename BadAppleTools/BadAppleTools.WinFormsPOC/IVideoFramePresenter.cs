using BadAppleTools.Library.Frame;
using System;

namespace BadAppleTools.WinFormsPOC
{
    public interface IVideoFramePresenter
    {
        void PresentFrameData(FrameData frameData);
    }
}
