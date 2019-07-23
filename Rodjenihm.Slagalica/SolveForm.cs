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
            var inputLetter = sender as InputLetterTextBox;
            inputLetter.Text = inputLetter.Text.ToLower();
            inputLetter.SelectionStart = inputLetter.Text.Length;
            inputLetter.SelectionLength = 0;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtInputLetters.ForEach(i => i.Clear());
            txtResult.Clear();
        }

        private void BtnSolve_Click(object sender, EventArgs e)
        {
            if (Utilities.ValidateInput(txtInputLetters))
            {
                txtResult.Clear();
                var letters = new List<string>(inputCount);
                foreach (var inputLetter in txtInputLetters)
                {
                    letters.Add(inputLetter.Text.Replace("dž", "1").Replace("lj", "2").Replace("nj", "3"));
                }
                var solutions = Utilities.GetSolutions(letters);
                Utilities.DisplaySolutions(solutions, txtResult);
            }
            else
            {
                MessageBox.Show("Ulazni podaci nisu ispravni\nUnesite samo slova srpske abecede.", "Neispravan unos");
            }
        }
    }
}
