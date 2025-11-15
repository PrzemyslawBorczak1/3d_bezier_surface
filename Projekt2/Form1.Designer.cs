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
            surfaceColorButton = new Button();
            lightColorButton = new Button();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            display1 = new Display();
            loadTextureButton = new Button();
            fillBox = new CheckBox();
            meshBox = new CheckBox();
            controlNetBox = new CheckBox();
            animationBox = new CheckBox();
            lightAnimationBar = new TrackBar();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            kd = new Label();
            kdBar = new TrackBar();
            mBar = new TrackBar();
            ksBar = new TrackBar();
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
            ((System.ComponentModel.ISupportInitialize)lightAnimationBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kdBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ksBar).BeginInit();
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
            splitContainer1.Panel2.BackColor = SystemColors.WindowFrame;
            splitContainer1.Panel2.Controls.Add(surfaceColorButton);
            splitContainer1.Panel2.Controls.Add(lightColorButton);
            splitContainer1.Panel2.Controls.Add(radioButton2);
            splitContainer1.Panel2.Controls.Add(radioButton1);
            splitContainer1.Panel2.Controls.Add(display1);
            splitContainer1.Panel2.Controls.Add(loadTextureButton);
            splitContainer1.Panel2.Controls.Add(fillBox);
            splitContainer1.Panel2.Controls.Add(meshBox);
            splitContainer1.Panel2.Controls.Add(controlNetBox);
            splitContainer1.Panel2.Controls.Add(animationBox);
            splitContainer1.Panel2.Controls.Add(lightAnimationBar);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(kd);
            splitContainer1.Panel2.Controls.Add(kdBar);
            splitContainer1.Panel2.Controls.Add(mBar);
            splitContainer1.Panel2.Controls.Add(ksBar);
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
            splitContainer1.SplitterDistance = 705;
            splitContainer1.TabIndex = 0;
            // 
            // surfaceCanvas1
            // 
            surfaceCanvas1.BackColor = SystemColors.ActiveCaptionText;
            surfaceCanvas1.Dock = DockStyle.Fill;
            surfaceCanvas1.Location = new Point(0, 0);
            surfaceCanvas1.Margin = new Padding(5, 6, 5, 6);
            surfaceCanvas1.Name = "surfaceCanvas1";
            surfaceCanvas1.Size = new Size(705, 544);
            surfaceCanvas1.TabIndex = 0;
            // 
            // surfaceColorButton
            // 
            surfaceColorButton.Location = new Point(159, 236);
            surfaceColorButton.Name = "surfaceColorButton";
            surfaceColorButton.Size = new Size(127, 23);
            surfaceColorButton.TabIndex = 27;
            surfaceColorButton.Text = "Surface Color";
            surfaceColorButton.UseVisualStyleBackColor = true;
            surfaceColorButton.Click += surfaceColorButton_Click;
            // 
            // lightColorButton
            // 
            lightColorButton.Location = new Point(160, 387);
            lightColorButton.Name = "lightColorButton";
            lightColorButton.Size = new Size(127, 23);
            lightColorButton.TabIndex = 26;
            lightColorButton.Text = "Light Color";
            lightColorButton.UseVisualStyleBackColor = true;
            lightColorButton.Click += lightColorButton_Click;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(236, 104);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(51, 19);
            radioButton2.TabIndex = 25;
            radioButton2.TabStop = true;
            radioButton2.Text = "Solid";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(159, 104);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(63, 19);
            radioButton1.TabIndex = 24;
            radioButton1.Text = "Texture";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // display1
            // 
            display1.BackColor = SystemColors.ButtonFace;
            display1.Location = new Point(159, 164);
            display1.Name = "display1";
            display1.Size = new Size(127, 64);
            display1.TabIndex = 23;
            // 
            // loadTextureButton
            // 
            loadTextureButton.Location = new Point(159, 135);
            loadTextureButton.Name = "loadTextureButton";
            loadTextureButton.Size = new Size(127, 23);
            loadTextureButton.TabIndex = 22;
            loadTextureButton.Text = "Load Texture";
            loadTextureButton.UseVisualStyleBackColor = true;
            loadTextureButton.Click += loadTextureButton_Click;
            // 
            // fillBox
            // 
            fillBox.AutoSize = true;
            fillBox.Checked = true;
            fillBox.CheckState = CheckState.Checked;
            fillBox.Location = new Point(159, 62);
            fillBox.Name = "fillBox";
            fillBox.Size = new Size(41, 19);
            fillBox.TabIndex = 20;
            fillBox.Text = "Fill";
            fillBox.UseVisualStyleBackColor = true;
            fillBox.CheckedChanged += fillBox_CheckedChanged;
            // 
            // meshBox
            // 
            meshBox.AutoSize = true;
            meshBox.Location = new Point(159, 37);
            meshBox.Name = "meshBox";
            meshBox.Size = new Size(85, 19);
            meshBox.TabIndex = 19;
            meshBox.Text = "Draw mesh";
            meshBox.UseVisualStyleBackColor = true;
            meshBox.CheckedChanged += meshBox_CheckedChanged;
            // 
            // controlNetBox
            // 
            controlNetBox.AutoSize = true;
            controlNetBox.Checked = true;
            controlNetBox.CheckState = CheckState.Checked;
            controlNetBox.Location = new Point(159, 15);
            controlNetBox.Name = "controlNetBox";
            controlNetBox.Size = new Size(114, 19);
            controlNetBox.TabIndex = 18;
            controlNetBox.Text = "Draw control net";
            controlNetBox.UseVisualStyleBackColor = true;
            controlNetBox.CheckedChanged += controlNetBox_CheckedChanged;
            // 
            // animationBox
            // 
            animationBox.AutoSize = true;
            animationBox.Location = new Point(217, 420);
            animationBox.Name = "animationBox";
            animationBox.Size = new Size(69, 19);
            animationBox.TabIndex = 17;
            animationBox.Text = "animate";
            animationBox.UseVisualStyleBackColor = true;
            // 
            // lightAnimationBar
            // 
            lightAnimationBar.Location = new Point(12, 416);
            lightAnimationBar.Name = "lightAnimationBar";
            lightAnimationBar.Size = new Size(196, 45);
            lightAnimationBar.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 398);
            label7.Name = "label7";
            label7.Size = new Size(96, 15);
            label7.TabIndex = 15;
            label7.Text = "Light Animation:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 329);
            label6.Name = "label6";
            label6.Size = new Size(18, 15);
            label6.TabIndex = 14;
            label6.Text = "m";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 284);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 13;
            label5.Text = "ks";
            // 
            // kd
            // 
            kd.AutoSize = true;
            kd.Location = new Point(13, 236);
            kd.Name = "kd";
            kd.Size = new Size(20, 15);
            kd.TabIndex = 12;
            kd.Text = "kd";
            // 
            // kdBar
            // 
            kdBar.Location = new Point(12, 254);
            kdBar.Maximum = 100;
            kdBar.Name = "kdBar";
            kdBar.Size = new Size(124, 45);
            kdBar.SmallChange = 10;
            kdBar.TabIndex = 11;
            kdBar.TickFrequency = 5;
            kdBar.Value = 50;
            kdBar.ValueChanged += kdBar_ValueChanged;
            // 
            // mBar
            // 
            mBar.Location = new Point(7, 350);
            mBar.Minimum = 1;
            mBar.Name = "mBar";
            mBar.Size = new Size(130, 45);
            mBar.TabIndex = 10;
            mBar.Value = 1;
            mBar.ValueChanged += mBar_ValueChanged;
            // 
            // ksBar
            // 
            ksBar.Location = new Point(12, 299);
            ksBar.Maximum = 100;
            ksBar.Name = "ksBar";
            ksBar.Size = new Size(121, 45);
            ksBar.TabIndex = 9;
            ksBar.TickFrequency = 5;
            ksBar.Value = 50;
            ksBar.ValueChanged += ksBar_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 185);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 8;
            label4.Text = "v";
            // 
            // vBar
            // 
            vBar.Location = new Point(13, 203);
            vBar.Maximum = 100;
            vBar.Minimum = 2;
            vBar.Name = "vBar";
            vBar.Size = new Size(124, 45);
            vBar.TabIndex = 7;
            vBar.TickFrequency = 2;
            vBar.Value = 5;
            vBar.ValueChanged += precisionV_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 143);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 6;
            label3.Text = "u";
            // 
            // uBar
            // 
            uBar.Location = new Point(13, 155);
            uBar.Maximum = 100;
            uBar.Minimum = 2;
            uBar.Name = "uBar";
            uBar.Size = new Size(124, 45);
            uBar.TabIndex = 5;
            uBar.TickFrequency = 2;
            uBar.Value = 5;
            uBar.ValueChanged += precisionU_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 86);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 4;
            label2.Text = "beta";
            // 
            // betaBar
            // 
            betaBar.Location = new Point(13, 104);
            betaBar.Maximum = 100;
            betaBar.Minimum = 2;
            betaBar.Name = "betaBar";
            betaBar.Size = new Size(123, 45);
            betaBar.TabIndex = 3;
            betaBar.TickFrequency = 5;
            betaBar.Value = 2;
            betaBar.ValueChanged += betaBar_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 38);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 2;
            label1.Text = "alfa";
            // 
            // loadButton
            // 
            loadButton.Location = new Point(13, 12);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(75, 23);
            loadButton.TabIndex = 1;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // alfaBar
            // 
            alfaBar.Location = new Point(13, 56);
            alfaBar.Maximum = 90;
            alfaBar.Minimum = 2;
            alfaBar.Name = "alfaBar";
            alfaBar.Size = new Size(124, 45);
            alfaBar.TabIndex = 0;
            alfaBar.TickFrequency = 5;
            alfaBar.Value = 2;
            alfaBar.ValueChanged += alfaBar_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1018, 544);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lightAnimationBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)kdBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)mBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ksBar).EndInit();
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
        private Label label5;
        private Label kd;
        private TrackBar kdBar;
        private TrackBar mBar;
        private TrackBar ksBar;
        private Label label6;
        private CheckBox animationBox;
        private TrackBar lightAnimationBar;
        private Label label7;
        private CheckBox controlNetBox;
        private CheckBox fillBox;
        private CheckBox meshBox;
        private Button loadTextureButton;
        private Display display1;
        private Button surfaceColorButton;
        private Button lightColorButton;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}
