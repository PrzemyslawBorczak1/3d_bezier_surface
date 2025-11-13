namespace Projekt2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            surfaceCanvas1 = new surfaceCanvas();
            label4 = new Label();
            vBar = new TrackBar();
            label3 = new Label();
            uBar = new TrackBar();
            label2 = new Label();
            betaBar = new TrackBar();
            label1 = new Label();
            loadButton = new Button();
            alfaBar = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alfaBar).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(surfaceCanvas1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(74, 144, 226);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(vBar);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(uBar);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(betaBar);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(loadButton);
            splitContainer1.Panel2.Controls.Add(alfaBar);
            splitContainer1.Size = new Size(1018, 544);
            splitContainer1.SplitterDistance = 706;
            splitContainer1.TabIndex = 0;
            // 
            // surfaceCanvas1
            // 
            surfaceCanvas1.Dock = DockStyle.Fill;
            surfaceCanvas1.Location = new Point(0, 0);
            surfaceCanvas1.Name = "surfaceCanvas1";
            surfaceCanvas1.Size = new Size(706, 544);
            surfaceCanvas1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 432);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 8;
            label4.Text = "v";
            // 
            // vBar
            // 
            vBar.Location = new Point(17, 449);
            vBar.Maximum = 100;
            vBar.Minimum = 4;
            vBar.Name = "vBar";
            vBar.Size = new Size(279, 45);
            vBar.TabIndex = 7;
            vBar.TickFrequency = 2;
            vBar.Value = 4;
            vBar.ValueChanged += precisionV_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 368);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 6;
            label3.Text = "u";
            // 
            // uBar
            // 
            uBar.Location = new Point(13, 386);
            uBar.Maximum = 100;
            uBar.Minimum = 4;
            uBar.Name = "uBar";
            uBar.Size = new Size(295, 45);
            uBar.TabIndex = 5;
            uBar.TickFrequency = 2;
            uBar.Value = 5;
            uBar.ValueChanged += precisionU_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 238);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 4;
            label2.Text = "beta";
            // 
            // betaBar
            // 
            betaBar.Location = new Point(13, 256);
            betaBar.Maximum = 100;
            betaBar.Minimum = 2;
            betaBar.Name = "betaBar";
            betaBar.Size = new Size(295, 45);
            betaBar.TabIndex = 3;
            betaBar.TickFrequency = 5;
            betaBar.Value = 2;
            betaBar.ValueChanged += betaBar_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 133);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 2;
            label1.Text = "alfa";
            // 
            // loadButton
            // 
            loadButton.Location = new Point(27, 27);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(75, 23);
            loadButton.TabIndex = 1;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // alfaBar
            // 
            alfaBar.Location = new Point(13, 151);
            alfaBar.Maximum = 90;
            alfaBar.Minimum = 2;
            alfaBar.Name = "alfaBar";
            alfaBar.Size = new Size(308, 45);
            alfaBar.TabIndex = 0;
            alfaBar.TickFrequency = 5;
            alfaBar.Value = 2;
            alfaBar.ValueChanged += alfaBar_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 544);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)vBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)uBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)betaBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)alfaBar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private surfaceCanvas surfaceCanvas1;
        private Button loadButton;
        private TrackBar alfaBar;
        private Label label1;
        private Label label2;
        private TrackBar betaBar;
        private Label label3;
        private TrackBar uBar;
        private TrackBar vBar;
        private Label label4;
    }
}
