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
            splitContainer1.Margin = new Padding(5, 6, 5, 6);
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
            splitContainer1.Size = new Size(1745, 1088);
            splitContainer1.SplitterDistance = 1210;
            splitContainer1.SplitterWidth = 7;
            splitContainer1.TabIndex = 0;
            // 
            // surfaceCanvas1
            // 
            surfaceCanvas1.Dock = DockStyle.Fill;
            surfaceCanvas1.Location = new Point(0, 0);
            surfaceCanvas1.Margin = new Padding(9, 12, 9, 12);
            surfaceCanvas1.Name = "surfaceCanvas1";
            surfaceCanvas1.Size = new Size(1210, 1088);
            surfaceCanvas1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 864);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(23, 30);
            label4.TabIndex = 8;
            label4.Text = "v";
            // 
            // vBar
            // 
            vBar.Location = new Point(29, 898);
            vBar.Margin = new Padding(5, 6, 5, 6);
            vBar.Minimum = 2;
            vBar.Name = "vBar";
            vBar.Size = new Size(478, 80);
            vBar.TabIndex = 7;
            vBar.TickFrequency = 2;
            vBar.Value = 4;
            vBar.ValueChanged += precisionV_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 736);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(25, 30);
            label3.TabIndex = 6;
            label3.Text = "u";
            // 
            // uBar
            // 
            uBar.Location = new Point(22, 772);
            uBar.Margin = new Padding(5, 6, 5, 6);
            uBar.Minimum = 2;
            uBar.Name = "uBar";
            uBar.Size = new Size(506, 80);
            uBar.TabIndex = 5;
            uBar.TickFrequency = 2;
            uBar.Value = 5;
            uBar.ValueChanged += precisionU_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 476);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 30);
            label2.TabIndex = 4;
            label2.Text = "beta";
            // 
            // betaBar
            // 
            betaBar.Location = new Point(22, 512);
            betaBar.Margin = new Padding(5, 6, 5, 6);
            betaBar.Maximum = 100;
            betaBar.Minimum = 2;
            betaBar.Name = "betaBar";
            betaBar.Size = new Size(506, 80);
            betaBar.TabIndex = 3;
            betaBar.TickFrequency = 5;
            betaBar.Value = 2;
            betaBar.ValueChanged += betaBar_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 266);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 30);
            label1.TabIndex = 2;
            label1.Text = "alfa";
            // 
            // loadButton
            // 
            loadButton.Location = new Point(46, 54);
            loadButton.Margin = new Padding(5, 6, 5, 6);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(129, 46);
            loadButton.TabIndex = 1;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // alfaBar
            // 
            alfaBar.Location = new Point(22, 302);
            alfaBar.Margin = new Padding(5, 6, 5, 6);
            alfaBar.Maximum = 90;
            alfaBar.Minimum = 2;
            alfaBar.Name = "alfaBar";
            alfaBar.Size = new Size(528, 80);
            alfaBar.TabIndex = 0;
            alfaBar.TickFrequency = 5;
            alfaBar.Value = 2;
            alfaBar.ValueChanged += alfaBar_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1745, 1088);
            Controls.Add(splitContainer1);
            Margin = new Padding(5, 6, 5, 6);
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
