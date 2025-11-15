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
            radioButton4 = new RadioButton();
            useMapButton = new RadioButton();
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            mapButton = new Button();
            mapDisplay = new Display();
            surfaceColorButton = new Button();
            lightColorButton = new Button();
            textureDisplay = new Display();
            loadTextureButton = new Button();
            fillBox = new CheckBox();
            meshBox = new CheckBox();
            controlNetBox = new CheckBox();
            animationBox = new CheckBox();
            lightAnimationBar = new TrackBar();
            label7 = new Label();
            mLabel = new Label();
            ksLabel = new Label();
            kdLabel = new Label();
            kdBar = new TrackBar();
            mBar = new TrackBar();
            ksBar = new TrackBar();
            vLabel = new Label();
            vBar = new TrackBar();
            uLabel = new Label();
            uBar = new TrackBar();
            betaLabel = new Label();
            betaBar = new TrackBar();
            alfaLabel = new Label();
            loadButton = new Button();
            alfaBar = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
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
            splitContainer1.Panel2.Controls.Add(radioButton4);
            splitContainer1.Panel2.Controls.Add(useMapButton);
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Panel2.Controls.Add(mapButton);
            splitContainer1.Panel2.Controls.Add(mapDisplay);
            splitContainer1.Panel2.Controls.Add(surfaceColorButton);
            splitContainer1.Panel2.Controls.Add(lightColorButton);
            splitContainer1.Panel2.Controls.Add(textureDisplay);
            splitContainer1.Panel2.Controls.Add(loadTextureButton);
            splitContainer1.Panel2.Controls.Add(fillBox);
            splitContainer1.Panel2.Controls.Add(meshBox);
            splitContainer1.Panel2.Controls.Add(controlNetBox);
            splitContainer1.Panel2.Controls.Add(animationBox);
            splitContainer1.Panel2.Controls.Add(lightAnimationBar);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(mLabel);
            splitContainer1.Panel2.Controls.Add(ksLabel);
            splitContainer1.Panel2.Controls.Add(kdLabel);
            splitContainer1.Panel2.Controls.Add(kdBar);
            splitContainer1.Panel2.Controls.Add(mBar);
            splitContainer1.Panel2.Controls.Add(ksBar);
            splitContainer1.Panel2.Controls.Add(vLabel);
            splitContainer1.Panel2.Controls.Add(vBar);
            splitContainer1.Panel2.Controls.Add(uLabel);
            splitContainer1.Panel2.Controls.Add(uBar);
            splitContainer1.Panel2.Controls.Add(betaLabel);
            splitContainer1.Panel2.Controls.Add(betaBar);
            splitContainer1.Panel2.Controls.Add(alfaLabel);
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
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Checked = true;
            radioButton4.Location = new Point(126, 509);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(64, 19);
            radioButton4.TabIndex = 31;
            radioButton4.TabStop = true;
            radioButton4.Text = "not use";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // useMapButton
            // 
            useMapButton.AutoSize = true;
            useMapButton.Location = new Point(126, 484);
            useMapButton.Name = "useMapButton";
            useMapButton.Size = new Size(70, 19);
            useMapButton.TabIndex = 30;
            useMapButton.Text = "use map";
            useMapButton.UseVisualStyleBackColor = true;
            useMapButton.CheckedChanged += useMapButton_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Location = new Point(159, 91);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(138, 38);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 13);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(63, 19);
            radioButton1.TabIndex = 24;
            radioButton1.Text = "Texture";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(75, 13);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(51, 19);
            radioButton2.TabIndex = 25;
            radioButton2.TabStop = true;
            radioButton2.Text = "Solid";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // mapButton
            // 
            mapButton.Location = new Point(126, 455);
            mapButton.Name = "mapButton";
            mapButton.Size = new Size(104, 23);
            mapButton.TabIndex = 29;
            mapButton.Text = "Load map";
            mapButton.UseVisualStyleBackColor = true;
            mapButton.Click += mapButton_Click;
            // 
            // mapDisplay
            // 
            mapDisplay.BackColor = SystemColors.ButtonFace;
            mapDisplay.Location = new Point(19, 455);
            mapDisplay.Name = "mapDisplay";
            mapDisplay.Size = new Size(89, 77);
            mapDisplay.TabIndex = 28;
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
            // textureDisplay
            // 
            textureDisplay.BackColor = SystemColors.ButtonFace;
            textureDisplay.Location = new Point(159, 164);
            textureDisplay.Name = "textureDisplay";
            textureDisplay.Size = new Size(63, 64);
            textureDisplay.TabIndex = 23;
            // 
            // loadTextureButton
            // 
            loadTextureButton.Location = new Point(160, 135);
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
            // mLabel
            // 
            mLabel.AutoSize = true;
            mLabel.Location = new Point(15, 329);
            mLabel.Name = "mLabel";
            mLabel.Size = new Size(18, 15);
            mLabel.TabIndex = 14;
            mLabel.Text = "m";
            // 
            // ksLabel
            // 
            ksLabel.AutoSize = true;
            ksLabel.Location = new Point(15, 284);
            ksLabel.Name = "ksLabel";
            ksLabel.Size = new Size(18, 15);
            ksLabel.TabIndex = 13;
            ksLabel.Text = "ks";
            // 
            // kdLabel
            // 
            kdLabel.AutoSize = true;
            kdLabel.Location = new Point(13, 236);
            kdLabel.Name = "kdLabel";
            kdLabel.Size = new Size(20, 15);
            kdLabel.TabIndex = 12;
            kdLabel.Text = "kd";
            // 
            // kdBar
            // 
            kdBar.Location = new Point(12, 254);
            kdBar.Maximum = 99;
            kdBar.Minimum = 1;
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
            ksBar.Maximum = 99;
            ksBar.Minimum = 1;
            ksBar.Name = "ksBar";
            ksBar.Size = new Size(121, 45);
            ksBar.TabIndex = 9;
            ksBar.TickFrequency = 5;
            ksBar.Value = 50;
            ksBar.ValueChanged += ksBar_ValueChanged;
            // 
            // vLabel
            // 
            vLabel.AutoSize = true;
            vLabel.Location = new Point(13, 185);
            vLabel.Name = "vLabel";
            vLabel.Size = new Size(13, 15);
            vLabel.TabIndex = 8;
            vLabel.Text = "v";
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
            // uLabel
            // 
            uLabel.AutoSize = true;
            uLabel.Location = new Point(12, 143);
            uLabel.Name = "uLabel";
            uLabel.Size = new Size(14, 15);
            uLabel.TabIndex = 6;
            uLabel.Text = "u";
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
            // betaLabel
            // 
            betaLabel.AutoSize = true;
            betaLabel.Location = new Point(13, 86);
            betaLabel.Name = "betaLabel";
            betaLabel.Size = new Size(30, 15);
            betaLabel.TabIndex = 4;
            betaLabel.Text = "beta";
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
            // alfaLabel
            // 
            alfaLabel.AutoSize = true;
            alfaLabel.Location = new Point(13, 38);
            alfaLabel.Name = "alfaLabel";
            alfaLabel.Size = new Size(26, 15);
            alfaLabel.TabIndex = 2;
            alfaLabel.Text = "alfa";
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private Label alfaLabel;
        private Label betaLabel;
        private TrackBar betaBar;
        private Label uLabel;
        private TrackBar uBar;
        private TrackBar vBar;
        private Label vLabel;
        private Label ksLabel;
        private Label kdLabel;
        private TrackBar kdBar;
        private TrackBar mBar;
        private TrackBar ksBar;
        private Label mLabel;
        private CheckBox animationBox;
        private TrackBar lightAnimationBar;
        private Label label7;
        private CheckBox controlNetBox;
        private CheckBox fillBox;
        private CheckBox meshBox;
        private Button loadTextureButton;
        private Display textureDisplay;
        private Button surfaceColorButton;
        private Button lightColorButton;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button mapButton;
        private Display mapDisplay;
        private RadioButton radioButton4;
        private RadioButton useMapButton;
        private GroupBox groupBox1;
    }
}
