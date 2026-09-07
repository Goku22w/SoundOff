using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NAudio.Wave;
namespace SoundOff
{
    public partial class SoundOffMainForm : Form
    {
        public SoundOffMainForm()
        {
            InitializeComponent();
        }
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

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
        }
    }
}
