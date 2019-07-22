using Rodjenihm.Slagalica.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Rodjenihm.Slagalica
{
    public partial class SolveForm : Form
    {
        private List<InputLetterTextBox> txtInputLetters;
        private readonly int inputCount = 12;

        public SolveForm()
        {
            InitializeComponent();
        }

        private void SolveForm_Load(object sender, EventArgs e)
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
                    TabIndex = i,
                    Font = new Font(Font.FontFamily, 12.0f, FontStyle.Bold),
                });
                txtInputLetters[i].TextChanged += InputLetter_TextChanged;
                gbInputLetters.Controls.Add(txtInputLetters[i]);
            }
        }

        private void InputLetter_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            foreach (var inputLetter in txtInputLetters)
            {
                inputLetter.Clear();
            }
            txtResult.Clear();
            btnSolve.Enabled = true;
        }

        private void BtnSolve_Click(object sender, EventArgs e)
        {
            if (Utilities.ValidateInput(txtInputLetters))
            {
                btnSolve.Enabled = false;
                var letters = new List<string>(inputCount);
                foreach (var inputLetter in txtInputLetters)
                {
                    letters.Add(inputLetter.Text
                        .Replace("dž", "1")
                        .Replace("lj", "2")
                        .Replace("nj", "3"));
                }
                foreach (var solution in WordList.Instance.Words.Where(w => Utilities.IsMatch(w, letters)).Take(1)) // Take(1) za samo jednu rec
                {
                    txtResult.Text += solution
                        .Replace("1", "dž")
                        .Replace("2", "lj")
                        .Replace("3", "nj") + "\r\n";
                }
            }
            else
            {
                MessageBox.Show(Owner, "Ulazni podaci nisu ispravni\nUnesite samo slova srpske abecede.", "Neispravan unos");
            }
        }
    }
}
