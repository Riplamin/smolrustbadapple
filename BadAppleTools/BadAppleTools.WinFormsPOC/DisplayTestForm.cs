using BadAppleTools.Library.Frame;
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
        private FrameRenderer frameRenderer;

        private static int WIDTH = 100, HEIGHT = 100;

        int totalLength = WIDTH * HEIGHT;

        int refreshMillis = 1000 / 15; // 16fps
        System.Windows.Forms.Timer refreshTimer;

        public DisplayTestForm()
        {
            InitializeComponent();
        }

        private void DisplayTestForm_Load(object sender, EventArgs e)
        {
            frameRenderer = new FrameRenderer(WIDTH, HEIGHT);

            FrameRendererControl.SetFrameRenderer(frameRenderer);

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Interval = refreshMillis;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            refreshTimer.Start();
            StartButton.Enabled = false;
        }

        private void RefreshTimer_Tick(object? sender, EventArgs e)
        {
            GenerateRandomFrame();
            FrameRendererControl.DrawFrame();
        }

        private void GenerateRandomFrame()
        {
            var frameSections = new List<FrameSection>();

            int filledLength = 0;
            var rng = new Random(DateTime.Now.Millisecond);

            var orientation = (Orientations)rng.Next(0, Enum.GetValues(typeof(Orientations)).Length);

            int sectionLength;
            Shades shade;
            do
            {
                sectionLength = Math.Min(rng.Next(5, 20), totalLength - filledLength);
                shade = (Shades)rng.Next(0, Enum.GetValues(typeof(Shades)).Length);

                frameSections.Add(
                    new()
                    {
                        Length = sectionLength,
                        Shade = shade
                    });

                filledLength += sectionLength;
            }
            while (filledLength < totalLength);

            frameRenderer.SetFrameData(
                new FrameData(
                    orientation,
                    frameSections));
        }
    }
}
