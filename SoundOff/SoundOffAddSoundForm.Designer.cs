namespace SoundOff
{
    partial class SoundOffAddSoundForm
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
            SoundLabelTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SoundFileLocationText = new TextBox();
            LocateSoundFileLocationButton = new Button();
            ClearSoundFileLocationButton = new Button();
            SoundNumeric = new NumericUpDown();
            label3 = new Label();
            SendSoundToMainButton = new Button();
            ((System.ComponentModel.ISupportInitialize)SoundNumeric).BeginInit();
            SuspendLayout();
            // 
            // SoundLabelTextBox
            // 
            SoundLabelTextBox.Location = new Point(12, 46);
            SoundLabelTextBox.Name = "SoundLabelTextBox";
            SoundLabelTextBox.Size = new Size(271, 23);
            SoundLabelTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(152, 25);
            label1.TabIndex = 1;
            label1.Text = "Set Sound Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(208, 25);
            label2.TabIndex = 3;
            label2.Text = "Set Sound File Location";
            // 
            // SoundFileLocationText
            // 
            SoundFileLocationText.Enabled = false;
            SoundFileLocationText.Location = new Point(12, 114);
            SoundFileLocationText.Name = "SoundFileLocationText";
            SoundFileLocationText.Size = new Size(271, 23);
            SoundFileLocationText.TabIndex = 2;
            // 
            // LocateSoundFileLocationButton
            // 
            LocateSoundFileLocationButton.Location = new Point(12, 143);
            LocateSoundFileLocationButton.Name = "LocateSoundFileLocationButton";
            LocateSoundFileLocationButton.Size = new Size(135, 23);
            LocateSoundFileLocationButton.TabIndex = 4;
            LocateSoundFileLocationButton.Text = "Locate your Sound";
            LocateSoundFileLocationButton.UseVisualStyleBackColor = true;
            LocateSoundFileLocationButton.Click += LocateSoundFileLocationButton_Click;
            // 
            // ClearSoundFileLocationButton
            // 
            ClearSoundFileLocationButton.Location = new Point(148, 143);
            ClearSoundFileLocationButton.Name = "ClearSoundFileLocationButton";
            ClearSoundFileLocationButton.Size = new Size(135, 23);
            ClearSoundFileLocationButton.TabIndex = 5;
            ClearSoundFileLocationButton.Text = "Clear Selected Sound";
            ClearSoundFileLocationButton.UseVisualStyleBackColor = true;
            ClearSoundFileLocationButton.Click += ClearSoundFileLocationButton_Click;
            // 
            // SoundNumeric
            // 
            SoundNumeric.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SoundNumeric.Location = new Point(12, 210);
            SoundNumeric.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            SoundNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            SoundNumeric.Name = "SoundNumeric";
            SoundNumeric.Size = new Size(47, 29);
            SoundNumeric.TabIndex = 6;
            SoundNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 182);
            label3.Name = "label3";
            label3.Size = new Size(216, 25);
            label3.TabIndex = 7;
            label3.Text = "Set Sound Number (1-9)";
            // 
            // SendSoundToMainButton
            // 
            SendSoundToMainButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SendSoundToMainButton.Location = new Point(12, 250);
            SendSoundToMainButton.Name = "SendSoundToMainButton";
            SendSoundToMainButton.Size = new Size(271, 43);
            SendSoundToMainButton.TabIndex = 8;
            SendSoundToMainButton.Text = "Set New Sound to SoundOff";
            SendSoundToMainButton.UseVisualStyleBackColor = true;
            SendSoundToMainButton.Click += SendSoundToMainButton_Click;
            // 
            // SoundOffAddSoundForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 305);
            Controls.Add(SendSoundToMainButton);
            Controls.Add(label3);
            Controls.Add(SoundNumeric);
            Controls.Add(ClearSoundFileLocationButton);
            Controls.Add(LocateSoundFileLocationButton);
            Controls.Add(label2);
            Controls.Add(SoundFileLocationText);
            Controls.Add(label1);
            Controls.Add(SoundLabelTextBox);
            Name = "SoundOffAddSoundForm";
            Text = "SoundOffAddSoundForm";
            ((System.ComponentModel.ISupportInitialize)SoundNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SoundLabelTextBox;
        private Label label1;
        private Label label2;
        private TextBox SoundFileLocationText;
        private Button LocateSoundFileLocationButton;
        private Button ClearSoundFileLocationButton;
        private NumericUpDown SoundNumeric;
        private Label label3;
        private Button SendSoundToMainButton;
    }
}