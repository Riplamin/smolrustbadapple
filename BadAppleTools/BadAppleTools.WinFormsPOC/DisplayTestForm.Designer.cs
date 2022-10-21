namespace BadAppleTools.WinFormsPOC
{
    partial class DisplayTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FrameRendererControl = new BadAppleTools.WinFormsPOC.FrameRendererControl();
            this.GenerateVideoButton = new System.Windows.Forms.Button();
            this.FramesPerSecondLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.FrameCountLabel = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FrameRendererControl
            // 
            this.FrameRendererControl.BackColor = System.Drawing.Color.Magenta;
            this.FrameRendererControl.Location = new System.Drawing.Point(12, 190);
            this.FrameRendererControl.Name = "FrameRendererControl";
            this.FrameRendererControl.Size = new System.Drawing.Size(188, 188);
            this.FrameRendererControl.TabIndex = 0;
            // 
            // GenerateVideoButton
            // 
            this.GenerateVideoButton.Location = new System.Drawing.Point(12, 12);
            this.GenerateVideoButton.Name = "GenerateVideoButton";
            this.GenerateVideoButton.Size = new System.Drawing.Size(156, 29);
            this.GenerateVideoButton.TabIndex = 1;
            this.GenerateVideoButton.Text = "Generate Video";
            this.GenerateVideoButton.UseVisualStyleBackColor = true;
            this.GenerateVideoButton.Click += new System.EventHandler(this.GenerateVideoButton_Click);
            // 
            // FramesPerSecondLabel
            // 
            this.FramesPerSecondLabel.AutoSize = true;
            this.FramesPerSecondLabel.Location = new System.Drawing.Point(12, 44);
            this.FramesPerSecondLabel.Name = "FramesPerSecondLabel";
            this.FramesPerSecondLabel.Size = new System.Drawing.Size(149, 20);
            this.FramesPerSecondLabel.TabIndex = 2;
            this.FramesPerSecondLabel.Text = "Frames Per Second: ...";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(12, 64);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(65, 20);
            this.WidthLabel.TabIndex = 3;
            this.WidthLabel.Text = "Width: ...";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(12, 84);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(70, 20);
            this.HeightLabel.TabIndex = 4;
            this.HeightLabel.Text = "Height: ...";
            // 
            // FrameCountLabel
            // 
            this.FrameCountLabel.AutoSize = true;
            this.FrameCountLabel.Location = new System.Drawing.Point(12, 104);
            this.FrameCountLabel.Name = "FrameCountLabel";
            this.FrameCountLabel.Size = new System.Drawing.Size(109, 20);
            this.FrameCountLabel.TabIndex = 5;
            this.FrameCountLabel.Text = "Frame Count: ...";
            // 
            // PlayButton
            // 
            this.PlayButton.Enabled = false;
            this.PlayButton.Location = new System.Drawing.Point(12, 155);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(94, 29);
            this.PlayButton.TabIndex = 6;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // DisplayTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.FrameCountLabel);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.FramesPerSecondLabel);
            this.Controls.Add(this.GenerateVideoButton);
            this.Controls.Add(this.FrameRendererControl);
            this.Name = "DisplayTestForm";
            this.Text = "DisplayTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrameRendererControl FrameRendererControl;
        private Button GenerateVideoButton;
        private Label FramesPerSecondLabel;
        private Label WidthLabel;
        private Label HeightLabel;
        private Label FrameCountLabel;
        private Button PlayButton;
    }
}