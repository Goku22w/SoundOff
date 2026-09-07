using System.Windows.Forms.Design;

namespace SoundOff
{
    partial class SoundOffMainForm
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SoundOutputBox = new ListBox();
            SoundOutputNumeric = new NumericUpDown();
            SetOutputButton = new Button();
            SaveSoundPresetButton = new Button();
            LoadSoundPresetButton = new Button();
            OpenNewSoundFormButton = new Button();
            Sound1 = new Label();
            Sound2 = new Label();
            Sound3 = new Label();
            Sound4 = new Label();
            Sound5 = new Label();
            Sound6 = new Label();
            Sound7 = new Label();
            Sound8 = new Label();
            Sound9 = new Label();
            SoundFile9 = new Label();
            SoundFile5 = new Label();
            SoundFile6 = new Label();
            SoundFile7 = new Label();
            SoundFile8 = new Label();
            SoundFile3 = new Label();
            SoundFile4 = new Label();
            SoundFile2 = new Label();
            SoundFile1 = new Label();
            VolumeBar = new NAudio.Gui.VolumeSlider();
            SetVolumeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)SoundOutputNumeric).BeginInit();
            SuspendLayout();
            // 
            // SoundOutputBox
            // 
            SoundOutputBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SoundOutputBox.FormattingEnabled = true;
            SoundOutputBox.Location = new Point(447, 12);
            SoundOutputBox.Name = "SoundOutputBox";
            SoundOutputBox.Size = new Size(215, 349);
            SoundOutputBox.TabIndex = 0;
            // 
            // SoundOutputNumeric
            // 
            SoundOutputNumeric.Location = new Point(447, 367);
            SoundOutputNumeric.Name = "SoundOutputNumeric";
            SoundOutputNumeric.Size = new Size(56, 23);
            SoundOutputNumeric.TabIndex = 1;
            // 
            // SetOutputButton
            // 
            SetOutputButton.Location = new Point(509, 367);
            SetOutputButton.Name = "SetOutputButton";
            SetOutputButton.Size = new Size(153, 23);
            SetOutputButton.TabIndex = 2;
            SetOutputButton.Text = "Set SoundOff's Output";
            SetOutputButton.UseVisualStyleBackColor = true;
            SetOutputButton.Click += SetOutputButton_Click;
            // 
            // SaveSoundPresetButton
            // 
            SaveSoundPresetButton.Location = new Point(447, 396);
            SaveSoundPresetButton.Name = "SaveSoundPresetButton";
            SaveSoundPresetButton.Size = new Size(98, 42);
            SaveSoundPresetButton.TabIndex = 3;
            SaveSoundPresetButton.Text = "Save Preset";
            SaveSoundPresetButton.UseVisualStyleBackColor = true;
            // 
            // LoadSoundPresetButton
            // 
            LoadSoundPresetButton.Location = new Point(564, 396);
            LoadSoundPresetButton.Name = "LoadSoundPresetButton";
            LoadSoundPresetButton.Size = new Size(98, 42);
            LoadSoundPresetButton.TabIndex = 4;
            LoadSoundPresetButton.Text = "Load Preset";
            LoadSoundPresetButton.UseVisualStyleBackColor = true;
            // 
            // OpenNewSoundFormButton
            // 
            OpenNewSoundFormButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OpenNewSoundFormButton.Location = new Point(366, 367);
            OpenNewSoundFormButton.Name = "OpenNewSoundFormButton";
            OpenNewSoundFormButton.Size = new Size(75, 71);
            OpenNewSoundFormButton.TabIndex = 5;
            OpenNewSoundFormButton.Text = "Add New Sound";
            OpenNewSoundFormButton.UseVisualStyleBackColor = true;
            OpenNewSoundFormButton.Click += OpenNewSoundFormButton_Click;
            // 
            // Sound1
            // 
            Sound1.AutoSize = true;
            Sound1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            Sound1.Location = new Point(12, 12);
            Sound1.Name = "Sound1";
            Sound1.Size = new Size(35, 37);
            Sound1.TabIndex = 6;
            Sound1.Text = "1:";
            // 
            // Sound2
            // 
            Sound2.AutoSize = true;
            Sound2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            Sound2.Location = new Point(12, 49);
            Sound2.Name = "Sound2";
            Sound2.Size = new Size(39, 37);
            Sound2.TabIndex = 7;
            Sound2.Text = "2:";
            // 
            // Sound3
            // 
            Sound3.AutoSize = true;
            Sound3.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            Sound3.Location = new Point(12, 86);
            Sound3.Name = "Sound3";
            Sound3.Size = new Size(39, 37);
            Sound3.TabIndex = 9;
            Sound3.Text = "3:";
            // 
            // Sound4
            // 
            Sound4.AutoSize = true;
            Sound4.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            Sound4.Location = new Point(12, 123);
            Sound4.Name = "Sound4";
            Sound4.Size = new Size(40, 37);
            Sound4.TabIndex = 8;
            Sound4.Text = "4:";
            // 
            // Sound5
            // 
            Sound5.AutoSize = true;
            Sound5.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            Sound5.Location = new Point(12, 160);
            Sound5.Name = "Sound5";
            Sound5.Size = new Size(39, 37);
            Sound5.TabIndex = 13;
            Sound5.Text = "5:";
            // 
            // Sound6
            // 
            Sound6.AutoSize = true;
            Sound6.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            Sound6.Location = new Point(12, 197);
            Sound6.Name = "Sound6";
            Sound6.Size = new Size(39, 37);
            Sound6.TabIndex = 12;
            Sound6.Text = "6:";
            // 
            // Sound7
            // 
            Sound7.AutoSize = true;
            Sound7.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            Sound7.Location = new Point(13, 234);
            Sound7.Name = "Sound7";
            Sound7.Size = new Size(38, 37);
            Sound7.TabIndex = 11;
            Sound7.Text = "7:";
            // 
            // Sound8
            // 
            Sound8.AutoSize = true;
            Sound8.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            Sound8.Location = new Point(13, 271);
            Sound8.Name = "Sound8";
            Sound8.Size = new Size(39, 37);
            Sound8.TabIndex = 10;
            Sound8.Text = "8:";
            // 
            // Sound9
            // 
            Sound9.AutoSize = true;
            Sound9.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            Sound9.Location = new Point(13, 308);
            Sound9.Name = "Sound9";
            Sound9.Size = new Size(39, 37);
            Sound9.TabIndex = 14;
            Sound9.Text = "9:";
            // 
            // SoundFile9
            // 
            SoundFile9.AutoSize = true;
            SoundFile9.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            SoundFile9.Location = new Point(351, 308);
            SoundFile9.Name = "SoundFile9";
            SoundFile9.RightToLeft = RightToLeft.Yes;
            SoundFile9.Size = new Size(90, 37);
            SoundFile9.TabIndex = 23;
            SoundFile9.Text = "label9";
            SoundFile9.TextAlign = ContentAlignment.TopRight;
            // 
            // SoundFile5
            // 
            SoundFile5.AutoSize = true;
            SoundFile5.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            SoundFile5.Location = new Point(350, 160);
            SoundFile5.Name = "SoundFile5";
            SoundFile5.RightToLeft = RightToLeft.Yes;
            SoundFile5.Size = new Size(90, 37);
            SoundFile5.TabIndex = 22;
            SoundFile5.Text = "label5";
            SoundFile5.TextAlign = ContentAlignment.TopRight;
            // 
            // SoundFile6
            // 
            SoundFile6.AutoSize = true;
            SoundFile6.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            SoundFile6.Location = new Point(350, 197);
            SoundFile6.Name = "SoundFile6";
            SoundFile6.RightToLeft = RightToLeft.Yes;
            SoundFile6.Size = new Size(90, 37);
            SoundFile6.TabIndex = 21;
            SoundFile6.Text = "label6";
            SoundFile6.TextAlign = ContentAlignment.TopRight;
            // 
            // SoundFile7
            // 
            SoundFile7.AutoSize = true;
            SoundFile7.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            SoundFile7.Location = new Point(351, 234);
            SoundFile7.Name = "SoundFile7";
            SoundFile7.RightToLeft = RightToLeft.Yes;
            SoundFile7.Size = new Size(89, 37);
            SoundFile7.TabIndex = 20;
            SoundFile7.Text = "label7";
            SoundFile7.TextAlign = ContentAlignment.TopRight;
            // 
            // SoundFile8
            // 
            SoundFile8.AutoSize = true;
            SoundFile8.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            SoundFile8.Location = new Point(351, 271);
            SoundFile8.Name = "SoundFile8";
            SoundFile8.RightToLeft = RightToLeft.Yes;
            SoundFile8.Size = new Size(90, 37);
            SoundFile8.TabIndex = 19;
            SoundFile8.Text = "label8";
            SoundFile8.TextAlign = ContentAlignment.TopRight;
            // 
            // SoundFile3
            // 
            SoundFile3.AutoSize = true;
            SoundFile3.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            SoundFile3.Location = new Point(350, 86);
            SoundFile3.Name = "SoundFile3";
            SoundFile3.RightToLeft = RightToLeft.Yes;
            SoundFile3.Size = new Size(90, 37);
            SoundFile3.TabIndex = 18;
            SoundFile3.Text = "label3";
            SoundFile3.TextAlign = ContentAlignment.TopRight;
            // 
            // SoundFile4
            // 
            SoundFile4.AutoSize = true;
            SoundFile4.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            SoundFile4.Location = new Point(350, 123);
            SoundFile4.Name = "SoundFile4";
            SoundFile4.RightToLeft = RightToLeft.Yes;
            SoundFile4.Size = new Size(91, 37);
            SoundFile4.TabIndex = 17;
            SoundFile4.Text = "label4";
            SoundFile4.TextAlign = ContentAlignment.TopRight;
            // 
            // SoundFile2
            // 
            SoundFile2.AutoSize = true;
            SoundFile2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            SoundFile2.Location = new Point(350, 49);
            SoundFile2.Name = "SoundFile2";
            SoundFile2.RightToLeft = RightToLeft.Yes;
            SoundFile2.Size = new Size(90, 37);
            SoundFile2.TabIndex = 16;
            SoundFile2.Text = "label2";
            SoundFile2.TextAlign = ContentAlignment.TopRight;
            // 
            // SoundFile1
            // 
            SoundFile1.AutoSize = true;
            SoundFile1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            SoundFile1.Location = new Point(350, 12);
            SoundFile1.Name = "SoundFile1";
            SoundFile1.RightToLeft = RightToLeft.Yes;
            SoundFile1.Size = new Size(86, 37);
            SoundFile1.TabIndex = 15;
            SoundFile1.Text = "label1";
            SoundFile1.TextAlign = ContentAlignment.TopRight;
            // 
            // VolumeBar
            // 
            VolumeBar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            VolumeBar.Location = new Point(13, 396);
            VolumeBar.Name = "VolumeBar";
            VolumeBar.Size = new Size(148, 32);
            VolumeBar.TabIndex = 26;
            // 
            // SetVolumeButton
            // 
            SetVolumeButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SetVolumeButton.Location = new Point(167, 394);
            SetVolumeButton.Name = "SetVolumeButton";
            SetVolumeButton.Size = new Size(98, 34);
            SetVolumeButton.TabIndex = 27;
            SetVolumeButton.Text = "Set Volume";
            SetVolumeButton.UseVisualStyleBackColor = true;
            SetVolumeButton.Click += SetVolumeButton_Click;
            // 
            // SoundOffMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 450);
            Controls.Add(SetVolumeButton);
            Controls.Add(SoundOutputBox);
            Controls.Add(VolumeBar);
            Controls.Add(SoundFile9);
            Controls.Add(SoundFile5);
            Controls.Add(SoundFile6);
            Controls.Add(SoundFile7);
            Controls.Add(SoundFile8);
            Controls.Add(SoundFile3);
            Controls.Add(SoundFile4);
            Controls.Add(SoundFile2);
            Controls.Add(SoundFile1);
            Controls.Add(Sound9);
            Controls.Add(Sound5);
            Controls.Add(Sound6);
            Controls.Add(Sound7);
            Controls.Add(Sound8);
            Controls.Add(Sound3);
            Controls.Add(Sound4);
            Controls.Add(Sound2);
            Controls.Add(Sound1);
            Controls.Add(OpenNewSoundFormButton);
            Controls.Add(LoadSoundPresetButton);
            Controls.Add(SaveSoundPresetButton);
            Controls.Add(SetOutputButton);
            Controls.Add(SoundOutputNumeric);
            Name = "SoundOffMainForm";
            Text = "SoundOff";
            Load += SoundOffMainForm_Load;
            ((System.ComponentModel.ISupportInitialize)SoundOutputNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox SoundOutputBox;
        private NumericUpDown SoundOutputNumeric;
        private Button SetOutputButton;
        private Button SaveSoundPresetButton;
        private Button LoadSoundPresetButton;
        private Button OpenNewSoundFormButton;
        private Label Sound1;
        private Label Sound2;
        private Label Sound3;
        private Label Sound4;
        private Label Sound5;
        private Label Sound6;
        private Label Sound7;
        private Label Sound8;
        private Label Sound9;
        private Label SoundFile9;
        private Label SoundFile5;
        private Label SoundFile6;
        private Label SoundFile7;
        private Label SoundFile8;
        private Label SoundFile3;
        private Label SoundFile4;
        private Label SoundFile2;
        private Label SoundFile1;
        private NAudio.Gui.VolumeSlider VolumeBar;
        private Button SetVolumeButton;
    }
}
