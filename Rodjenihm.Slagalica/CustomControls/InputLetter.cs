using System.Windows.Forms;

namespace Rodjenihm.Slagalica.CustomControls
{
    public class InputLetterTextBox : TextBox
    {
        private TextBox innerTextBox;

        public InputLetterTextBox()
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
