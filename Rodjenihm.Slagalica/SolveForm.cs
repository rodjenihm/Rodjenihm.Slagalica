using Rodjenihm.Slagalica.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rodjenihm.Slagalica
{
    public partial class SolveForm : Form
    {
        private List<InputLetter> txtInputLetters;
        private readonly int inputCount = 12;

        public SolveForm()
        {
            InitializeComponent();
        }

        private void SolveForm_Load(object sender, EventArgs e)
        {
            txtInputLetters = new List<InputLetter>(inputCount);

            for (int i = 0; i < txtInputLetters.Capacity; i++)
            {
                txtInputLetters.Add(new InputLetter()
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
            var inputLetter = sender as InputLetter;
            var text = inputLetter.Text;

            if (InputLetter.allowedInput.Contains(text) || text == string.Empty)
            {
                inputLetter.PreviousText = text;
            }
            else
            {
                inputLetter.Text = inputLetter.PreviousText;
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            foreach (var inputLetter in txtInputLetters)
            {
                inputLetter.Text = string.Empty;
            }
            txtResult.Text = string.Empty;
            btnSolve.Enabled = true;
        }

        private void BtnSolve_Click(object sender, EventArgs e)
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
            foreach (var word in WordList.Instance.Words)
            {
                if (IsMatch(word, letters))
                {
                    txtResult.Text = word
                        .Replace("1", "dž")
                        .Replace("2", "lj")
                        .Replace("3", "nj");
                    break;
                }
            }
        }

        public static bool IsMatch(string word, IEnumerable<string> letters)
        {
            var let = letters.ToList();
            foreach (var letter in word)
            {
                var s = letter.ToString();
                if (!let.Contains(s))
                {
                    return false;
                }
                else
                {
                    let.Remove(s);
                }
            }
            return true;
        }
    }
}
