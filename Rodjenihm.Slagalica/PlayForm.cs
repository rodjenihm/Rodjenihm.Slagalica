using Rodjenihm.Slagalica.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rodjenihm.Slagalica
{
    public partial class PlayForm : Form
    {
        public static readonly List<string> allowedInput = new List<string>
        {
            "a", "b", "c", "č", "ć",
            "d", "dž", "đ", "e", "f",
            "g", "h", "i", "j", "k",
            "l", "lj", "m", "n", "nj",
            "o", "p", "r", "s", "š",
            "t", "u", "v", "z", "ž",
        };
        private List<InputLetterTextBox> txtInputLetters;
        private readonly int inputCount = 12;
        private Timer pickerTimer;
        private Timer progressTimer;
        private readonly Random random = new Random();
        private int idx;

        public PlayForm()
        {
            InitializeComponent();
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
            txtInputLetters = new List<InputLetterTextBox>(inputCount);

            for (int i = 0; i < txtInputLetters.Capacity; i++)
            {
                txtInputLetters.Add(new InputLetterTextBox()
                {
                    Width = 30,
                    Height = 30,
                    Location = new Point(10 + 50 * i, 35),
                    TextAlign = HorizontalAlignment.Center,
                    MaxLength = 2,
                    TabStop = false,
                    Font = new Font(Font.FontFamily, 12.0f, FontStyle.Bold),
                    ReadOnly = true,
                    BackColor = Color.Ivory,
                });

                gbRandomLetters.Controls.Add(txtInputLetters[i]);

                pickerTimer = new Timer();
                pickerTimer.Interval = 10;
                pickerTimer.Tick += (s, ev) =>
                    txtInputLetters[idx].Text = allowedInput[random.Next(0, allowedInput.Count)];

                progressTimer = new Timer();
                progressTimer.Interval = 1000;
                pbTimeLeft.Maximum = 10;
                progressTimer.Tick += (s, ev) =>
                {
                    if (pbTimeLeft.Value >= pbTimeLeft.Maximum)
                    {
                        btnStart.Enabled = true;
                        btnStop.Enabled = false;
                        progressTimer.Enabled = false;
                        MessageBox.Show("You failed!");
                    }
                    else
                    {
                        pbTimeLeft.Value += pbTimeLeft.Step;
                    }
                };
            }
        }

        private void PlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pickerTimer.Enabled = false;
            progressTimer.Enabled = false;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            idx = 0;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            pickerTimer.Enabled = true;

            foreach (var inputLetter in txtInputLetters)
            {
                inputLetter.Clear();
            }

            pbTimeLeft.Value = pbTimeLeft.Minimum;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (idx++ == inputCount - 1)
            {
                btnStop.Enabled = false;
                pickerTimer.Enabled = false;
                progressTimer.Enabled = true;
            }
        }
    }
}
