using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MAIB
{
    public partial class DataProperties : Form
    {
        public DataProperties()
        {
            InitializeComponent();
        }

        private void buttonApplyProperties_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Вы уверены?", @"Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            Hide();
        }
    }
}
