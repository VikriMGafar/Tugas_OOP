using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        private void subMenu2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tssPesan.Text = "anda masuk sub menu 2";
        }

        private void menu2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tssPesan.Text = "anda masuk Menu 2";
        }
    }
}
