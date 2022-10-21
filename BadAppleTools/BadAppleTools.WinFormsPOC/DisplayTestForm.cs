using BadAppleTools.Library.Frame;
using BadAppleTools.Library.Video;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadAppleTools.WinFormsPOC
{
    public partial class DisplayTestForm : Form
    {
        Video? generatedVideo;
        private FrameRenderer? frameRenderer;
        private VideoFramePresenter? videoFramePresenter;
        private VideoPlayer? videoPlayer;

        public DisplayTestForm()
        {
            InitializeComponent();
        }

        private void GenerateVideoButton_Click(object sender, EventArgs e)
        {
            var videoGenerator = new VideoGenerator();
            generatedVideo = videoGenerator.Generate();

            if (generatedVideo?.Manifest != null && generatedVideo?.Frames != null)
            {
                frameRenderer = new FrameRenderer(
                    generatedVideo.Manifest.Width,
                    generatedVideo.Manifest.Height);

                FrameRendererControl.SetFrameRenderer(frameRenderer);
                videoFramePresenter = new VideoFramePresenter(frameRenderer, FrameRendererControl);

                UpdateLabels();

                PlayButton.Enabled = true;
            }

            GenerateVideoButton.Enabled = false;
        }

        private void UpdateLabels()
        {
            if (generatedVideo?.Manifest == null || generatedVideo?.Frames == null)
                return;

            FramesPerSecondLabel.Text =
                            FramesPerSecondLabel.Text.Replace("...", generatedVideo.Manifest.FramesPerSecond.ToString());

            WidthLabel.Text =
                WidthLabel.Text.Replace("...", generatedVideo.Manifest.Width.ToString());

            HeightLabel.Text =
                HeightLabel.Text.Replace("...", generatedVideo.Manifest.Height.ToString());

            FrameCountLabel.Text =
                FrameCountLabel.Text.Replace("...", generatedVideo.Frames.Length.ToString());
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (generatedVideo == null || videoFramePresenter == null)
                return;

            videoPlayer = new VideoPlayer(generatedVideo, videoFramePresenter);
            videoPlayer.PlayVideoAsync();

            PlayButton.Enabled = false;
        }
    }
}
