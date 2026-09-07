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
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            // 
            // ClearSoundFileLocationButton
            // 
            ClearSoundFileLocationButton.Location = new Point(148, 143);
            ClearSoundFileLocationButton.Name = "ClearSoundFileLocationButton";
            ClearSoundFileLocationButton.Size = new Size(135, 23);
            ClearSoundFileLocationButton.TabIndex = 5;
            ClearSoundFileLocationButton.Text = "Clear Selected Sound";
            ClearSoundFileLocationButton.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDown1.Location = new Point(12, 210);
            numericUpDown1.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(47, 29);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 250);
            button1.Name = "button1";
            button1.Size = new Size(271, 43);
            button1.TabIndex = 8;
            button1.Text = "Set New Sound to SoundOff";
            button1.UseVisualStyleBackColor = true;
            // 
            // SoundOffAddSoundForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 305);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(ClearSoundFileLocationButton);
            Controls.Add(LocateSoundFileLocationButton);
            Controls.Add(label2);
            Controls.Add(SoundFileLocationText);
            Controls.Add(label1);
            Controls.Add(SoundLabelTextBox);
            Name = "SoundOffAddSoundForm";
            Text = "SoundOffAddSoundForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Button button1;
    }
}