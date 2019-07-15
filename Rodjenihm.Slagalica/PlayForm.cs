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
        private List<string> _dictionary;

        public PlayForm()
        {
            InitializeComponent();
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
            using (var fileStream = new FileStream(ConfigurationManager.AppSettings["dictionaryPath"], FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var dictionarySize = int.Parse(streamReader.ReadLine());
                    _dictionary = new List<string>(dictionarySize);
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        _dictionary.Add(line);
                    }
                }
            }
        }
    }
}
