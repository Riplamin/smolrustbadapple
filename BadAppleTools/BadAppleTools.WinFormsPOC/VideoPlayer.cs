using BadAppleTools.Library.Video;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadAppleTools.WinFormsPOC
{
    public class VideoPlayer
    {
        private readonly Video _video;
        private readonly IVideoFramePresenter _videoFramePresenter;

        private int frameIndex = 0;

        public VideoPlayer(
            Video video,
            IVideoFramePresenter videoFramePresenter)
        {
            _video = video;
            _videoFramePresenter = videoFramePresenter;
        }

        public async void PlayVideoAsync()
        {
            await PlayVideoTask();
        }

        // TODO: This Task should have a cancellation token implementation somewhere so that the video can be stopped/paused
        private async Task PlayVideoTask()
        {
            if (_video?.Manifest == null || _video?.Frames == null)
                return;

            if (frameIndex >= _video.Frames.Length - 1)
                frameIndex = 0;

            Stopwatch stopwatch;
            while (frameIndex < _video.Frames.Length)
            {
                stopwatch = Stopwatch.StartNew();

                _videoFramePresenter?.PresentFrameData(_video.Frames[frameIndex]);
                frameIndex++;

                var remainingMillis =
                    (int)(1000f / _video.Manifest.FramesPerSecond) - (int)stopwatch.ElapsedMilliseconds;

                await Task.Delay(Math.Max(0, remainingMillis));
            }

            Debug.WriteLine("Finished Playing");
        }
    }
}
