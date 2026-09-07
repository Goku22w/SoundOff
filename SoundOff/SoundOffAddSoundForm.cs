using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SoundOff
{
    public partial class SoundOffAddSoundForm : Form
    {
        public SoundOffAddSoundForm()
        {
            InitializeComponent();
        }

        private void LocateAndCopySound()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.ogg;*.flac;*.aac;*.wma|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var sourcePath = openFileDialog.FileName;
                    try
                    {
                        // Determine target folder next to the executable
                        var soundsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds Folder");
                        if (!Directory.Exists(soundsFolder))
                        {
                            Directory.CreateDirectory(soundsFolder);
                        }

                        var fileName = Path.GetFileName(sourcePath);
                        var destPath = Path.Combine(soundsFolder, fileName);

                        // If a file with the same name exists, generate a unique filename
                        if (File.Exists(destPath))
                        {
                            var nameOnly = Path.GetFileNameWithoutExtension(fileName);
                            var ext = Path.GetExtension(fileName);
                            int copyIndex = 1;
                            string candidate;
                            do
                            {
                                candidate = Path.Combine(soundsFolder, $"{nameOnly} ({copyIndex}){ext}");
                                copyIndex++;
                            } while (File.Exists(candidate));
                            destPath = candidate;
                        }

                        File.Copy(sourcePath, destPath);

                        // Store the copied file path in the UI
                        SoundFileLocationText.Text = destPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, $"Failed to copy sound file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SoundFileLocationText.Text = sourcePath; // fallback to original
                    }
                }
            }
        }

        public void AddToMainForm(string soundName, string soundFilePath, int soundNumber)
        {
            // Validate sound number (we only have 1-9 slots)
            if (soundNumber < 1 || soundNumber > 9) return;

            // Try to find the main form instance
            SoundOffMainForm? mainForm = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f is SoundOffMainForm)
                {
                    mainForm = (SoundOffMainForm)f;
                    break;
                }
            }
            if (mainForm == null && this.Owner is SoundOffMainForm ownerForm)
            {
                mainForm = ownerForm;
            }
            if (mainForm == null) return;

            try
            {
                var soundLabelName = $"Sound{soundNumber}";
                var soundFileLabelName = $"SoundFile{soundNumber}";

                // Find the controls by name (works even if the designer fields are private)
                var soundLabelObj = mainForm.Controls.Find(soundLabelName, true);
                var soundFileLabelObj = mainForm.Controls.Find(soundFileLabelName, true);

                if (soundLabelObj != null && soundLabelObj.Length > 0 && soundLabelObj[0] is Label soundLabel)
                {
                    // Show and set the display name; keep the numeric prefix
                    soundLabel.Show();
                    soundLabel.Text = $"{soundNumber}: {soundName}";
                }

                if (soundFileLabelObj != null && soundFileLabelObj.Length > 0 && soundFileLabelObj[0] is Label soundFileLabel)
                {
                    // Keep the full path hidden from the UI and store it in the Tag
                    soundFileLabel.Tag = soundFilePath;
                    // Optionally show only the file name if you ever make the label visible
                    try
                    {
                        soundFileLabel.Text = Path.GetFileName(soundFilePath);
                    }
                    catch
                    {
                        soundFileLabel.Text = string.Empty;
                    }
                    // Ensure the label remains hidden in the main UI
                    soundFileLabel.Hide();
                }
            }
            catch
            {
                // Silent fail - do not crash the add-sound dialog if main form manipulation fails
            }
        }

        private void LocateSoundFileLocationButton_Click(object sender, EventArgs e)
        {
            LocateAndCopySound();
        }

        private void ClearSoundFileLocationButton_Click(object sender, EventArgs e)
        {
            SoundFileLocationText.Text = string.Empty;
        }

        private void SendSoundToMainButton_Click(object sender, EventArgs e)
        {
            AddToMainForm(SoundLabelTextBox.Text, SoundFileLocationText.Text, (int)SoundNumeric.Value);
            this.Close();
        }
    }
}
