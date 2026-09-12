using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Text.Json;
namespace SoundOff
{
    public partial class SoundOffMainForm : Form
    {
        public SoundOffMainForm()
        {
            InitializeComponent();
        }
        private IWavePlayer outputDevice;
        private AudioFileReader audioFile;
        private int selectedOutputIndex = 0; // 0 = default
        private List<MMDevice> availableMmDevices = new List<MMDevice>();

        private record PresetEntry(int Number, string? Name, string? Path);
        private record SoundPreset(List<PresetEntry> Entries, int SelectedOutput, float Volume);

        // Global hotkey constants/interop
        private const int WM_HOTKEY = 0x0312;
        private const uint MOD_NONE = 0x0000;
        private const uint VK_NUMPAD0 = 0x60;
        private const uint VK_NUMPAD1 = 0x61;
        private const uint VK_NUMPAD2 = 0x62;
        private const uint VK_NUMPAD3 = 0x63;
        private const uint VK_NUMPAD4 = 0x64;
        private const uint VK_NUMPAD5 = 0x65;
        private const uint VK_NUMPAD6 = 0x66;
        private const uint VK_NUMPAD7 = 0x67;
        private const uint VK_NUMPAD8 = 0x68;
        private const uint VK_NUMPAD9 = 0x69;

        // IDs for registered hotkeys
        private const int HOTKEY_ID_0 = 100;
        private const int HOTKEY_ID_1 = 101;
        private const int HOTKEY_ID_2 = 102;
        private const int HOTKEY_ID_3 = 103;
        private const int HOTKEY_ID_4 = 104;
        private const int HOTKEY_ID_5 = 105;
        private const int HOTKEY_ID_6 = 106;
        private const int HOTKEY_ID_7 = 107;
        private const int HOTKEY_ID_8 = 108;
        private const int HOTKEY_ID_9 = 109;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private void PlaySound(string filePath)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }
            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }
            audioFile = new AudioFileReader(filePath);

            // Create output device based on selectedOutputIndex
            try
            {
                if (selectedOutputIndex == 0)
                {
                    // Use WaveOut (replacement for WaveOutEvent) for default device
                    outputDevice = new WaveOut();
                }
                else if (availableMmDevices != null && selectedOutputIndex - 1 < availableMmDevices.Count && selectedOutputIndex - 1 >= 0)
                {
                    var dev = availableMmDevices[selectedOutputIndex - 1];
                    // Use WasapiPlayerBuilder for the selected MMDevice
                    outputDevice = new WasapiPlayerBuilder()
                        .WithDevice(dev)
                        .WithLatency(200)
                        .Build();
                }
                else
                {
                    // final fallback to default
                    outputDevice = new WaveOut();
                }
            }
            catch
            {
                // ensure we have a working player
                try { outputDevice = new WaveOut(); } catch { outputDevice = null; }
            }

            outputDevice.Init(audioFile);
            // Apply current UI volume to the playback device
            SetVolume();
            outputDevice.Play();
        }

        private void StopSound()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }
            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }
        }

        // Read the current volume from the UI volume control (VolumeBar) and apply it
        public void SetVolume()
        {
            float volume = 1.0f; // default full volume

            try
            {
                if (VolumeBar != null)
                {
                    var t = VolumeBar.GetType();
                    var prop = t.GetProperty("Volume") ?? t.GetProperty("Value");
                    if (prop != null)
                    {
                        var raw = prop.GetValue(VolumeBar);
                        if (raw is float f)
                        {
                            volume = f;
                        }
                        else if (raw is double d)
                        {
                            volume = (float)d;
                        }
                        else if (raw is int i)
                        {
                            volume = i;
                        }
                        else if (raw is decimal dec)
                        {
                            volume = (float)dec;
                        }
                        else if (raw != null)
                        {
                            float.TryParse(raw.ToString(), out volume);
                        }

                        // Normalize if value appears to be 0..100
                        if (volume > 1.5f)
                        {
                            volume = MathF.Min(1f, volume / 100f);
                        }
                        volume = MathF.Max(0f, MathF.Min(1f, volume));
                    }
                }

                // Apply to audio source if available
                if (audioFile != null)
                {
                    audioFile.Volume = volume;
                }

                // Attempt to set volume on output device if it exposes Volume
                if (outputDevice != null)
                {
                    var odType = outputDevice.GetType();
                    var volProp = odType.GetProperty("Volume");
                    if (volProp != null && volProp.CanWrite)
                    {
                        // WaveOutEvent.Volume expects float 0..1
                        volProp.SetValue(outputDevice, volume);
                    }
                }
            }
            catch
            {
                // Ignore any errors setting volume to keep UI responsive
            }
        }

        public void SoundOffMainForm_Load(object sender, EventArgs e)
        {
            // Load settings and initialize the form
            SoundFile1.Hide();
            SoundFile2.Hide();
            SoundFile3.Hide();
            SoundFile4.Hide();
            SoundFile5.Hide();
            SoundFile6.Hide();
            SoundFile7.Hide();
            SoundFile8.Hide();
            SoundFile9.Hide();
            // Populate available output devices and select default (0)
            PopulateOutputDevices();

            // Attempt to load default preset silently on startup
            TryLoadDefaultPreset();

            // Wire double-click on output list to copy value into numeric selector
            if (SoundOutputBox != null)
            {
                SoundOutputBox.DoubleClick -= SoundOutputBox_DoubleClick;
                SoundOutputBox.DoubleClick += SoundOutputBox_DoubleClick;
            }

            // Register global hotkeys for numpad 0-9
            // IDs chosen are in the HOTKEY_ID_* constants above
            RegisterHotKey(this.Handle, HOTKEY_ID_0, MOD_NONE, VK_NUMPAD0);
            RegisterHotKey(this.Handle, HOTKEY_ID_1, MOD_NONE, VK_NUMPAD1);
            RegisterHotKey(this.Handle, HOTKEY_ID_2, MOD_NONE, VK_NUMPAD2);
            RegisterHotKey(this.Handle, HOTKEY_ID_3, MOD_NONE, VK_NUMPAD3);
            RegisterHotKey(this.Handle, HOTKEY_ID_4, MOD_NONE, VK_NUMPAD4);
            RegisterHotKey(this.Handle, HOTKEY_ID_5, MOD_NONE, VK_NUMPAD5);
            RegisterHotKey(this.Handle, HOTKEY_ID_6, MOD_NONE, VK_NUMPAD6);
            RegisterHotKey(this.Handle, HOTKEY_ID_7, MOD_NONE, VK_NUMPAD7);
            RegisterHotKey(this.Handle, HOTKEY_ID_8, MOD_NONE, VK_NUMPAD8);
            RegisterHotKey(this.Handle, HOTKEY_ID_9, MOD_NONE, VK_NUMPAD9);

            // Ensure hotkeys are unregistered when form closes
            this.FormClosing += SoundOffMainForm_FormClosing;
        }

        private void SoundOutputBox_DoubleClick(object? sender, EventArgs e)
        {
            try
            {
                if (SoundOutputBox == null || SoundOutputBox.SelectedItem == null) return;
                var item = SoundOutputBox.SelectedItem.ToString() ?? string.Empty;
                // Expect format like "N: Name" where N is numeric
                var parts = item.Split(':');
                int val = 0;
                if (parts.Length > 0 && int.TryParse(parts[0].Trim(), out var parsed))
                {
                    val = parsed;
                }
                else
                {
                    // fallback to SelectedIndex
                    val = SoundOutputBox.SelectedIndex;
                }

                if (SoundOutputNumeric != null)
                {
                    var min = SoundOutputNumeric.Minimum;
                    var max = SoundOutputNumeric.Maximum;
                    var toSet = Math.Min((decimal)val, max);
                    toSet = Math.Max(toSet, min);
                    SoundOutputNumeric.Value = toSet;
                }
            }
            catch
            {
                // ignore errors
            }
        }

        private void ApplyPreset(SoundPreset preset)
        {
            if (preset == null) return;

            // Apply entries
            foreach (var entry in preset.Entries)
            {
                if (entry == null) continue;
                int i = entry.Number;
                if (i < 1 || i > 9) continue;

                var soundLabelObj = this.Controls.Find($"Sound{i}", true);
                if (soundLabelObj != null && soundLabelObj.Length > 0 && soundLabelObj[0] is Label sl)
                {
                    sl.Show();
                    var displayName = entry.Name ?? string.Empty;
                    if (displayName.StartsWith($"{i}:") || displayName.StartsWith($"{i} :"))
                        sl.Text = displayName;
                    else
                        sl.Text = $"{i}: {displayName}".Trim();
                }

                var soundFileLabelObj = this.Controls.Find($"SoundFile{i}", true);
                if (soundFileLabelObj != null && soundFileLabelObj.Length > 0 && soundFileLabelObj[0] is Label sfl)
                {
                    var path = entry.Path;
                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        sfl.Tag = path;
                        try { sfl.Text = Path.GetFileName(path); } catch { sfl.Text = string.Empty; }
                    }
                    else
                    {
                        sfl.Tag = null;
                        sfl.Text = string.Empty;
                    }
                    sfl.Hide();
                }
            }

            // Apply selected output
            try
            {
                selectedOutputIndex = preset.SelectedOutput;
                if (SoundOutputNumeric != null)
                {
                    var max = SoundOutputNumeric.Maximum;
                    var min = SoundOutputNumeric.Minimum;
                    var val = Math.Min((decimal)selectedOutputIndex, max);
                    val = Math.Max(val, min);
                    SoundOutputNumeric.Value = val;
                }

                if (SoundOutputBox != null && SoundOutputBox.Items.Count > 0)
                {
                    int sel = Math.Min(SoundOutputBox.Items.Count - 1, Math.Max(0, selectedOutputIndex));
                    SoundOutputBox.SelectedIndex = sel;
                }
            }
            catch { }

            // Apply volume
            try
            {
                var vol = preset.Volume;
                if (VolumeBar != null)
                {
                    var t = VolumeBar.GetType();
                    var prop = t.GetProperty("Volume") ?? t.GetProperty("Value");
                    if (prop != null && prop.CanWrite)
                    {
                        if (prop.PropertyType == typeof(float)) prop.SetValue(VolumeBar, vol);
                        else if (prop.PropertyType == typeof(double)) prop.SetValue(VolumeBar, (double)vol);
                        else if (prop.PropertyType == typeof(int)) prop.SetValue(VolumeBar, (int)(vol * 100));
                        else if (prop.PropertyType == typeof(decimal)) prop.SetValue(VolumeBar, (decimal)vol);
                    }
                }

                SetVolume();
            }
            catch { }
        }

        private void TryLoadDefaultPreset()
        {
            try
            {
                var presetsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Presets Folder");
                if (!Directory.Exists(presetsFolder)) return;

                // Try DefaultP.json then DefaultP
                var candidates = new[] { Path.Combine(presetsFolder, "DefaultP.json"), Path.Combine(presetsFolder, "DefaultP") };
                foreach (var path in candidates)
                {
                    if (File.Exists(path))
                    {
                        try
                        {
                            var json = File.ReadAllText(path);
                            var preset = JsonSerializer.Deserialize<SoundPreset>(json);
                            if (preset != null)
                            {
                                ApplyPreset(preset);
                            }
                        }
                        catch { }
                        break;
                    }
                }
            }
            catch { }
        }

        private void PopulateOutputDevices()
        {
            try
            {
                SoundOutputBox.Items.Clear();
                // Add default device as 0
                SoundOutputBox.Items.Add("0: Default Device");

                using (var enumerator = new MMDeviceEnumerator())
                {
                    var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
                    int idx = 1;
                    availableMmDevices.Clear();
                    foreach (var dev in devices)
                    {
                        SoundOutputBox.Items.Add($"{idx}: {dev.FriendlyName}");
                        availableMmDevices.Add(dev);
                        idx++;
                    }
                }
            }
            catch
            {
                // Fallback to WaveOut devices if MMDeviceEnumerator not available
                try
                {
                    SoundOutputBox.Items.Clear();
                    SoundOutputBox.Items.Add("0: Default Device");
                    availableMmDevices.Clear();
                    int count = WaveOut.DeviceCount;
                    for (int i = 0; i < count; i++)
                    {
                        var caps = WaveOut.GetCapabilities(i);
                        SoundOutputBox.Items.Add($"{i + 1}: {caps.ProductName}");
                    }
                    // waveOutDeviceNumber will map to these indices minus 1
                }
                catch
                {
                    // If enumeration fails, at least ensure default is present
                    if (SoundOutputBox.Items.Count == 0)
                        SoundOutputBox.Items.Add("0: Default Device");
                }
            }

            // Ensure default selection is index 0
            if (SoundOutputBox.Items.Count > 0)
                SoundOutputBox.SelectedIndex = 0;
        }

        private void SoundOffMainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Unregister hotkeys
            UnregisterHotKey(this.Handle, HOTKEY_ID_0);
            UnregisterHotKey(this.Handle, HOTKEY_ID_1);
            UnregisterHotKey(this.Handle, HOTKEY_ID_2);
            UnregisterHotKey(this.Handle, HOTKEY_ID_3);
            UnregisterHotKey(this.Handle, HOTKEY_ID_4);
            UnregisterHotKey(this.Handle, HOTKEY_ID_5);
            UnregisterHotKey(this.Handle, HOTKEY_ID_6);
            UnregisterHotKey(this.Handle, HOTKEY_ID_7);
            UnregisterHotKey(this.Handle, HOTKEY_ID_8);
            UnregisterHotKey(this.Handle, HOTKEY_ID_9);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    case HOTKEY_ID_0:
                        StopSound();
                        break;
                    case HOTKEY_ID_1:
                        TryPlayFromLabel(SoundFile1);
                        break;
                    case HOTKEY_ID_2:
                        TryPlayFromLabel(SoundFile2);
                        break;
                    case HOTKEY_ID_3:
                        TryPlayFromLabel(SoundFile3);
                        break;
                    case HOTKEY_ID_4:
                        TryPlayFromLabel(SoundFile4);
                        break;
                    case HOTKEY_ID_5:
                        TryPlayFromLabel(SoundFile5);
                        break;
                    case HOTKEY_ID_6:
                        TryPlayFromLabel(SoundFile6);
                        break;
                    case HOTKEY_ID_7:
                        TryPlayFromLabel(SoundFile7);
                        break;
                    case HOTKEY_ID_8:
                        TryPlayFromLabel(SoundFile8);
                        break;
                    case HOTKEY_ID_9:
                        TryPlayFromLabel(SoundFile9);
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void TryPlayFromLabel(Label lbl)
        {
            if (lbl == null) return;
            // Prefer full path stored in Tag; fall back to Text for compatibility
            var path = lbl.Tag as string ?? lbl.Text;
            if (string.IsNullOrWhiteSpace(path)) return;
            if (File.Exists(path))
            {
                try
                {
                    PlaySound(path);
                }
                catch
                {
                    // swallow exceptions from playing; keep UI responsive
                }
            }
        }
        private void OpenNewSoundFormButton_Click(object sender, EventArgs e)
        {
            SoundOffAddSoundForm AddSound = new SoundOffAddSoundForm();
            AddSound.Show();
        }
        private void SetOutputButton_Click(object sender, EventArgs e)
        {
            try
            {
                int val = 0;
                // Use SoundOutputNumeric as the control for selecting device index
                if (SoundOutputNumeric != null)
                    val = (int)SoundOutputNumeric.Value;

                if (val < 0) val = 0;

                // If value corresponds to available MMDevice, select it; otherwise revert to default
                if (val == 0)
                {
                    selectedOutputIndex = 0;
                }
                else if (availableMmDevices != null && val - 1 < availableMmDevices.Count)
                {
                    selectedOutputIndex = val;
                }
                else
                {
                    // Invalid selection - revert to default
                    selectedOutputIndex = 0;
                }

                // Update UI selection in the list if possible
                if (SoundOutputBox != null && SoundOutputBox.Items.Count > 0)
                {
                    int sel = Math.Min(SoundOutputBox.Items.Count - 1, Math.Max(0, val));
                    SoundOutputBox.SelectedIndex = sel;
                }
            }
            catch
            {
                // ignore errors and keep default output
                selectedOutputIndex = 0;
            }
        }

        private void SaveSoundPresetButton_Click(object sender, EventArgs e)
        {
            try
            {
                var presetsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Presets Folder");
                if (!Directory.Exists(presetsFolder))
                    Directory.CreateDirectory(presetsFolder);

                var entries = new List<PresetEntry>();
                for (int i = 1; i <= 9; i++)
                {
                    string? name = null;
                    string? path = null;
                    var soundLabel = this.Controls.Find($"Sound{i}", true);
                    if (soundLabel != null && soundLabel.Length > 0 && soundLabel[0] is Label sl)
                    {
                        name = sl.Text;
                    }
                    var soundFileLabel = this.Controls.Find($"SoundFile{i}", true);
                    if (soundFileLabel != null && soundFileLabel.Length > 0 && soundFileLabel[0] is Label sfl)
                    {
                        path = sfl.Tag as string ?? sfl.Text;
                    }
                    entries.Add(new PresetEntry(i, name, path));
                }

                // Attempt to read current volume
                float volume = 1.0f;
                try
                {
                    if (VolumeBar != null)
                    {
                        var t = VolumeBar.GetType();
                        var prop = t.GetProperty("Volume") ?? t.GetProperty("Value");
                        if (prop != null)
                        {
                            var raw = prop.GetValue(VolumeBar);
                            if (raw is float f) volume = f;
                            else if (raw is double d) volume = (float)d;
                            else if (raw is int iv) volume = iv;
                            else if (raw != null) float.TryParse(raw.ToString(), out volume);
                            if (volume > 1.5f) volume = MathF.Min(1f, volume / 100f);
                            volume = MathF.Max(0f, MathF.Min(1f, volume));
                        }
                    }
                }
                catch { }

                var preset = new SoundPreset(entries, selectedOutputIndex, volume);
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(preset, jsonOptions);

                using (var sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = presetsFolder;
                    sfd.Filter = "JSON Preset|*.json|All Files|*.*";
                    sfd.Title = "Save preset as...";
                    sfd.FileName = "preset.json";
                    if (sfd.ShowDialog(this) != DialogResult.OK) return;

                    var chosen = sfd.FileName;
                    try
                    {
                        // Ensure .json extension
                        if (Path.GetExtension(chosen)?.ToLowerInvariant() != ".json")
                            chosen = chosen + ".json";
                        File.WriteAllText(chosen, json);
                        MessageBox.Show(this, $"Saved preset to: {chosen}", "Preset Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, $"Failed to save preset: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to save preset: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSoundPresetButton_Click(object sender, EventArgs e)
        {
            try
            {
                var presetsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Presets Folder");
                if (!Directory.Exists(presetsFolder))
                {
                    MessageBox.Show(this, "No Presets Folder found.", "Load Preset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var ofd = new OpenFileDialog())
                {
                    ofd.InitialDirectory = presetsFolder;
                    ofd.Filter = "JSON Preset|*.json|All Files|*.*";
                    ofd.Title = "Select a preset to load";
                    if (ofd.ShowDialog(this) != DialogResult.OK) return;

                    var json = File.ReadAllText(ofd.FileName);
                    var preset = JsonSerializer.Deserialize<SoundPreset>(json);
                    if (preset == null)
                    {
                        MessageBox.Show(this, "Failed to parse preset file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Apply entries
                    foreach (var entry in preset.Entries)
                    {
                        if (entry == null) continue;
                        int i = entry.Number;
                        if (i < 1 || i > 9) continue;

                        var soundLabelObj = this.Controls.Find($"Sound{i}", true);
                        if (soundLabelObj != null && soundLabelObj.Length > 0 && soundLabelObj[0] is Label sl)
                        {
                            sl.Show();
                            // store display name without duplicating numeric prefix
                            var displayName = entry.Name ?? string.Empty;
                            // If displayName already contains a colon prefix, avoid adding another
                            if (displayName.StartsWith($"{i}:") || displayName.StartsWith($"{i} :"))
                                sl.Text = displayName;
                            else
                                sl.Text = $"{i}: {displayName}".Trim();
                        }

                        var soundFileLabelObj = this.Controls.Find($"SoundFile{i}", true);
                        if (soundFileLabelObj != null && soundFileLabelObj.Length > 0 && soundFileLabelObj[0] is Label sfl)
                        {
                            // store full path in Tag, keep visible text as filename, and hide the label
                            var path = entry.Path;
                            if (!string.IsNullOrWhiteSpace(path))
                            {
                                sfl.Tag = path;
                                try { sfl.Text = Path.GetFileName(path); } catch { sfl.Text = string.Empty; }
                            }
                            else
                            {
                                sfl.Tag = null;
                                sfl.Text = string.Empty;
                            }
                            sfl.Hide();
                        }
                    }

                    // Apply selected output
                    try
                    {
                        selectedOutputIndex = preset.SelectedOutput;
                        if (SoundOutputNumeric != null)
                        {
                            var max = SoundOutputNumeric.Maximum;
                            var min = SoundOutputNumeric.Minimum;
                            var val = Math.Min((decimal)selectedOutputIndex, max);
                            val = Math.Max(val, min);
                            SoundOutputNumeric.Value = val;
                        }

                        // Update list selection
                        if (SoundOutputBox != null && SoundOutputBox.Items.Count > 0)
                        {
                            int sel = Math.Min(SoundOutputBox.Items.Count - 1, Math.Max(0, selectedOutputIndex));
                            SoundOutputBox.SelectedIndex = sel;
                        }
                    }
                    catch { }

                    // Apply volume
                    try
                    {
                        var vol = preset.Volume;
                        if (VolumeBar != null)
                        {
                            var t = VolumeBar.GetType();
                            var prop = t.GetProperty("Volume") ?? t.GetProperty("Value");
                            if (prop != null && prop.CanWrite)
                            {
                                // try to set the property in a compatible type
                                if (prop.PropertyType == typeof(float)) prop.SetValue(VolumeBar, vol);
                                else if (prop.PropertyType == typeof(double)) prop.SetValue(VolumeBar, (double)vol);
                                else if (prop.PropertyType == typeof(int)) prop.SetValue(VolumeBar, (int)(vol * 100));
                                else if (prop.PropertyType == typeof(decimal)) prop.SetValue(VolumeBar, (decimal)vol);
                            }
                        }

                        // Also apply to current audio if any
                        SetVolume();
                    }
                    catch { }

                    MessageBox.Show(this, "Preset loaded.", "Load Preset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load preset: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
