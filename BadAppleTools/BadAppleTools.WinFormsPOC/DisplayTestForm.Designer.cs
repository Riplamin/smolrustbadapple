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
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FrameRendererControl
            // 
            this.FrameRendererControl.BackColor = System.Drawing.Color.Magenta;
            this.FrameRendererControl.Location = new System.Drawing.Point(12, 47);
            this.FrameRendererControl.Name = "FrameRendererControl";
            this.FrameRendererControl.Size = new System.Drawing.Size(188, 188);
            this.FrameRendererControl.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 29);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // DisplayTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.FrameRendererControl);
            this.Name = "DisplayTestForm";
            this.Text = "DisplayTestForm";
            this.Load += new System.EventHandler(this.DisplayTestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FrameRendererControl FrameRendererControl;
        private Button StartButton;
    }
}