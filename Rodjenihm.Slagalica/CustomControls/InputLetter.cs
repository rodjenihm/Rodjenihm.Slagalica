using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rodjenihm.Slagalica.CustomControls
{
    public class InputLetter : TextBox
    {
        private TextBox innerTextBox;
        public static readonly List<string> allowedInput = new List<string>
        {
            "a", "b", "c", "č", "ć",
            "d", "dž", "đ", "e", "f",
            "g", "h", "i", "j", "k",
            "l", "lj", "m", "n", "nj",
            "o", "p", "r", "s", "š",
            "t", "u", "v", "z", "ž",
        };
        public string PreviousText { get; set; } = string.Empty;

        public InputLetter()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.innerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // innerTextBox
            // 
            this.innerTextBox.Location = new System.Drawing.Point(0, 0);
            this.innerTextBox.Name = "innerTextBox";
            this.innerTextBox.Size = new System.Drawing.Size(100, 20);
            this.innerTextBox.TabIndex = 0;
            this.ResumeLayout(false);
        }
    }
}
