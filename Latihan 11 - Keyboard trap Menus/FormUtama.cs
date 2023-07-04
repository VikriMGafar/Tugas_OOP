using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_11___Keyboard_trap_Menus
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        private void subMenu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTrap ft = new FormTrap();
            ft.MdiParent = this;
            ft.Show();
            
        }

        private void menu2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tssStatus.Text = "Menu 2 dipilih";
        }

        private void menu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tssStatus.Text = "Menu 1 dipilih";

        }

        private void subMenu2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
