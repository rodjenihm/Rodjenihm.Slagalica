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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            var playForm = new PlayForm();
            playForm.Show();
        }

        private void BtnSolve_Click(object sender, EventArgs e)
        {

        }
    }
}
